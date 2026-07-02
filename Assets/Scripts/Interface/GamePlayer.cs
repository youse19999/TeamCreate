=======
using System.Data.Common;
>>>>>>> main
using NUnit.Framework.Interfaces;
using System.Drawing;
using UnityEngine;

public class GamePlayer : MonoBehaviour, IPlayer
{

    private Vector3 point;

    private MeshFilter itemFilter;
    public void CreateMove()
    {

    }

}
public void Start()
{
    GetRigidBody();
    itemFilter.mesh = GameStructure.GetInstance().playerStructure.Item.mesh;
}
public void Update()
{
    RaycastHit hit;
    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
    {
        point = hit.point;
        if (Vector2.Distance(point, this.transform.position) < GameStructure.GetInstance().playerStructure.deadzone)
        {
            GetRigidBody().linearVelocity = Vector3.zero;
            return;
        }
        if (hit.collider.gameObject == this.gameObject)
        {
            GetRigidBody().linearVelocity = Vector3.zero;
            return;
        }
        this.transform.rotation = Quaternion.LookRotation(point - this.transform.position, this.transform.forward);
        //ツイスト
        Quaternion refQ = this.transform.rotation;
        Vector3 qVector = new Vector3(refQ.x, refQ.y, refQ.z);
        //yのみ
        Vector3 projection = Vector3.Project(qVector, Vector3.up);
        //クオータニオン
        Quaternion q = new Quaternion(projection.x, projection.y, projection.z, this.transform.rotation.w);
        //符号
        float dot = Quaternion.Dot(q, refQ);
        if (dot > 0.0f)
        {
            this.transform.rotation = q;
        }
        else
        {
            this.transform.rotation = Quaternion.Inverse(q);
        }
        //Yのaxisの入力
        float verticalInput = Input.GetAxis("Vertical");
        //使うスピード（input依存)
        float maxSpeed = GameStructure.GetInstance().playerStructure.speed * verticalInput;
        //ベロシティー
        Vector3 velocity = GetRigidBody().linearVelocity + (this.transform.forward * maxSpeed);
        //クランプ（ここでyもクランプされる）
        Vector3 clampedVelocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        //yをの要素を復元
        clampedVelocity.y = velocity.y;
        //最終的なクランプ済みのlinearVelocityをセット
        GetRigidBody().linearVelocity = clampedVelocity;
    }
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
}
}
=======
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
    }
}
>>>>>>> main
