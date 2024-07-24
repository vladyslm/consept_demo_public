using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlueprintContainer : BlueprintContainer
{
    public Blueprintable Target => _target;

    void OnEnable()
    {
        SpawnBlueprint(KillChildren, transform.parent);
    }

    protected override void KillChildren()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.name != name)
            {
                Destroy(child.gameObject);
            }
        }
    }
}