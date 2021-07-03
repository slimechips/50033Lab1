using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerEV : MonoBehaviour
{
    public UnityEvent onApplicationExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnApplicationQuit()
    {
        onApplicationExit.Invoke();

    }
}
