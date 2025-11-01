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
        Debug.Log("�V�[���ύX���Đ�");
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
    }

    void DestroyThis()
    {
        Debug.Log("�I�u�W�F�N�g���폜");
        Destroy(gameObject);
    }
}
