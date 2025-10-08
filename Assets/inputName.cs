using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inputName : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;

    void Start()
    {
        //Componentを扱えるようにする
        inputField = inputField.GetComponent<TMP_InputField>();
        text = text.GetComponent<TextMeshProUGUI>();

    }
    public void InputText()
    {
        //テキストにinputFieldの内容を表示
        text.text = inputField.text;
    }

    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        string name = inputField.text;
        Debug.Log(name);

        //入力フォームのテキストを空にする
        inputField.text = "";
    }
}
