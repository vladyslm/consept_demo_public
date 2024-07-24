using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueprintContainer : MonoBehaviour
{
    protected delegate void CleanContainer();

    [SerializeField] protected BuildableObjectVariable SelectedBlueprint;


    private bool _isCollide = false;

    public bool IsCollide
    {
        get { return _isCollide; }
    }


    protected Blueprintable _target;
    public Blueprintable Target => _target;


    void OnEnable()
    {
        SpawnBlueprint(KillChildren, transform);
    }


    protected void SpawnBlueprint(CleanContainer cleanContainer, Transform parent)
    {
        if (_target != null)
        {
            cleanContainer();
        }


        if (SelectedBlueprint.Value == null) return;
        if (SelectedBlueprint.Value.Blueprintable == null) return;

        _target = Instantiate(SelectedBlueprint.Value.Blueprintable, parent);
    }


    protected virtual void KillChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}