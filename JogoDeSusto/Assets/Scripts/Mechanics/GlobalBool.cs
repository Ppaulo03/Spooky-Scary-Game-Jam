using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalBool", menuName = "ScriptableObject/GlobalBool", order = 0)]
public class GlobalBool : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private bool initialValue = false;
    [System.NonSerialized] public bool Value;

    public void OnBeforeSerialize(){}
    public void OnAfterDeserialize()
    {
        Value = initialValue;
    }
}
