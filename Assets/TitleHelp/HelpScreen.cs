using UnityEngine;
using UnityEngine.InputSystem; // Input Systemを使うために必要

public class HelpScreen : MonoBehaviour
{
    // インスペクターからInput Actions Assetを割り当てるための変数
    [SerializeField] private InputActionAsset inputActionAsset;

    // ヘルプ画面のUIパネル (GameObject) を割り当てるための変数
    [SerializeField] private GameObject helpPanel;

    private InputAction helpAction;

private void Awake()
{
    if (inputActionAsset == null)
    {
        // inputActionAsset自体がInspectorで設定されていない
        Debug.LogError("ERROR: Input Action Assetが設定されていません。Inspectorを確認してください。", this);
        return; 
    }
    
    // ActionMap名とAction名は、実際に設定した名前に合わせてください
    var actionMap = inputActionAsset.FindActionMap("UI");
    if (actionMap == null)
    {
        Debug.LogError("ERROR: Action Map 'UI' が見つかりません。名前を確認してください。", this);
        return;
    }

    helpAction = actionMap.FindAction("ToggleHelp"); 
    
    if (helpAction == null)
    {
        // Hキーに割り当てられたアクションが見つからない
        Debug.LogError("ERROR: Action 'ToggleHelp' が見つかりません。名前を確認してください。", this);
        return;
    }
    
    // 全てOKの場合のみイベントを登録
    helpAction.performed += ctx => ToggleHelpPanel(); 
    
    Debug.Log("HelpScreen: Input Actionの設定とイベント登録が完了しました。");
}

private void OnEnable()
{
    // OnEnable時にアクションを有効化する
    if (helpAction != null)
    {
        helpAction.Enable();
        // ★このログがコンソールに出ているか確認してください
        UnityEngine.Debug.Log("Help ActionをEnableしました。"); 
    }
}

private void OnDisable()
{
    if (helpAction != null)
    {
        helpAction.Disable();
        UnityEngine.Debug.Log("Help ActionをDisableしました。");
    }
}

    // ヘルプパネルの表示・非表示を切り替えるメソッド
private void ToggleHelpPanel()
{
    // Hキーが押されたログ (デバッグ用)
    Debug.Log("Hキーが押されました！"); 

    if (helpPanel != null)
    {

        bool isCurrentlyActive = helpPanel.activeSelf;

        helpPanel.SetActive(!isCurrentlyActive); 
        
        Debug.Log("ヘルプパネルの新しい状態: " + helpPanel.activeSelf);
    }
}
}