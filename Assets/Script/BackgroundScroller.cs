using UnityEngine;
using System.Collections.Generic;

public class BackgroundScroller : MonoBehaviour
{
    // 背景パーツのプレハブを格納する配列
    public GameObject[] backgroundPrefabs;
    // 背景パーツの横幅（インスペクターで設定）
    public float backgroundWidth = 20f;
    // カメラのTransform
    public Transform cameraTransform;

    // 現在画面に表示されている背景パーツのリスト
    private List<GameObject> activeBackgrounds = new List<GameObject>();
    // 次の背景を生成するX座標の閾値
    private float nextSpawnX;

    void Start()
    {
        // カメラのTransformが設定されていない場合、メインカメラを探す
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // 初期背景をいくつか生成
        for (int i = 0; i < 3; i++)
        {
            SpawnBackground();
        }
    }

    void Update()
    {
        // カメラが次の生成位置を超えたら新しい背景を生成
        if (cameraTransform.position.x > nextSpawnX - backgroundWidth * 2)
        {
            SpawnBackground();
            DeleteOldBackground();
        }
    }

    // 新しい背景を生成するメソッド
    void SpawnBackground()
    {
        // ランダムな背景パーツを選択
        int prefabIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject newBackground = Instantiate(backgroundPrefabs[prefabIndex], new Vector3(nextSpawnX, 3, 0), Quaternion.identity);
        activeBackgrounds.Add(newBackground);
        nextSpawnX += backgroundWidth -2.159f ;
    }

    // 画面外に出た背景を消去するメソッド
    void DeleteOldBackground()
    {
        if (activeBackgrounds.Count > 0)
        {
            // 最初の背景パーツがカメラの範囲外（左側）に出たかチェック
            if (activeBackgrounds[0].transform.position.x < cameraTransform.position.x - backgroundWidth * 2)
            {
                Destroy(activeBackgrounds[0]);
                activeBackgrounds.RemoveAt(0);
            }
        }
    }
}