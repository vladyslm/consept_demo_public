using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildType : ScriptableObject
{
    [Tooltip("Buold type")]
    [SerializeField]
    private string m_Value = "";

    public string Value
    {
        get { return m_Value; }
    }

}
