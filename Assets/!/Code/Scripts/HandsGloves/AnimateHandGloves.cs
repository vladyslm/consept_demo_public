using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandGloves : MonoBehaviour
{
    [SerializeField] private InputActionReference m_gripInputActionReference;
    [SerializeField] private Animator m_handAnimator;

    private void OnEnable()
    {
        var gripInputAction = GetInputAction(m_gripInputActionReference);
        if (gripInputAction == null) return;
        gripInputAction.performed += OnPerformGrip;
        gripInputAction.canceled += OnCancelGrip;
    }

    private void OnDisable()
    {
        var gripInputAction = GetInputAction(m_gripInputActionReference);
        if (gripInputAction == null) return;
        gripInputAction.performed -= OnPerformGrip;
        gripInputAction.canceled -= OnCancelGrip;
    }

    public void OnPokeEventEnter()
    {
        m_handAnimator.SetBool("isPoking", true);
    }

    public void OnPokeEventExit()
    {
        m_handAnimator.SetBool("isPoking", false);
    }

    void OnPerformGrip(InputAction.CallbackContext context)
    {
        m_handAnimator.SetFloat("Grip", context.ReadValue<float>());
    }

    void OnCancelGrip(InputAction.CallbackContext context)
    {
        m_handAnimator.SetFloat("Grip", 0);
    }

    static InputAction GetInputAction(InputActionReference actionReference)
    {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}