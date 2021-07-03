using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomPowerupCastEvent : UnityEvent<KeyCode>
{

}
public class PowerupCastEventListener : MonoBehaviour
{
    public PowerupCastEvent Event;
    public CustomPowerupCastEvent Response;
    // Start is called before the first frame update

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(KeyCode key)
    {
        Response.Invoke(key);
    }
}
