using UnityEngine;

public class soundplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //何かがboxCollider(当たり判定)に入ったとき

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            //効果音再生
            GetComponent<AudioSource>().Play();//AudioSourceのコンポーネントを取得し、Playメソッドを実行する。
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            //効果音再生
            GetComponent<AudioSource>().Play();
        }
    }
}
