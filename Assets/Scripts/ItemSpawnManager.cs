using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 10.0f;//スポーン感覚
    [SerializeField] private int maxSpawnAmount = 3;//マップ内に存在できるアイテムの数
    public static int currentSpawnAmount = 0;
    [SerializeField] BoxCollider spawnArea;
    public List<GameObject> ItemList;//ノーマルアイテム
    public List<GameObject> SupecialItemList;//スペシャルアイテム

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ItemSpawn();
    }

    //スポーンの条件
    void ItemSpawn()
    {
        if (ItemList == null) { return; }
        if(currentSpawnAmount >= maxSpawnAmount){ return; }


        //ItemList内のスポーンさせるアイテムをランダムに選択
        int randomIndex = Random.Range(0, ItemList.Count-1);

        //スポーン条件
        //等間隔でSpawnAreaのランダムな位置にスポーン
 
        //マップ内のアイテム０ならスポーン
        if(currentSpawnAmount == 0)
        {
            SpawnItem();
        }
        //制限時間が一定以下になると10pアイテムのスポーン
        //if(制限時間が一定を下回ったら)
        {
            Instantiate(ItemList[ItemList.Count], spawnArea.transform.position, Quaternion.identity);
        }
    }

    //スポーン処理
    void SpawnItem()
    {
        //スポーンエリア内のランダムな位置取得
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        //アイテムのスポーン
        int randamItemNumber = Random.Range(0, ItemList.Count - 2);
        Instantiate(ItemList[randamItemNumber], randomPosition, Quaternion.identity);
    }

}
