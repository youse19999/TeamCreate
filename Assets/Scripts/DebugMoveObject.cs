using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
/*
デバッグシーン用の動く床
*/

struct DebugMoveObjectData
{
    public Vector3 pos;
}

// 待機状態
public class UpDownMove : IState<DebugMoveObjectData>
{
    /*
     * 変数初期化
     */
    protected float height;
    protected Vector3 beforePos;
    protected Vector3 targetPos;

    private float time;

    private float speed;
    public UpDownMove(Vector3 _beforePos, float _height, float speed)
    {
        this.beforePos = _beforePos;
        this.height = _height;
        this.speed = speed;
    }
    void IState<DebugMoveObjectData>.Enter()
    {
        this.targetPos = this.beforePos + new Vector3(0, height, 0);
    }

    void IState<DebugMoveObjectData>.Update()
    {
    }

    void IState<DebugMoveObjectData>.Exit()
    {

    }

    bool IState<DebugMoveObjectData>.IsEnd()
    {
        float disntance = Vector3.Distance(Vector3.Lerp(beforePos, targetPos, time), targetPos);
        if (disntance < 0.9f)
        {
            return true;
        }
        return false;
    }


    void IState<DebugMoveObjectData>.GetValue(out DebugMoveObjectData value)
    {
        this.time += Time.deltaTime * speed;
        value.pos = Vector3.Lerp(beforePos, targetPos, time);
    }
}

public class DebugMoveObject : MonoBehaviour
{
    StateMachine<DebugMoveObjectData> stateMachine;
    void Start()
    {
        stateMachine = new StateMachine<DebugMoveObjectData>();
        stateMachine.RegisterState("Up", new UpDownMove (this.transform.position,5,0.1f));
        stateMachine.RegisterState("Down", new UpDownMove(this.transform.position,-5, 0.1f));
        stateMachine.TransitionTo("Down");
        stateMachine.Update();
    }
    void Update()
    {
        DebugMoveObjectData data;
        if (stateMachine.CurrentState.IsEnd())
        {
            stateMachine.TransitionTo("Up");
        }
        stateMachine.Update();
        this.stateMachine.CurrentState.GetValue(out data);
        this.transform.position = data.pos;
    }
}
