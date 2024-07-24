using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BuildingInputController : MonoBehaviour
{
    [Header("Input Actions")] [SerializeField]
    private InputActionReference m_BuildAction;

    [SerializeField] private InputActionReference m_activateBuilding;
    [SerializeField] private InputActionReference m_RotateAction;

    [Header("Data")] [SerializeField] private BoolReference m_isBuildingModeActive;
    [SerializeField] private GameObjectReference m_activeInteractor;
    [SerializeField] private Vector3Reference m_BlueprintInputRotation;

    [Header("Events")] [SerializeField] private UnityEvent OnPerformBuilding;
    [SerializeField] private UnityEvent OnCancelBuilding;
    [SerializeField] private UnityEvent onBuildEvent;
    [SerializeField] private UnityEvent OnRotateBlueprintEvent;

    private void Start()
    {
        // Disable the Rotation action on Start to prevent from updating rotation while Building is 
        // not active
        DisableRotation();
    }

    private void OnEnable()
    {
        m_BlueprintInputRotation.Variable.SetValue(Vector3.zero);

        var activateBuildingInputAction = GetInputAction(m_activateBuilding);
        if (activateBuildingInputAction == null) return;
        activateBuildingInputAction.performed += OnPerformActivateBuilding;
        activateBuildingInputAction.canceled += OnCancelActivateBuilding;

        activateBuildingInputAction.performed += OnRotateActionEnable;
        activateBuildingInputAction.canceled += OnRotateActionDisable;

        var buildAction = GetInputAction(m_BuildAction);
        if (buildAction == null) return;
        buildAction.started += OnBuild;

        var rotationAction = GetInputAction(m_RotateAction);
        if (rotationAction == null) return;
        rotationAction.performed += OnBlueprintRotation;
        rotationAction.canceled += OnBlueprintRotationCancel;
    }

    private void OnDisable()
    {
        var activateBuildingInputAction = GetInputAction(m_activateBuilding);
        if (activateBuildingInputAction == null) return;
        activateBuildingInputAction.performed -= OnPerformActivateBuilding;
        activateBuildingInputAction.canceled -= OnCancelActivateBuilding;

        activateBuildingInputAction.performed -= OnRotateActionEnable;
        activateBuildingInputAction.canceled -= OnRotateActionDisable;

        var buildAction = GetInputAction(m_BuildAction);
        if (buildAction == null) return;
        buildAction.started -= OnBuild;

        var rotationAction = GetInputAction(m_RotateAction);
        if (rotationAction == null) return;
        rotationAction.performed -= OnBlueprintRotation;
        rotationAction.canceled -= OnBlueprintRotationCancel;
    }

    private void DisableRotation()
    {
        ActionInputReferenceUtil.DisableAction(m_RotateAction);
    }


    // Events
    // Activate Building Event

    private void OnPerformActivateBuilding(InputAction.CallbackContext _)
    {
        if (!m_isBuildingModeActive) return;
        if (m_activeInteractor.Value == null) return;

        OnPerformBuilding?.Invoke();
        m_activeInteractor.Variable.Value.SetActive(m_isBuildingModeActive);
    }

    private void OnCancelActivateBuilding(InputAction.CallbackContext _)
    {
        if (m_activeInteractor.Value == null) return;

        // OnCancelBuilding?.Invoke();
        m_activeInteractor.Variable.Value.SetActive(false);
        OnCancelBuilding?.Invoke();
    }


    // Build Event
    private void OnBuild(InputAction.CallbackContext _)
    {
        onBuildEvent?.Invoke();
    }


    // On Rotate a Blueprint Event
    private void OnBlueprintRotation(InputAction.CallbackContext context)
    {
        var vector = context.ReadValue<Vector2>();
        m_BlueprintInputRotation.Variable.SetValue(new Vector3(vector.x, 0, 0));

        OnRotateBlueprintEvent?.Invoke();
    }

    private void OnBlueprintRotationCancel(InputAction.CallbackContext _)
    {
        m_BlueprintInputRotation.Variable.SetValue(Vector3.zero);
    }

    private void OnRotateActionEnable(InputAction.CallbackContext _)
    {
        ActionInputReferenceUtil.EnableAction(m_RotateAction);
    }

    private void OnRotateActionDisable(InputAction.CallbackContext _)
    {
        ActionInputReferenceUtil.DisableAction(m_RotateAction);
    }

    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}