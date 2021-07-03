using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text score;
    private int playerScore = 0;

    public delegate void gameEvent();
    public static event gameEvent OnPlayerDeath;
    public static event gameEvent OnIncreaseScore;
    public static event gameEvent OnNextStage;


    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        playerScore += 1;
        score.text = string.Format("SCORE: {0}", playerScore);
        OnIncreaseScore();
    }

    public void damagePlayer()
    {
        OnPlayerDeath();
        MenuController.Instance.GameOver();
    }

    public void NextStage()
    {
        OnNextStage();
    }
}
