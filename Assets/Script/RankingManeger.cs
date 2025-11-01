using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // シーン遷移のため

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI lastScoreText;
    private const string LastPlayTimeKey = "LastPlayTime";
    private const string Lastspeedkey = "Lastspeed";
    private const string SpaceCamerakey = "SpaceCamera";
    private const string Camerakey = "Camera";
    private const string spacespeedkey = "spacespeed";
    private const string jumpkey = "jump";

    void Start()
    {
        // PlayerPrefsから最終プレイ時間を読み込む
        if (PlayerPrefs.HasKey(LastPlayTimeKey))
        {
            float lastPlayTime = PlayerPrefs.GetFloat(LastPlayTimeKey);
            
            int minutes = (int)Mathf.Floor(lastPlayTime / 60);
            int seconds = (int)Mathf.Floor(lastPlayTime % 60);
            lastScoreText.text = string.Format("今回の記録: {0:00}:{1:00}", minutes, seconds);

            // ★★★読み込んだ後にPlayerPrefsをクリア★★★
            PlayerPrefs.DeleteKey(LastPlayTimeKey);
            PlayerPrefs.SetFloat("Lastspeed", 6f);
            PlayerPrefs.SetFloat("Camera", 6f);
            PlayerPrefs.SetFloat("SpaceCamera", 6f);
            PlayerPrefs.SetFloat("spacespeed", 6f);
            PlayerPrefs.SetFloat("jump", 580.0f);
            PlayerPrefs.Save();
        }
        else
        {
            lastScoreText.text = "今回の記録: なし";
        }
    }

    // 例：リトライボタンが押されたときの処理
    // public void OnRetryButton()
    // {
    //     SceneManager.LoadScene("GameScene"); // ゲームシーンに戻る
    // }
}