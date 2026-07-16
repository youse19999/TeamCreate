using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 10.0f;//スポーン感覚
    [SerializeField] private int maxSpawnAmount = 3;//マップ内に存在できるアイテムの数
    public static int currentSpawnAmount;

    [SerializeField] BoxCollider spawnArea;

    public List<GameObject> ItemList;//ノーマルアイテム
    public List<GameObject> SupecialItemList;//スペシャルアイテム
 
    private float spawnTimer;
    [SerializeField] private float specialItemTime = 30.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ItemSpawn();
        Debug.Log(currentSpawnAmount);
    }

    //スポーンの条件
    void ItemSpawn()
    { 

        //マップ内のアイテム０ならスポーン
        if (currentSpawnAmount == 0)
        {
            SpawnItem();
        }
        //等間隔でSpawnAreaのランダムな位置にスポーン
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnItem();
            spawnTimer = 0.0f;
        }
        //制限時間が一定以下になると10pアイテムのスポーン
        if (spawnTimer <= specialItemTime)
        {
            SpawnItem();
        }
    }

    //スポーン処理
    void SpawnItem()
    {

        //スポーンエリア内のランダムな位置取得
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float y =　bounds.center.y;//Ｙの値は固定
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 randomPosition = new Vector3(randomX, y, randomZ);


        //通常アイテムのスポーン
        if (spawnTimer < specialItemTime)
        {
            if (ItemList == null) { return; }

            int randamItemNumber = Random.Range(0, ItemList.Count);
            Instantiate(ItemList[randamItemNumber], randomPosition, Quaternion.identity);
            //マップ内のアイテム数加算
            currentSpawnAmount++;
        }
        //逆転アイテムのスポーン
        else
        {
            if (SupecialItemList == null) { return; }

            int randamItemNumber = Random.Range(0, SupecialItemList.Count);
            Instantiate(SupecialItemList[randamItemNumber], randomPosition, Quaternion.identity);
            //マップ内のアイテム数加算
            currentSpawnAmount++;
        }
         


    }

}
