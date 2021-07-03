using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentralManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PowerupManager powerUpManager;
    public static CentralManager instance;

    void Awake()
    {
        instance = this;
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
        gameManager.increaseScore();
    }

    public void damagePlayer()
    {
        gameManager.damagePlayer();
    }

    public void consumePowerup(KeyCode k, GameObject g)
    {
        powerUpManager.consumePowerup(k, g);
    }

    public void addPowerup(Texture t, int i, ConsumableInterface c)
    {
        powerUpManager.addPowerup(t, i, c);
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void NextStage()
    {
        GameManager.Instance.NextStage();
    }
}
