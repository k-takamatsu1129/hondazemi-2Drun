using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inputName : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;

    void Start()
    {
        //Component��������悤�ɂ���
        inputField = inputField.GetComponent<TMP_InputField>();
        text = text.GetComponent<TextMeshProUGUI>();

    }
    public void InputText()
    {
        //�e�L�X�g��inputField�̓��e��\��
        text.text = inputField.text;
    }

    public void GetInputName()
    {
        //InputField����e�L�X�g�����擾����
        string name = inputField.text;
        Debug.Log(name);

        //���̓t�H�[���̃e�L�X�g����ɂ���
        inputField.text = "";
    }
}
