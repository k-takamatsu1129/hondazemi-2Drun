using UnityEngine;
using TMPro;
using System.Text;
using System.Collections.Generic;

public class RankingManager2 : MonoBehaviour
{
    [Tooltip("TextMeshProUGUI where the ranking will be displayed.")]
    public TMP_Text rankingText;

    [Tooltip("How many top entries to show (e.g. 10).")]
    public int topN = 10;

    void Start()
    {
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
        sb.AppendLine("RANK  NAME        SCORE");
        sb.AppendLine("------------------------");

        int count = Mathf.Min(topN, entries.Count);
        for (int i = 0; i < count; i++)
        {
            var e = entries[i];
            // 固定長フォーマット（簡易）
            sb.AppendFormat("{0,2}.   {1,-10}  {2,5}\n", i + 1, e.name, e.score);
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
        ScoreManager.ClearScores();
        ShowRanking();
    }
}