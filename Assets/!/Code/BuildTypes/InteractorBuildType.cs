using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorBuildType : MonoBehaviour
{
    [SerializeField]
    private BuildType _buildType;

    public BuildType Type{
        get{ return _buildType; }
    }

}
