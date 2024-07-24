using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CleanArea : MonoBehaviour
{
    [Header("Environment")] [SerializeField]
    private Vector3Reference areaSize;

    [SerializeField] private Vector3Reference areaPosition;
    private bool isResetValue = true;


    [Header("Blueprint Data")] [SerializeField]
    private BoolReference isBlueprintBuildable;

    [SerializeField] private Vector3Reference lastRaycastHit;
    [SerializeField] private BuildableObjectReference buildableObjectReference;


    [FormerlySerializedAs("onRemoveArea")] [Header("Events")] [SerializeField]
    private UnityEvent onCleanArea;

    private void OnEnable()
    {
        if (isResetValue)
        {
            areaSize.Variable.SetValue(Vector3.zero);
            areaPosition.Variable.SetValue(Vector3.zero);
        }
    }

    public void NotyfiToCleanArea()
    {
        if (!isBlueprintBuildable) return;

        var roundedPosX = Mathf.Round(lastRaycastHit.Value.x);
        var roundedPosZ = Mathf.Round(lastRaycastHit.Value.z);
        var areaPos = new Vector3(roundedPosX, 0, roundedPosZ);

        var objectSize = buildableObjectReference.Value.Blueprintable.GetComponent<ObjectSize>();
        if (objectSize == null) return;

        var areaItemSize = objectSize.Size;

        areaPosition.Variable.SetValue(areaPos);
        areaSize.Variable.SetValue(areaItemSize);

        onCleanArea.Invoke();
    }
}