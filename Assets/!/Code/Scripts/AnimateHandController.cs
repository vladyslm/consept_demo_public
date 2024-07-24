using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandController : MonoBehaviour
{
    [SerializeField] private InputActionReference m_gripInputActionReference;

    [SerializeField] private Animator _handAnimator;

    private float _gripValue;


    void OnEnable()
    {
        var gripInputAction = GetInputAction(m_gripInputActionReference);
        if (gripInputAction != null)
        {
            gripInputAction.performed += OnPerformSelect;
        }
    }

    void OnPerformSelect(InputAction.CallbackContext context)
    {
        _handAnimator.SetFloat("Grip", context.ReadValue<float>());
    }

    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}