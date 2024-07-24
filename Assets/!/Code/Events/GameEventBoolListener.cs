using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventBoolListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventBool Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<bool> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(bool value)
    {
        Response?.Invoke(value);
    }
}
