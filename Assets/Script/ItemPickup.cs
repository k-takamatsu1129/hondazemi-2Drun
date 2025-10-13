using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーがアイテムに触れたかチェック
        if (other.CompareTag("Player"))
        {
            // アイテムのオブジェクトを破壊して消す
            Destroy(gameObject);
        }
    }
}
