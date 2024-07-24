using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportInputController : MonoBehaviour
{
    [Header("Input Actions")] [SerializeField]
    private InputActionReference activateTeleportAction;

    [Header("Interactor")] [SerializeField]
    private GameObject teleportInteractor;
    

    private bool _isTeleportActive = false;

    private void OnEnable()
    {
        var action = GetInputAction(activateTeleportAction);
        if (action == null) return;
        action.started += OnAction;
    }

    private void OnDisable()
    {
        var action = GetInputAction(activateTeleportAction);
        if (action == null) return;
        action.started -= OnAction;
    }

    private void OnAction(InputAction.CallbackContext _)
    {
        if (!_isTeleportActive)
        {
            ToggleOnTeleport();
            return;
        }

        ToggleOffTeleport();
    }

    private void ToggleOnTeleport()
    {
        _isTeleportActive = true;
        teleportInteractor.SetActive(_isTeleportActive);
    }

    private void ToggleOffTeleport()
    {
        _isTeleportActive = false;
        teleportInteractor.SetActive(_isTeleportActive);
    }

    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}