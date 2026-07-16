using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int point;//1,2,3,10
    GamePlayer gamePlayer;

    private void OnTriggerEnter(Collider col)
    {
        //すでにアイテムを所持しているなら処理しない　: 未実装

        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            ItemSpawnManager.currentSpawnAmount--;
        }
    }
}
