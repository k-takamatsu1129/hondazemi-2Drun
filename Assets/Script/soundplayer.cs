using UnityEngine;

public class soundplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //������boxCollider(�����蔻��)�ɓ������Ƃ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();//AudioSource�̃R���|�[�l���g���擾���APlay���\�b�h�����s����B
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();//AudioSource�̃R���|�[�l���g���擾���APlay���\�b�h�����s����B
        }
    }
}
