using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField] GameObject targetPlayer;
    [SerializeField] public int point = 0;
    private string playerName;
    private string pointTargetTag;//ここにアイテムtagの名前を書く

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerName = targetPlayer.name;
        //アイテムスクリプトなどを取得
    }

    private void OnTriggerEnter(Collider collider)
    {
        //エリアに侵入したアイテムの固有ポイントを取得、その分ポイント加算
        //if(collider.gameObject.tag == "Item"){;}
        //仮実装：アイテムをエリアに置くとポイント加算
     
        if (collider.gameObject == targetPlayer)
        {
            //ターゲットプレイヤの所持しているアイテムを取得
            Transform ItemPosition = targetPlayer.transform.Find("ItemPosition");

            //アイテムのポイント加算と手持ちのアイテムデストロイ
            foreach(Transform child in ItemPosition)
            {
                //ItemPositionの子オブジェクト、スクリプトを取得、このPointに加算する
                GameObject Item = child.gameObject;
                ItemScript itemScript = Item.GetComponent<ItemScript>();
                this.point += itemScript.point;
                //加算を終えたらデストロイ
                Destroy(Item);
            }
            //デバッグ
            Debug.Log($"{playerName}のポイント:{point}");
        }
    }
}
