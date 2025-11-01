using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private const string LastPlayTimeKey = "LastPlayTime";

    // ���Q�[���ł͂��̃��\�b�h���X�R�A�v�Z�̌�ɌĂ�
    public void FinishGameWithScoreFromField()
    {
        int score = (int) PlayerPrefs.GetFloat(LastPlayTimeKey); 

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
    }
}