using UnityEngine;
using System.Collections.Generic;

public class jump : MonoBehaviour
{
    public float Jump = 350.0f;
    bool isJump;
    Rigidbody2D rbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
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