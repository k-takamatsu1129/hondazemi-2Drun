using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;

public class GameManeger : MonoBehaviour
{
    public TextMeshProUGUI playTimeText;
    public float totalPlayTime = 0f;
    private const string LastPlayTimeKey = "LastPlayTime";
    private const string PlayTimeKey = "TotalPlayTime";

    [SerializeField] private string game2scene = "game2scene";
    [SerializeField] private string RankingScene = "RankingScene";
    [SerializeField] private string spaceScene = "spaceScene";

    public GameObject FinishText; // ゲームオーバーテキストを入れる

    // シングルトンインスタンス
    public static GameManeger Instance;


    public TextMeshProUGUI guageTimeText;  //ゲージテキストの取得
    public float gauge; //食料ゲージ
    public float gaugetime = 0f;  //食料ゲージの時間
    public float intaval = 2f;  //２秒ごとに食料ゲージを減らす

    private AudioSource audioSource;
    public AudioClip GameOverSound;
    public AudioClip ItemGetSound;
    public AudioClip BadItemGetSound;
    public AudioClip SpaceItemGetSound;

    //食料ゲージ(UI)
    public GameObject GaugeInsideUI;
    float GaugeMax = 10f;

    void Start()
    {
        totalPlayTime = PlayerPrefs.GetFloat(LastPlayTimeKey);

        //時間の開始
        Time.timeScale = 1;

        //効果音のコンポーネント取得
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        //時間の更新
        totalPlayTime += Time.deltaTime;
        gaugetime += Time.deltaTime;

        //関数の遷移
        DisplayTime();
        Displaygauge();

        //食料ゲージの処理
        float remaining = gauge / GaugeMax;
        GaugeInsideUI.GetComponent<Image>().fillAmount = remaining;
    }
    
    private  void DisplayTime()
    {
        int minutes = (int)Mathf.Floor(totalPlayTime / 60);
        int seconds = (int)Mathf.Floor(totalPlayTime % 60);
        playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void Displaygauge(){
        if(gauge > 0){
            if(gaugetime >= intaval){
                gauge -= 1f;
                gaugetime = 0f;
            }
        }
        else if(Time.deltaTime != 0){
            //本来はここを有効化
            Debug.Log("食料ゲージによる終了");
            GameOver();
        }
        guageTimeText.text = gauge.ToString();
    }

    //アイテム入手時の処理:アイテムの画像決定後有効化
    public void item (){
        if(gauge + 3f >= 10f)
        {
            gauge = 10f;
        }
        else
        {
            gauge += 3f;
        }
        audioSource.PlayOneShot(ItemGetSound);
    }

    //デバフアイテムを取った時の関数
    public void difitem (){
        gauge -= 2f;
        audioSource.PlayOneShot(BadItemGetSound);
    }

    //シーンの切り替え関数
    public void changsene(){
        GameObject soundObject;
        //シーンチェンジ
        if (SceneManager.GetActiveScene().name == "game2scene")
        {
            soundObject = GameObject.Find("MainSoundObject");
            if (soundObject != null)
            {
                AudioSource audioSource = soundObject.GetComponent<AudioSource>();
                audioSource.Stop();
            }
            SceneManager.LoadScene(spaceScene);
        }
         else if(SceneManager.GetActiveScene().name == "spaceScene")
         {
            soundObject = GameObject.Find("MainSoundObject");
            if (soundObject != null)
            {
                AudioSource audioSource = soundObject.GetComponent<AudioSource>();
                audioSource.Play();
            }
            SceneManager.LoadScene(game2scene);
         }
            PlayerPrefs.SetFloat("LastPlayTime", totalPlayTime);
            PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Playerにぶつかったら
        {
            GameOver();
        }
    }

    //ゲームオーバー関数
    public void GameOver()
    {
        // GameOverテキストを呼び出す
        FinishText.SetActive(true);

        //時間の停止
        Time.timeScale = 0;
        //時間の保存
        PlayerPrefs.SetFloat("LastPlayTime", totalPlayTime); 
        PlayerPrefs.Save();

        //地上音楽を停止
        GameObject soundObject = GameObject.Find("MainSoundObject");
        if (soundObject != null)
        {
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();
            audioSource.Stop();
            Destroy(soundObject);
        }
        else
        {
            Debug.Log("MainSoundObjectがありません");
        }
        //宇宙音楽を停止
        soundObject = GameObject.Find("SpaceSoundObject");
        if (soundObject != null)
        {
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();
            audioSource.Stop();
        }
        //効果音再生
        audioSource.PlayOneShot(GameOverSound);

        //１秒後に画面遷移
        StartCoroutine(GameOverCoroutine(1f, RankingScene));
    }

    //画面遷移の関数
    private IEnumerator GameOverCoroutine(float delay, string sceneName)
    {
        // 指定した秒数だけ待機する（Time.timeScaleの影響を受けない）
        yield return new WaitForSecondsRealtime(delay);

        // 待機後に実行したい処理
        SceneManager.LoadScene(sceneName);
    }
    // GameManager.cs に追加
    public void ResetGameState()
    {
        gauge = 10f;
        gaugetime = 0f;
        totalPlayTime = 0f;
        Time.timeScale = 1;
        // 必要に応じて、他のゲーム状態もリセット
}
}
