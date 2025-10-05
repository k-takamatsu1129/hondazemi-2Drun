using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject backgroundPrefab; // 背景プレハブ
    public float scrollSpeed = 2f;
    private Vector3 startPosition;
    private float repeatWidth;

    void Start()
    {
        startPosition = transform.position;
        // 背景画像の幅を取得
        repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 背景が画面外に出たら、最初の位置に戻す
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}