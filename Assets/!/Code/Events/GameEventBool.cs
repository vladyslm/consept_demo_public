using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventBool : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>

    private readonly List<GameEventBoolListener> eventListeners =
    new();

    public void Raise(bool value)
    {
        for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
    }

    public void RegisterListener(GameEventBoolListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventBoolListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
