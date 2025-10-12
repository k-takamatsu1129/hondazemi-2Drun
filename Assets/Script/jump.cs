using UnityEngine;
using System.Collections.Generic;

public class jump : MonoBehaviour
{
    public float Jump = 580.0f;
    public float val = 30f;
    public float intaval = 10f;
    bool isJump;
    private float totalPlayTime = 0f;
    Rigidbody2D rbody;

    public Sprite walking;
    public Sprite jumping;
    private SpriteRenderer sr;
    public AudioSource jumpSE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPlayTime = 0f;
        rbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        totalPlayTime += Time.deltaTime;
        if(totalPlayTime >= intaval){
            Jump += val;
            totalPlayTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJump)
        {
            rbody.AddForce(new Vector2(0, Jump));
            jumpSE.Play();
            sr.sprite = jumping;
            isJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            sr.sprite = walking;
            isJump = false;
        }
    }
}