using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] Text text;
    private static string HEALTH_TEXT = "Health: {0}";
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int health)
    {
        text.text = string.Format(HEALTH_TEXT, health);
    }
}
