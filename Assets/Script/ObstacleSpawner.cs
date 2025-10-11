using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform cameraTransform;
    public float spawnOffset = 15f; 

    public float initialMinDistance = 15f;
    public float minDistanceBetweenObstacles;

    private float totalPlayTime = 0f;
    [SerializeField]
    private float interval = 10f;
    [SerializeField]
    private float val = 0.5f;
    [SerializeField]
    private float minimumDistance = 5f;

    private float nextSpawnX;

    void Start()
    {
        totalPlayTime = 0f;
        minDistanceBetweenObstacles = initialMinDistance;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // 初期生成位置をカメラの位置+オフセットで決定
        // ここではまだ生成しない
        nextSpawnX = cameraTransform.position.x + spawnOffset;
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

        // 修正: カメラが次の生成位置に十分近づいたら新しい障害物を生成
        if (cameraTransform.position.x > nextSpawnX - spawnOffset)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];
        
        // 生成位置はnextSpawnXを使用する
        Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);

        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);

        // 修正: 次の生成位置を更新
        nextSpawnX = cameraTransform.position.x + spawnOffset + minDistanceBetweenObstacles;
    }
}
