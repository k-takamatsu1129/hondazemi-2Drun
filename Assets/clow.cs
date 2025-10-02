using UnityEngine;

public class clow : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 100.0f;

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

    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(speed, 0);
    }
}
