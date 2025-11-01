using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // シーン遷移のため
using System.Text;
using System.Collections.Generic;

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI lastScoreText;
    private const string LastPlayTimeKey = "LastPlayTime";
    private const string Lastspeedkey = "Lastspeed";
    private const string SpaceCamerakey = "SpaceCamera";
    private const string Camerakey = "Camera";
    private const string spacespeedkey = "spacespeed";
    private const string jumpkey = "jump";

    [Tooltip("TextMeshProUGUI where the ranking will be displayed.")]
    public TMP_Text rankingText;

    [Tooltip("How many top entries to show (e.g. 10).")]
    public int topN = 5;

    void Start()
    {
        if (PlayerPrefs.HasKey(LastPlayTimeKey))
        {
            float lastPlayTime = PlayerPrefs.GetFloat(LastPlayTimeKey);
            
            // int minutes = (int)Mathf.Floor(lastPlayTime / 60);
            // int seconds = (int)Mathf.Floor(lastPlayTime % 60);
            // lastScoreText.text = string.Format("今回の記録: {0:00}:{1:00}", minutes, seconds);

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
            // lastScoreText.text = "今回の記録: なし";
        }

        if (rankingText == null)
        {
            Debug.LogError("rankingText is not assigned in RankingManager.");
            return;
        }
        ShowRanking();
    }

    public void ShowRanking()
    {
        List<ScoreEntry> entries = ScoreManager.ReadScores();

        var sb = new StringBuilder();

        int count = Mathf.Min(topN, entries.Count);
        for (int i = 0; i < count; i++)
        {
            var e = entries[i];
            // 固定長フォーマット（簡易）
            sb.AppendFormat("{0,2}   {1,-10}  {2,4}\n", "", e.name, e.score);
        }

        if (entries.Count == 0)
        {
            sb.AppendLine("No scores yet.");
        }

        rankingText.text = sb.ToString();
    }

    // UI のボタンに繋いで使用
    public void ClearAllScores()
    {
        // if (Input.GetKeyDown(KeyCode.RightShift))
        // {
        //     ScoreManager.ClearScores();
        //     ShowRanking();
        // }
        ScoreManager.ClearScores();
        ShowRanking();
    }
}