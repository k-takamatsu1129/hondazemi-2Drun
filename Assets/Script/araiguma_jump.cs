using UnityEngine;

public class araiguma_jump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Jump = 350.0f;
    bool isJump;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJump)
        {
            rbody.AddForce(new Vector2(0, Jump));
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
