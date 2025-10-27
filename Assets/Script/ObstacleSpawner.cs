using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    // 敵とアイテムのプレハブ配列
    public GameObject[] enemyPrefabs;
    public GameObject[] itemPrefabs;

    // カメラと生成に関する設定
    public Transform cameraTransform;
    [SerializeField]
    public float spawnOffset = 15f; // カメラの可視範囲の右端からオブジェクトを生成するまでの距離

    // 障害物間の距離に関する設定
    [SerializeField]
    public float initialMinDistance = 10f;
    private float minDistanceBetweenObstacles;

    // 難易度調整用
    private float totalPlayTime = 0f;
    [SerializeField]
    private float interval = 10f;
    [SerializeField]
    private float val = 0.5f;
    [SerializeField]
    private float minimumDistance = 5f;

    // 生成位置管理
    private float nextSpawnX;

    // 特定のアイテムに関する設定
    [SerializeField]
    private float spawnSpecificInterval = 6f; // 特定アイテムの出現間隔
    private float specificItemSpawnTimer; // 内部で使用するタイマー

    // 通常時のアイテム出現に関する設定
    [Range(0f, 1f)]
    public float itemSpawnProbability = 0.2f; // 通常時のアイテム出現確率 (0.0～1.0)

    void Start()
    {
        totalPlayTime = 0f;
        minDistanceBetweenObstacles = initialMinDistance;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        nextSpawnX = cameraTransform.position.x + spawnOffset;
        specificItemSpawnTimer = spawnSpecificInterval;
    }

    void Update()
    {
        totalPlayTime += Time.deltaTime;
        if (totalPlayTime >= interval)
        {
            if (minDistanceBetweenObstacles > minimumDistance)
            {
                minDistanceBetweenObstacles -= val;
            }
            totalPlayTime = 0f;
        }

        specificItemSpawnTimer -= Time.deltaTime;

        // カメラの可視範囲の右端が次の生成位置を通り過ぎたら生成
        if (cameraTransform.position.x + spawnOffset > nextSpawnX)
        {
            if (specificItemSpawnTimer <= 0)
            {
                SpawnSpecificItemAndEnemy();
                specificItemSpawnTimer = spawnSpecificInterval; // タイマーをリセット
            }
            else
            {
                SpawnNormalObstacle();
            }
            // オブジェクトを生成した直後に次の生成位置を更新
            nextSpawnX = cameraTransform.position.x + spawnOffset + minDistanceBetweenObstacles;
        }
    }

    /// <summary>
    /// アイテムの要素番号0と敵の要素番号2を同時に生成します。
    /// </summary>
    void SpawnSpecificItemAndEnemy()
    {
        // アイテムの要素番号0を生成
        if (itemPrefabs.Length > 0 && itemPrefabs != null)
        {
            Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);
            // ★修正箇所: 配列の0番目を指定
            Instantiate(itemPrefabs[0], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("アイテムプレハブの要素番号0が存在しないか、設定されていません。");
        }

        // 敵の要素番号2を同時に生成
        if (enemyPrefabs.Length > 2 && enemyPrefabs != null)
        {
            Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);
            // ★修正箇所: 配列の2番目を指定
            Instantiate(enemyPrefabs[2], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("敵プレハブの要素番号2が存在しないか、設定されていません。");
        }
    }

    /// <summary>
    /// 通常の敵かランダムなアイテムを生成します。
    /// </summary>
    void SpawnNormalObstacle()
    {
        GameObject objectToSpawn = null;

        // ランダムな値で敵かアイテムかを判定
        if (Random.value < itemSpawnProbability)
        {
            // アイテムの配列からランダムに選択（要素番号0は定期生成用なので除外）
            if (itemPrefabs.Length > 1)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, itemPrefabs.Length);
                } while (randomIndex == 0);
                objectToSpawn = itemPrefabs[randomIndex];
            }
        }
        else
        {
            // 敵の配列からランダムに選択（すべての敵が対象）
            if (enemyPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                objectToSpawn = enemyPrefabs[randomIndex];
            }
        }

        // 障害物を生成
        if (objectToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
