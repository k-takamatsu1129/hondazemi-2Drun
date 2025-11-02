using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceSoundManager : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    private AudioSource audioSource;
    public AudioClip audioClip;
    private bool isSpace = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        isSpace = false;
}

    // Update is called once per frame
    void Update()
    {
        SceneChangeSE();
    }

    void SceneChangeSE()
    {
        Debug.Log("シーン変更音再生");
        if (SceneManager.GetActiveScene().name == "game2scene" && isSpace)
        {
            audioSource.PlayOneShot(audioClip);
            isSpace = false;
            Invoke(nameof(DestroyThis), 3.0f);
        }
        else if (SceneManager.GetActiveScene().name == "spaceScene" && !isSpace)
        {
            audioSource.PlayOneShot(audioClip);
            isSpace = true;
        }
        else if(SceneManager.GetActiveScene().name == "RankingScene")
        {
            isSpace = false;
            DestroyThis();
        }
    }

    void DestroyThis()
    {
        Debug.Log("オブジェクトを削除");
        Destroy(gameObject);
    }
}
