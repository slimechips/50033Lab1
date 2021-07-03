using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
	public AudioSource changeSceneSound;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			changeSceneSound.PlayOneShot(changeSceneSound.clip);
			GetComponent<Collider2D>().enabled = false;
			CentralManager.instance.NextStage();
			StartCoroutine(LoadYourAsyncScene("MarioLevel2"));
		}
	}

	IEnumerator LoadYourAsyncScene(string sceneName)
	{
		yield return new WaitUntil(() => !changeSceneSound.isPlaying);
		CentralManager.instance.ChangeScene("MarioLevel2");
	}
}
