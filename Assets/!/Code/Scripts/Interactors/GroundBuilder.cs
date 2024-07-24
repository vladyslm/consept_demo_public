using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBuilder : Builder
{
    public override void Build()
    {
        if (!IsBlueprintBuildable) return;
        var rounderPosX = Mathf.Round(LastRaycastHit.Value.x);
        var rounderPosZ = Mathf.Round(LastRaycastHit.Value.z);
        var vectorPos = new Vector3(rounderPosX, 0, rounderPosZ);

        Instantiate(BuildableReference.Value.Buildable, vectorPos, Quaternion.identity);
    }
}