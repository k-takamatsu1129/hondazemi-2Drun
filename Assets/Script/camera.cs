using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // カメラが追跡するターゲット（プレイヤー）
    public Transform target;
    // カメラとターゲットの間の距離
    public Vector3 offset = new Vector3(0, 0, -10);

    // カメラの動きを滑らかにするための変数
    [SerializeField] private float smoothSpeed = 0.125f;

    void Start()
    {
        // ターゲットが設定されていない場合、"Player"タグの付いたオブジェクトを探す
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    // LateUpdateでカメラを追跡させる
    void LateUpdate()
    {
        if (target == null) return;

        // 追跡先の位置を計算
        Vector3 desiredPosition = target.position + offset;
        // 現在位置から追跡先までを滑らかに補間
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}