using UnityEngine;

public class MainSoundScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă��I�u�W�F�N�g�������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {

    }
}
