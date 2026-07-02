using System.Data.Common;
using NUnit.Framework.Interfaces;
using System.Drawing;
using UnityEngine;

public class GamePlayer : MonoBehaviour, IPlayer
{
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