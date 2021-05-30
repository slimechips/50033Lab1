using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public HealthUIController HealthText;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject GameOverTextGO;
    public static MenuController Instance { get; private set; }

    private static string GAME_OVER_BUTTON_TEXT = "GG";

    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        if (StartButton.GetComponentInChildren<Text>().text.Equals(GAME_OVER_BUTTON_TEXT))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            return;
        }

        foreach (Transform eachChild in transform)
        {
            // Disable each child that isnt score
            if (eachChild.name != "ScoreText" && eachChild != HealthText.transform)
            {
                eachChild.gameObject.SetActive(false);
            }

        }
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GameOverTextGO.SetActive(true);
        StartButton.SetActive(true);
        StartButton.GetComponentInChildren<Text>().text = GAME_OVER_BUTTON_TEXT;
    }
}
