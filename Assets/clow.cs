using UnityEngine;

public class clow : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 100.0f;

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

    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(speed, 0);
    }
}
