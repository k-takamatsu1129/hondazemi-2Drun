//using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class spacecamera : MonoBehaviour
{
    public float speed;   // 横に移動する速度
    public float speedup = 1f; //速度の上げ幅

    private float totalPlayTime = 0f;
    [SerializeField]
    private  float interval = 10f; // 10秒ごとにスピードを上げる
    private const string PlayTimeKey = "TotalPlayTime";

    private const string SpaceCamerakey = "SpaceCamera";

    Rigidbody2D rbody; // リジッドボディを使うための宣言

    // Start is called before the first frame update
    void Start()
    {
        //速度の初期化
        speed = PlayerPrefs.GetFloat(SpaceCamerakey);
        //時間を初期化
        totalPlayTime = 0f;
        //時間の開始
        Time.timeScale = 1;
        // リジッドボディ2Dをコンポーネントから取得して変数に入れる
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        totalPlayTime += Time.deltaTime;
        if(totalPlayTime >= interval){
            speed +=  speedup;
            rbody.linearDamping += 0.5f;
            totalPlayTime -= interval;

            //速度の保存
            PlayerPrefs.SetFloat("SpaceCamera", speed);
            PlayerPrefs.Save();
        }
    }

    private void FixedUpdate()
    {
        //リジッドボディに一定の速度を入れる（横移動の速度, リジッドボディのyの速度）
        rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);

    }
}