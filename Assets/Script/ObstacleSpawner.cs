using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 生成する障害物のプレハブを格納する配列
    private float time;

    void Update()
    {
        time = time + Time.deltaTime;
        // 次の生成タイミングが来たかチェック
        if (time>2f)
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

        // ランダムな位置を決定
        float randomY = Random.Range(-4.5f, 4.5f); // 画面の上下の範囲
        Vector3 spawnPosition = new Vector3(10, randomY, 0); // 画面外の右側から生成

        // 障害物を生成
        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}