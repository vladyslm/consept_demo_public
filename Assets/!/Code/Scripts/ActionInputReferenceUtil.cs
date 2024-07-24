using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class ActionInputReferenceUtil
{
    public static void EnableAction(InputActionReference actionReference)
    {
        var action = GetInputAction(actionReference);
        if (action != null && !action.enabled)
            action.Enable();
    }

    public static void DisableAction(InputActionReference actionReference)
    {
        var action = GetInputAction(actionReference);
        if (action != null && action.enabled)
            action.Disable();
    }

    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}