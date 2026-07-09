using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 10.0f;//スポーン感覚
    [SerializeField] private int maxSpawnAmount = 3;//マップ内に存在できるアイテムの数
    private int currentSpawnAmount = 0;
    [SerializeField] BoxCollider spawnArea;
    public List<GameObject> ItemList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ItemSpawn();
    }

    void ItemSpawn()
    {
        if (ItemList == null) { return; }
        if(currentSpawnAmount >= maxSpawnAmount){ return; }


        //ItemList内のスポーンさせるアイテムをランダムに選択
        int randomIndex = Random.Range(0, ItemList.Count-1);

        //スポーン条件
        //等間隔でSpawnAreaのランダムな位置にスポーン
        //if ()
        //{
        //
        //}
        //マップ内のアイテム０ならスポーン
        if(currentSpawnAmount == 0)
        {
           
        }
        //制限時間が一定以下になると10pアイテムのスポーン
        //if(制限時間が一定を下回ったら)
        {
            Instantiate(ItemList[ItemList.Count], spawnArea.transform.position, Quaternion.identity);
        }
    }

}
