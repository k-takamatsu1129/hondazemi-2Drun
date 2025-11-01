using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("For quick testing: a TMP_InputField where you can type a score to finish the game.")]
    public TMP_InputField scoreInputField;

    [Tooltip("Scene name to load when showing ranking (e.g. \"RankingScene\").")]
    public string rankingSceneName = "RankingScene";

    // 実ゲームではこのメソッドをスコア計算の後に呼ぶ
    public void FinishGameWithScoreFromField()
    {
        if (scoreInputField == null)
        {
            Debug.LogError("scoreInputField is not assigned in GameManager.");
            return;
        }

        string s = scoreInputField.text;
        if (!int.TryParse(s, out int score))
        {
            Debug.LogWarning("Score is not a valid integer. Using 0.");
            score = 0;
        }

        SaveAndShowRanking(score);
    }

    public void SaveAndShowRanking(int score)
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        bool success = ScoreManager.SaveScore(playerName, score);
        if (!success)
        {
            Debug.LogError("Failed to save score.");
        }

        SceneManager.LoadScene(rankingSceneName);
    }
}