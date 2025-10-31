using UnityEngine;

public class fly : MonoBehaviour
{
    // 基本の強制スクロール速度
    public float baseSpeed = 6f;
    // Dキーを押したときの加速分
    public float boostSpeed = 8f;
    //Aキーを押したときの速度
    public float slowspeed = 4f;
    // 上下の移動速度
    public float verticalSpeed = 5f;
    public float speedup = 5f;
    public float targetX;

    private float totalPlayTime = 0f;
    [SerializeField]
    private  float interval = 10f; // 10秒ごとにスピードを上げる
    private const string PlayTimeKey = "TotalPlayTime";

    // 加速、減速の速さ
    public float acceleration = 7f;
    public float deceleration = 10f;

    // 画面の縦方向の移動範囲を制限
    public float verticalLimit = 8f;

    // Rigidbody2Dコンポーネントへの参照
    private Rigidbody2D rb;
    
    // 現在の目標速度
    private Vector2 targetVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 重力の影響をなくす
        rb.gravityScale = 0;
        //時間を初期化
        totalPlayTime = 0f;
        //時間の開始
        Time.timeScale = 1;
    }

    void Update()
    {
        // 入力値を取得
        float horizontalInput = Input.GetAxis("Horizontal"); // A/Dキー
        float verticalInput = Input.GetAxisRaw("Vertical"); // W/Sキー

        // 目標速度を計算
        // 強制スクロールの基本速度
        targetX = baseSpeed;

        //時間で速度を管理
        totalPlayTime += Time.deltaTime;
        if(totalPlayTime >= interval){
            baseSpeed +=  speedup;
            boostSpeed += speedup;
            slowspeed += speedup;
            //rbody.linearDamping += 0.5f; //ジャンプ力も下がってる
            totalPlayTime -= interval;
        }

        // Dキーが押されている場合は加速
        if (Input.GetKey(KeyCode.D))
        {
            targetX = boostSpeed;
        }
        // Aキーが押されている場合は減速（後ろには進まない）
        else if (Input.GetKey(KeyCode.A))
        {
            targetX = slowspeed; 
        }
        else
        {
            targetX = baseSpeed;
        }
        
        // Y軸（縦方向）の目標速度
        float targetY = verticalInput * verticalSpeed;

        // 現在の速度を目標速度に徐々に近づける
        targetVelocity = new Vector2(targetX, targetY);
        Vector2 newVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        rb.linearVelocity = newVelocity;

        // キャラクターのY位置を制限
        float clampedY = Mathf.Clamp(transform.position.y, -verticalLimit, verticalLimit);
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}
