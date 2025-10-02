using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public GameObject FinishText; // ゲームオーバーテキストを入れる

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Playerにぶつかったら
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        // GameOverテキストを呼び出す
        FinishText.SetActive(true);
        // 2秒後にリスタート
        Invoke("GameRestart", 1);
    }

    public void GameRestart()
    {
        // 現在のシーンを取得してロードする
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
