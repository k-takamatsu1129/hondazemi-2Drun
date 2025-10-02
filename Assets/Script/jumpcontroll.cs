using UnityEngine;

public class jumpcontoroll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    int jumpCount;
    public int maxJumpCount;

    // ...

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}