using UnityEngine;

public class CatWalking : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite walk1;
    public Sprite walk2;
    private SpriteRenderer sr;
    jump Jump;
    crouch Crouch;
    //private float time = 0f;
    public float switchInterval = 0.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Jump = GetComponent<jump>();
        Crouch = GetComponent<crouch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Jump.isJump && !Crouch.isCrouching)
         {
            int step = (int)(Time.time/switchInterval);

            if(step % 2 == 0)
            {
                //Debug.Log("walk1");
                sr.sprite = walk1;
            }else if (step % 2 != 0)
            {
                //Debug.Log("walk2");
                sr.sprite = walk2;
            }
        }
    }
}
