using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBotton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private string Gamescene = "GameScene"; 

    void Update()
    {   
        // Spaceキーが押された瞬間に処理を実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 次のシーンを読み込む
            SceneManager.LoadScene(Gamescene);
            
            // または、Build Settingsのインデックス番号で指定する場合
            // SceneManager.LoadScene(1); 
        }
    
        
    }
}
