//using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [SerializeField] private string spaceScene = "spaceScene";

    public float speed;  //この変数でスピードを管理
    public float defaultspeed;   //元の変数
    public float fastspeed = 8f;  //早いときの速度の変数
    public float slowspped = 4f;  //遅いときの速度の変数
    public float speedup = 1f; //速度の上げ幅

    private float totalPlayTime = 0f;
    [SerializeField]
    private  float interval = 10f; // 10秒ごとにスピードを上げる
    private const string PlayTimeKey = "TotalPlayTime";

    Rigidbody2D rbody; // リジッドボディを使うための宣言

    private const string Lastspeedkey = "Lastspeed";

    // Start is called before the first frame update
    void Start()
    {
        //速度の初期化
        defaultspeed = PlayerPrefs.GetFloat(Lastspeedkey);
        fastspeed = defaultspeed + 2f;
        slowspped = defaultspeed - 2f;

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
        speed = defaultspeed;
        //時間で速度を管理
        totalPlayTime += Time.deltaTime;
        if(totalPlayTime >= interval){
            defaultspeed +=  speedup;
            fastspeed += speedup;
            slowspped += speedup;
            //rbody.linearDamping += 0.5f; //ジャンプ力も下がってる
            totalPlayTime -= interval;

            PlayerPrefs.SetFloat("Lastspeed", defaultspeed);
            PlayerPrefs.Save();
        }

        if(Input.GetKey(KeyCode.D)){
            speed = fastspeed;
        }
        else if(Input.GetKey(KeyCode.A)){
            speed = slowspped;
        }
        else{
            speed = defaultspeed;
        }
    }

    private void FixedUpdate()
    {
        //リジッドボディに一定の速度を入れる（横移動の速度, リジッドボディのyの速度）
        rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);

    }
}