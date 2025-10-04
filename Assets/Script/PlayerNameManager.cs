using UnityEngine;
using UnityEngine.UI;
using TMPro; // Input Field (TMP)を使用する場合

public class PlayerNameManager : MonoBehaviour
{
    // InputFieldコンポーネントをアタッチする変数を宣言
    public InputField nameInputField; // 従来のUI.InputFieldの場合
    // public TMP_InputField nameInputField; // Text Mesh ProのInputFieldの場合

    private string playerName;

    // ゲーム開始時に名前を取得する
    void Start()
    {
        // PlayerPrefsに保存された名前があれば読み込む
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
            // InputFieldに名前を表示する
            // nameInputField.text = playerName;
        }
    }

    // InputFieldの値が変更されたときに呼び出される関数
    public void OnNameChanged(string newName)
    {
        playerName = newName;
    }

    // ゲーム開始ボタンが押されたときに呼び出される関数
    public void StartGame()
    {
        // 名前が入力されていなければ、デフォルト名を設定する
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "名無し";
        }

        // プレイヤー名をPlayerPrefsに保存する
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); // 変更を保存

        Debug.Log("保存された名前: " + playerName);

        // シーンをロードするなど、ゲームを開始する処理をここに追加
        // SceneManager.LoadScene("MainGameScene");
    }
}