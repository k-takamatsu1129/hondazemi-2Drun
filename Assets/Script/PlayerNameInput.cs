using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [Tooltip("TextMeshPro Input Field where the player types their name.")]
    public TMP_InputField nameInput;

    [Tooltip("Scene to load after setting name (e.g. \"GameScene\").")]
    public string nextSceneName = "GameScene";

    // Called from a Start button OnClick()
    public void OnStartGame()
    {
        if (nameInput == null)
        {
            Debug.LogError("nameInput is not assigned in PlayerNameInput.");
            return;
        }

        string playerName = nameInput.text?.Trim();
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player"; // �f�t�H���g��
        }

        // �ێ����@�FPlayerPrefs �ɕۑ����ăV�[���ԂŎ󂯓n���i���K�͂ŊȒP�j
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nextSceneName);
    }
}