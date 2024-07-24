using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private BoolReference isBlueprintBuildable;

    protected BoolReference IsBlueprintBuildable => isBlueprintBuildable;

    [SerializeField] private Vector3Reference lastRaycastHit;

    protected Vector3Reference LastRaycastHit => lastRaycastHit;

    [SerializeField] private BuildableObjectReference BuildableObjectReference;

    protected BuildableObjectReference BuildableReference => BuildableObjectReference;

    [SerializeField] private bool restartValue = true;

    [SerializeField] private Vector3Reference blueprintRotation;

    void Awake()
    {
        if (restartValue)
            isBlueprintBuildable.Variable.SetValue(false);
    }

    public virtual void Build()
    {
        if (isBlueprintBuildable)
            Instantiate(
                BuildableObjectReference.Value.Buildable,
                lastRaycastHit,
                Quaternion.Euler(blueprintRotation)
            );
    }
}