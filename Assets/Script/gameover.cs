using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameManeger gamemaneger;  // ← クラスの中、メソッドの外に置く

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))  // ← CompareTag 推奨
        {
            Debug.Log("Game Over");
            gamemaneger.GameOver(); // GameManeger のメソッドを呼び出す
        }
    }
}
