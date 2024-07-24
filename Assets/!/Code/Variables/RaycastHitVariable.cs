using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/RaycastHit")]
public class RaycastHitVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public RaycastHit Value;

    public void SetValue(RaycastHit value)
    {
        Value = value;
    }

    public void SetValue(RaycastHitVariable value)
    {
        Value = value.Value;
    }
}
