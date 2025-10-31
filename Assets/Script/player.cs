using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManeger gamemaneger;  // ゲームマネージャーへの参照

    private Renderer myRenderer;
    private bool hasLeftScreen = false;
    public Camera mainCamera; // カメラ情報取得

    void Start()
    {
        // GameManagerを探して参照を取得
        if (gamemaneger == null)
        {
            gamemaneger = FindObjectOfType<GameManeger>();
        }

        // 画面外判定のためにRendererと画面端の座標を取得
        myRenderer = GetComponent<Renderer>();
        if (myRenderer == null)
        {
            Debug.LogError("Rendererコンポーネントがアタッチされていません。");
            return;
        }

        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("メインカメラが見つかりません。");
            return;
        }
    }

    void Update()
    {
        // 画面の幅と高さを取得
        float screenLeftBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRightBoundary = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float screenBottomBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float screenTopBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // 画面外に出ていない場合のみ判定
        if (!hasLeftScreen)
        {
            // レンダラーがある場合のみ判定
            if (myRenderer != null)
            {
                float objectWidth = myRenderer.bounds.size.x;
                float objectHeight = myRenderer.bounds.size.y;

                // 左右の判定
                bool isOutsideHorizontal = transform.position.x + objectWidth / 2 < screenLeftBoundary || transform.position.x - objectWidth / 2 > screenRightBoundary;

                // 上下の判定
                bool isOutsideVertical = transform.position.y + objectHeight / 2 < screenBottomBoundary || transform.position.y - objectHeight / 2 > screenTopBoundary;

                if (isOutsideHorizontal || isOutsideVertical)
                {
                    hasLeftScreen = true;
                    if (gamemaneger != null)
                    {
                        Debug.Log("画面外による終了");
                        gamemaneger.GameOver(); // ゲームオーバー処理を呼び出す
                    }
                }
            }  
        }
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "enemy"タグのオブジェクトに衝突したらゲームオーバー
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("衝突によるゲームオーバー");
            if (gamemaneger != null)
            {
                gamemaneger.GameOver();
            }
            //プレイヤー消すのもありかなー
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //アイテム入手時の処理
        if (collision.gameObject.CompareTag("item"))
        {
            Debug.Log("アイテムを入手");
            if (gamemaneger != null)
            {
                gamemaneger.item();
            }
        }
        
        if (collision.gameObject.CompareTag("item1"))
        {
            Debug.Log("アイテムを入手");
            if (gamemaneger != null)
            {
                gamemaneger.difitem();
            }
        }

        if(collision.gameObject.CompareTag("item2"))
        {
            gamemaneger.changsene();
        }

        //敵と接触した時の処理
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("衝突によるゲームオーバー");
            if (gamemaneger != null)
            {
                gamemaneger.GameOver();
            }
        }
    }
}
