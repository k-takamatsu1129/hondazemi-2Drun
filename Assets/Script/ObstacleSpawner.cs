using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 生成する障害物のプレハブを格納する配列
    public Transform cameraTransform;    // メインカメラのTransform
    public float spawnOffset = 15f;      // カメラからの生成位置のオフセット
    public float enemyspown = 3f;

    private float time;
    private float totalPlayTime;
    [SerializeField]
    private float intarval = 10f;  

    void Start()
    {
        // cameraTransformが設定されていなければ、メインカメラを探す
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        time += Time.deltaTime;  //生成時間
        totalPlayTime += Time.deltaTime;  //生成間隔

        //生成間隔の変更
        if(totalPlayTime >= intarval){
            if(enemyspown > 1f){
            enemyspown -= 0.2f;
            }
            totalPlayTime -= intarval;
        }

        // 次の生成タイミングが来たかチェック
        if (time > enemyspown)
        {
            SpawnObstacle();
            // 次の生成タイミングを更新
            time = 0f;
        }
    }

    void SpawnObstacle()
    {
        // 配列からランダムにプレハブを選択
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

        // カメラの位置を基準に、画面外の右側に位置を決定
        float spawnX = cameraTransform.position.x + spawnOffset;
        
        // y座標を0に固定
        Vector3 spawnPosition = new Vector3(spawnX, 0, 0);

        // 障害物を生成
        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}
