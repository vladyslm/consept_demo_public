using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BuildingInteractor : MonoBehaviour
{
    [SerializeField] private XRRayInteractor buildInteractor;

    private XRInteractorLineVisual _lineVisual;

    [Header("Controller Actions")] [SerializeField]
    private BlueprintContainer _blueprintContainer;

    private GameObject _socket;

    [SerializeField] private Vector3Reference LastRaycastHit;

    [SerializeField] private GameEvent OnBuild;

    void Awake()
    {
        _lineVisual = buildInteractor.GetComponent<XRInteractorLineVisual>();
        SpawnSocket();
        Instantiate(_blueprintContainer, _socket.transform, true);
    }

    void Update()
    {
        CheckUIHit();
    }

    private void LateUpdate()
    {
        UpdateSocketPosition();
    }

    void OnDisable()
    {
        EnebleLineVisual(false);
    }


    void CheckUIHit()
    {
        buildInteractor.TryGetCurrentUIRaycastResult(out RaycastResult raycastResult);
        EnebleLineVisual(!raycastResult.isValid);
    }

    void EnebleLineVisual(bool value)
    {
        _lineVisual.enabled = value;
    }

    public void OnBuildAction()
    {
        Debug.Log("Build!");
        if (!buildInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            return;
        }

        buildInteractor.TryGetCurrentUIRaycastResult(out RaycastResult raycastResult);
        if (raycastResult.isValid)
        {
            return;
        }

        if (!raycastHit.transform.CompareTag("Ground"))
        {
            return;
        }

        LastRaycastHit.Variable.SetValue(raycastHit.point);
        OnBuild.Raise();
    }

    private void SpawnSocket()
    {
        _socket = new GameObject("_socket");
        _socket.transform.parent = buildInteractor.transform;
    }

    private void UpdateSocketPosition()
    {
        buildInteractor.TryGetCurrentUIRaycastResult(out RaycastResult raycastResult);
        if (raycastResult.isValid)
        {
            _socket.SetActive(false);
            return;
        }

        if (!buildInteractor.TryGetCurrent3DRaycastHit(out var raycastHit))
        {
            _socket.SetActive(false);
            return;
        }

        _socket.SetActive(true);
        _socket.transform.position = raycastHit.point;
        _socket.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}