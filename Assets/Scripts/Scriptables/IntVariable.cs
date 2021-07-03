using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "ScriptableObjects/IntVariable", order = 2)]
public class IntVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public int Value { get; private set; }

    public void SetValue(int value)
    {
        this.Value = value;
    }

    // overload
    public void SetValue(IntVariable value)
    {
        this.Value = value.Value;
    }

    public void ApplyChange(int amount)
    {
        this.Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        this.Value += amount.Value;
    }
}
