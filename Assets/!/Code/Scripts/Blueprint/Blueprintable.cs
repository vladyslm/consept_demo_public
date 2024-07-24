using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blueprintable : MonoBehaviour
{
    [SerializeField]
    private GameObject _root;

    [SerializeField]
    private BoolReference isBlueprintBuildable;

    [SerializeField]
    private Material valid;

    [SerializeField]
    private Material invalid;


    private MeshRenderer m_MeshRenderer;


    void Awake()
    {
        m_MeshRenderer = _root.GetComponent<MeshRenderer>();
        // m_MeshRenderer.material = valid;
        Blueprint();
        // ValidToBuild();
    }

    private void Blueprint()
    {
        var meshColliders = transform.GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider meshColider in meshColliders)
        {
            meshColider.convex = true;
            meshColider.isTrigger = true;
        }
    }

    private void ValidToBuild()
    {
        isBlueprintBuildable.Variable.SetValue(true);
        m_MeshRenderer.material = valid;
    }

    private void InvalidToBuild()
    {
        isBlueprintBuildable.Variable.SetValue(false);
        m_MeshRenderer.material = invalid;
    }

    void OnEnable() {
        ValidToBuild();    
    }

    void OnTriggerStay(Collider other)
    {
        InvalidToBuild();
    }
    void OnTriggerExit(Collider other)
    {
        ValidToBuild();
    }
}
