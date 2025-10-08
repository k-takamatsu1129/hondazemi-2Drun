using UnityEngine;

public class CreateRandomPositions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject createPrefab;//生成するGameObject
    public Transform rangeA;//生成する範囲A
    public Transform rangeB;//生成する範囲B

    public float spped = 5.0f;

    // 経過時間
    private float time;
    int rnd = Random.Range(1, 10);

    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;
        rnd = Random.Range(1, 500);
        //if (time > 1.0f) // 約1秒置きにランダムに生成されるようにする。
        if (rnd <= 1)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);
            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            // 経過時間リセット
            time = 0f;
        }
    }
}
