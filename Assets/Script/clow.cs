using UnityEngine;

public class clow : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 2.0f;
    public float downSpeed = -600.0f;
    private bool down = false;

    private float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //コンポーネントを取得
    }

    private void Update()
    {
        if (!down)
        {
            rbody.AddForce(transform.up * downSpeed);
            down = true;
        }
        if(transform.position.y < -0.2)
        {
            rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);
        }

        time += Time.deltaTime;
        if (time > 5)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);//横移動
    }
}
