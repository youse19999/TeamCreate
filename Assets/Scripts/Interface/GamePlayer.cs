using System;
using UnityEngine;

public class GamePlayer : MonoBehaviour, IPlayer
{
    [SerializeField] public Camera gameCamera;
    // モック用アイテム
    [SerializeField] public GameObject item;

    [SerializeField] private Transform head;
    [SerializeField]  private float rotation;

    private GameObject headItem;

    public void CreateMove()
    {
        throw new System.NotImplementedException();
    }
    private Vector3 point;
    private Vector3 beforePoint;

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
    }
    public void ShowItem(GameObject itemPrefab)
    {
        headItem = Instantiate(itemPrefab, head);

        headItem.transform.localPosition = new Vector3(0f, 0.3f, 0f);
        headItem.transform.localRotation = Quaternion.identity;
        //itemFilter.mesh = GameStructure.GetInstance().playerStructure.Item.mesh;
    }

    public void Update()
    {
        RaycastHit hit;

        float horizonInput = Input.GetAxis("Horizontal");
        rotation += horizonInput * GameStructure.GetInstance().playerStructure.rotateSpeed;
        point = this.transform.position + new Vector3(Mathf.Cos(rotation), 0, Mathf.Sin(rotation)) * 2;
        //this.transform.rotation = ;
        //ツイスト
        Quaternion refQ = Quaternion.LookRotation(point - this.transform.position, this.transform.forward);
        Vector3 qVector = new Vector3(refQ.x, refQ.y, refQ.z);
        //yのみ
        Vector3 projection = Vector3.Project(qVector, Vector3.up);
        //クオータニオン
        Quaternion q = new Quaternion(projection.x, projection.y, projection.z, refQ.w);
        //符号
        float dot = Quaternion.Dot(q, refQ);
        if ((beforePoint-point).magnitude < 0.1f)
        {
            if (dot > 0.0f)
            {
                this.transform.rotation = q;
            }
            else
            {
                this.transform.rotation = Quaternion.Inverse(q);
            }
        }
        //Yのaxisの入力
        float verticalInput = Input.GetAxis("Vertical");
        //使うスピード（input依存)
        float maxSpeed = (GameStructure.GetInstance().playerStructure.speed* (verticalInput*1)) * verticalInput;
        //ベロシティー
        Vector3 velocity = GetRigidBody().linearVelocity + (this.transform.forward * verticalInput * maxSpeed);
        //クランプ（ここでyもクランプされる）
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            // 3. 実際の長さを平方根（ルート）で求める
            float magnitude = (float)Math.Sqrt(velocity.sqrMagnitude);

            // 4. 正規化しつつ、最大値を掛けて新しいベクトルを生成する
            velocity = velocity / magnitude * maxSpeed;
        }
        Vector3 clampedVelocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        //yをの要素を復元
        clampedVelocity.y = velocity.y;
        //最終的なクランプ済みのlinearVelocityをセット
        GetRigidBody().linearVelocity = clampedVelocity;
        beforePoint = point;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point, 0.1f);
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.right);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.up);

        Gizmos.DrawWireSphere(point, 1.0f);
    }
}