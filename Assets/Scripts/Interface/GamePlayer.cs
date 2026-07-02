using System.Data.Common;
using UnityEngine;

public class GamePlayer : MonoBehaviour, IPlayer
{
    // モック用アイテム
    [SerializeField] public GameObject item;

    [SerializeField] private Transform head;

    private GameObject headItem;

    public void CreateMove()
    {
        throw new System.NotImplementedException();
    }

    protected Rigidbody GetRigidBody()
    {
        Rigidbody body;
        if (!this.TryGetComponent<Rigidbody>(out body))
        {
            body = this.gameObject.AddComponent<Rigidbody>();
        }
        return body;
    }
    public void Start()
    {
        GetRigidBody();

        // モックアイテムを頭上表示
        ShowItem(item);
    }
    public void ShowItem(GameObject itemPrefab)
    {
        headItem = Instantiate(itemPrefab, head);

        headItem.transform.localPosition = new Vector3(0f, 0.3f, 0f);
        headItem.transform.localRotation = Quaternion.identity;
    }
}