using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject target; // 追従する対象を決める変数
    private Vector3 initialCameraPosition; // カメラの初期位置を記憶するための変数

    // Start is called before the first frame update
    void Start()
    {
        // カメラの初期位置を取得して保持する
        initialCameraPosition = Camera.main.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        // 追従する対象の位置を取得
        Vector3 targetPosition = target.transform.position; 
        
        // カメラの新しい位置を計算
        Vector3 newCameraPosition = new Vector3(
            targetPosition.x,      // x軸はターゲットに追従
            initialCameraPosition.y, // y軸は初期位置で固定
            initialCameraPosition.z  // z軸も初期位置で固定
        );

        // カメラの位置を更新
        Camera.main.transform.position = newCameraPosition; 
    }
}
