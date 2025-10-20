using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public GameObject GaugeInsideUI;
    float GaugeMax = 10f;
    float GaugeRemain = 10f;

    GameManeger gameManeger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //食料ゲージ
        GaugeRemain = gameManeger.gauge; //ゲージ残量を取得
        float remaining = GaugeRemain / GaugeMax;
        GaugeInsideUI.GetComponent<Image>().fillAmount = remaining;
    }
}
