using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildable/Element")]
public class BuildableSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif


    public GameObject Buildable;
    public Blueprintable Blueprintable;
    public BuildType BuildType;
}
