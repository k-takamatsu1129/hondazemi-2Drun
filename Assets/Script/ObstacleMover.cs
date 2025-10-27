using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveSpeed = 5f; // 障害物の移動速度
    public float destroyOffset = 10f; // カメラからこの距離離れたら消去
    
    private Transform cameraTransform;

    void Start()
    {
        // メインカメラのTransformをキャッシュ
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Main Camera not found! Please tag a camera with 'MainCamera'.");
        }
    }

    void Update()
    {
        // 障害物を左に動かす
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // カメラから一定距離離れたらオブジェクトを消去
        // ここでの条件は、カメラの位置 - オフセットよりも障害物の位置が左にあるか
        if (cameraTransform != null && transform.position.x < cameraTransform.position.x - destroyOffset)
        {
            Destroy(gameObject);
        }
    }
}
