using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName ="CanvasParamwter", menuName="ScriptableObjects/CanvasParameter", order=1)]
public class CanvasScriptableObject : ScriptableObject
{
    [SerializeField] 
    public float TimeLimit;

    [SerializeField]
    public float TitleMoveSpeed;
}