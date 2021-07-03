using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupCastEvent", menuName = "ScriptableObjects/PowerupCastEvent", order = 4)]
public class PowerupCastEvent : ScriptableObject
{
    private List<PowerupCastEventListener> listeners = new List<PowerupCastEventListener>();

    public void Raise(KeyCode key)
    {
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].OnEventRaised(key);
        }
    }

    public void RegisterListener(PowerupCastEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(PowerupCastEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
