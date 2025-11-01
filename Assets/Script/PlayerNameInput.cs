using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [Tooltip("TextMeshPro Input Field where the player types their name.")]
    public TMP_InputField nameInput;

    [Tooltip("Scene to load after setting name (e.g. \"game2scene\").")]
    public string nextSceneName = "game2scene";

    // 毎フレーム呼ばれるメソッド
    void Update()
    {
        // 1. nameInputがnullでないことを確認
        if (nameInput == null) return;

        // 2. 現在、インプットフィールドが選択（フォーカス）されているか確認
        if (nameInput.isFocused)
        {
            // 3. スペースキーが押された瞬間を検知
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ゲーム開始処理を呼び出す
                OnStartGame();
            }
        }
    }

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
            playerName = "Player"; // デフォルト値
        }

        // 保存処理
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        // 次のシーンへ遷移する行をコメントアウトから戻す
        SceneManager.LoadScene(nextSceneName);
    }
}
