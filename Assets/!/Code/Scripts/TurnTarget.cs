using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class TurnTarget : MonoBehaviour
{
    [SerializeField] private BlueprintContainer m_container;
    [SerializeField] private Vector3Reference m_RotationLerp;
    [SerializeField] private Vector3Reference m_TargetRotation;

    void FixedUpdate()
    {
        var lerpVector = m_RotationLerp.Variable.Value;
        if (lerpVector.x == 0) return;


        var angle = Mathf.Lerp(20, 200, Mathf.Abs(lerpVector.x));

        var rotationDirection = lerpVector.x > 0 ? Vector3.down : Vector3.up;

        m_container.Target.transform.RotateAround(m_container.transform.position, rotationDirection,
            angle * Time.fixedDeltaTime);

        m_TargetRotation.Variable.SetValue(m_container.Target.transform.rotation.eulerAngles);
    }
}