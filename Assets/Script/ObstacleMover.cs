using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftBoundary = -10f; // 画面外（左側）の座標

    void Update()
    {
        // 障害物を左に移動
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 画面外に出たらオブジェクトを削除
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}