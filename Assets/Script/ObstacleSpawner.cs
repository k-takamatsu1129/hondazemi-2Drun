using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    // 敵とアイテムの配列を分ける
    public GameObject[] enemyPrefabs;
    public GameObject[] itemPrefabs; // 複数のアイテムを格納できる配列

    public Transform cameraTransform;
    public float spawnOffset = 15f; 

    public float initialMinDistance = 10f;
    public float minDistanceBetweenObstacles;

    private float totalPlayTime = 0f;
    [SerializeField]
    private float interval = 10f;
    [SerializeField]
    private float val = 0.5f;
    [SerializeField]
    private float minimumDistance = 5f;

    private float nextSpawnX;
    private float specificItemSpawnTimer;
    public float spawnSpecificInterval = 9f; // 特定アイテムの出現間隔

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
        if(totalPlayTime >= interval)
        {
            if (minDistanceBetweenObstacles > minimumDistance)
            {
                minDistanceBetweenObstacles -= val;
            }
            totalPlayTime = 0f;
        }

        specificItemSpawnTimer -= Time.deltaTime;
        
        if (cameraTransform.position.x > nextSpawnX - spawnOffset)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject objectToSpawn;
        
        if (specificItemSpawnTimer <= 0)
        {
            // 5秒に1回、アイテム配列からランダムに1つを生成
            if (itemPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, itemPrefabs.Length);
                objectToSpawn = itemPrefabs[randomIndex];
            }
            else
            {
                // アイテムが設定されていなければ、何もしないか、デフォルトの敵を生成するなどの処理
                Debug.LogWarning("アイテムプレハブが設定されていません。");
                return;
            }
            specificItemSpawnTimer = spawnSpecificInterval; // タイマーをリセット
        }
        else
        {
            // アイテム出現タイミングではない場合は敵をランダムに生成
            if (enemyPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                objectToSpawn = enemyPrefabs[randomIndex];
            }
            else
            {
                // 敵が設定されていなければ何もしない
                Debug.LogWarning("敵プレハブが設定されていません。");
                return;
            }
        }

        Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        nextSpawnX = cameraTransform.position.x + spawnOffset + minDistanceBetweenObstacles;
    }
}
