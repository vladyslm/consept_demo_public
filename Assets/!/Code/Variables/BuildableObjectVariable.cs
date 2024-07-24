using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/BuildableObject")]
public class BuildableObjectVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public BuildableSO Value;

    public void SetValue(BuildableSO value)
    {
        Value = value;
    }

    public void SetValue(BuildableObjectVariable value)
    {
        Value = value.Value;
    }
}
