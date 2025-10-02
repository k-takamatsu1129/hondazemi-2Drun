using UnityEngine;

public class clow : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 2.0f;
    public float downSpeed = -300.0f;
    private bool down = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //コンポーネントを取得
    }

    //何かがboxCollider(当たり判定)に入ったとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("直撃ing");
        GetComponent<AudioSource>().Play();//AudioSourceのコンポーネントを取得し、Playメソッドを実行する。
    }

    private void Update()
    {
        if (!down)
        {
            rbody.AddForce(transform.up * downSpeed);
            down = true;
        }
        if(transform.position.y < -0.1)
        {
            rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);
        }
    }

    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);//横移動
    }
}
