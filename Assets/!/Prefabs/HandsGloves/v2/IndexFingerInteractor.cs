using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class IndexFingerInteractor : MonoBehaviour
{
    [Header("Data")] [SerializeField] private Vector3Reference m_lastTouch;

    [SerializeField] private XRRayInteractor m_indexFingerInteractor;
    private bool _isEntered = false;

    [Header("Events")] [SerializeField] private UnityEvent TouchEvent;

    private void Start()
    {
        m_lastTouch.Variable.SetValue(Vector3.zero);
    }

    private void Update()
    {
        HandleTabletTouch();
        HandleUITouch();
    }

    private void HandleTabletTouch()
    {
        if (!m_indexFingerInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            _isEntered = false;
            return;
        }

        if (_isEntered) return;

        var cords = raycastHit.textureCoord;

        m_lastTouch.Variable.SetValue(new Vector3(cords.x, cords.y, 0));
        TouchEvent.Invoke();
        _isEntered = true;
    }

    private void HandleUITouch()
    {
        m_indexFingerInteractor.TryGetCurrentUIRaycastResult(out RaycastResult raycastResult);
        if (!raycastResult.isValid) return;

        var button = raycastResult.gameObject.GetComponent<Button>();
        button?.OnSubmit(null);
    }
}