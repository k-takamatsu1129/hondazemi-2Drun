using UnityEngine;

public class MainSoundScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {

    }
}
