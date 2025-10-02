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
        rbody = GetComponent<Rigidbody2D>(); //�R���|�[�l���g���擾
    }

    //������boxCollider(�����蔻��)�ɓ������Ƃ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����ing");
        GetComponent<AudioSource>().Play();//AudioSource�̃R���|�[�l���g���擾���APlay���\�b�h�����s����B
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
        rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);//���ړ�
    }
}
