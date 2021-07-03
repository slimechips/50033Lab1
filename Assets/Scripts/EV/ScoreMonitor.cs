using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMonitor : MonoBehaviour
{

    public IntVariable marioScore;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        text.text = "Score: " + marioScore.Value.ToString();
    }
}
