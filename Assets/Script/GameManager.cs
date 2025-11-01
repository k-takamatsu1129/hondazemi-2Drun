using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private const string PlayTimeKey = "TotalPlayTime";

    // ���Q�[���ł͂��̃��\�b�h���X�R�A�v�Z�̌�ɌĂ�
    public void FinishGameWithScoreFromField()
    {
        float score = PlayerPrefs.GetFloat(PlayTimeKey);

        SaveAndShowRanking(score);
    }

    public void SaveAndShowRanking(float score)
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        bool success = ScoreManager.SaveScore(playerName, score);
        if (!success)
        {
            Debug.LogError("Failed to save score.");
        }
    }
}