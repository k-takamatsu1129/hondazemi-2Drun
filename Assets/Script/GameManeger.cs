using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;

public class GameManeger : MonoBehaviour
{
    public TextMeshProUGUI playTimeText;
    private float totalPlayTime = 0f;
    private const string LastPlayTimeKey = "LastPlayTime";
    private const string PlayTimeKey = "TotalPlayTime";
    [SerializeField] private string RankingScene = "RankingScene";
    public GameObject FinishText; // ゲームオーバーテキストを入れる
    

    void Start()
    {

        //時間を初期化
        totalPlayTime = 0f;
        //時間の開始
        Time.timeScale = 1;
    }

    void Update()
    {
        totalPlayTime += Time.deltaTime;
        DisplayTime();
    }
    
    private void DisplayTime()
    {
        int minutes = (int)Mathf.Floor(totalPlayTime / 60);
        int seconds = (int)Mathf.Floor(totalPlayTime % 60);
        playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

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

        //時間の停止
        Time.timeScale = 0;
        //時間の保存
        PlayerPrefs.SetFloat("LastPlayTime", totalPlayTime); 
        PlayerPrefs.Save();

        //１秒後に画面遷移
        StartCoroutine(GameOverCoroutine(1f, RankingScene));
    }

    private IEnumerator GameOverCoroutine(float delay, string sceneName)
    {
        // 指定した秒数だけ待機する（Time.timeScaleの影響を受けない）
        yield return new WaitForSecondsRealtime(delay);

        // 待機後に実行したい処理
        SceneManager.LoadScene(sceneName);
    }
}
