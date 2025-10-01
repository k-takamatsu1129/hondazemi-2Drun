using UnityEngine;

public class crouch : MonoBehaviour
{
    private BoxCollider2D col;
    private Vector2 defaultSize;

    private bool isCrouching = false; //しゃがみ中に真

    public Sprite walkSprite;
    public Sprite crouchSprite;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<BoxCollider2D>(); //キャラクターの当たり判定を取得
        defaultSize = col.size; //当たり判定の大きさを代入

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //画像を変更　しゃがむ
            sr.sprite = crouchSprite;
            isCrouching = true;

            //当たり判定を変更
            col.size = new Vector2(defaultSize.x, defaultSize.y * 0.5f); //当たり判定をデフォルトの半分に変更
        }
        else if (isCrouching)
        {
            //画像を変更　走る
            sr.sprite = walkSprite;
            isCrouching = true;

            //当たり判定を変更
            col.size = new Vector2(defaultSize.x, defaultSize.y); //当たり判定をデフォルトに設定
        }
    }
}
