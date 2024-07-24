using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabletController : MonoBehaviour
{
    [SerializeField] private BuildableObjectVariable SelectedItem;

    [SerializeField] private BuildableSO StartingValue;
    public bool ResetSelectedItem;


    [Header("Events")] [SerializeField] private UnityEvent ItemSelected;

    private void Awake()
    {
        if (ResetSelectedItem)
        {
            SelectedItem.Value = StartingValue;
        }
    }

    public void Notify(BuildableSO blueprint)
    {
        SelectedItem.SetValue(blueprint);
        ItemSelected.Invoke();
    }
}