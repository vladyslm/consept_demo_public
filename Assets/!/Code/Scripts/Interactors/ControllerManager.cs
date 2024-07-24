using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public event Action OnActivateBuildingModeAction;


    public BoolVariable BuildingModeStatus;
    public bool ResetMode;

    [SerializeField] private BuildableObjectReference m_SelectedItem;

    [SerializeField] private GameObjectReference m_activeInteractor;

    [Header("Controller Actions")] [SerializeField]
    private InputActionReference m_BuildingModeActivate;

    [Header("Interactors")] [SerializeField]
    private List<InteractorBuildType> m_InteractorBuildTypeList;


    [Header("Events")] [SerializeField] private UnityEvent BuildModeActivate;

    [SerializeField] private UnityEvent BuildModeDeactivate;


    void Start()
    {
        if (ResetMode)
            BuildingModeStatus.SetValue(false);
    }

    void OnEnable()
    {
        SetupInteractorEvents();
    }

    void OnDisable()
    {
        TeardownInteractorEvents();
    }

    void SetupInteractorEvents()
    {
        var buildingModeActivateAction = GetInputAction(m_BuildingModeActivate);
        if (buildingModeActivateAction != null)
        {
            buildingModeActivateAction.performed += OnActivateBuildingMode;
        }
    }

    void TeardownInteractorEvents()
    {
        var buildingModeActivateAction = GetInputAction(m_BuildingModeActivate);
        if (buildingModeActivateAction != null)
        {
            buildingModeActivateAction.performed -= OnActivateBuildingMode;
        }
    }

    void OnActivateBuildingMode(InputAction.CallbackContext context)
    {
        if (!BuildingModeStatus.Value)
        {
            BuildModeActivate.Invoke();
            BuildingModeStatus.SetValue(true);
            return;
        }

        BuildModeDeactivate.Invoke();
        BuildingModeStatus.SetValue(false);
    }

    public void DeligateSelectedItem()
    {
        var type = m_SelectedItem.Value.BuildType.Value;
        Debug.Log(type);
        foreach (InteractorBuildType InteractorType in m_InteractorBuildTypeList)
        {
            if (InteractorType.Type.Value == type)
            {
                m_activeInteractor.Variable.SetValue(InteractorType.gameObject);
            }
        }

        Debug.Log("blueprint");
    }

    public void SetSelectedItemToDefault()
    {
        m_SelectedItem.Variable.SetValue(m_SelectedItem.ConstantValue);
    }


    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}