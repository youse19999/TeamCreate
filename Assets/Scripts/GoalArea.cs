using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField]GameObject targetPlayer;
    [SerializeField] public int point = 0;
    private string playerName;
    private string pointTargetTag;//ここにアイテムtagの名前を書く

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerName = targetPlayer.name;
        //アイテムスクリプトなどを取得
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        //エリアに侵入したアイテムの固有ポイントを取得、その分ポイント加算
        //if(collider.gameObject.tag == "Item"){;}
        //仮実装：アイテムをエリアに置くとポイント加算
        point++;
        if (collider.gameObject == targetPlayer)
        {
            Debug.Log($"{playerName}のポイント:{point}");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //エリアから出たアイテムの固有ポイントを取得、その分ポイント減算

        //仮実装：アイテムをエリアに置くとポイント加算
        point--;
        if (collider.gameObject == targetPlayer)
        {
            Debug.Log($"{playerName}のポイント:{point}");
        }
    }
}
