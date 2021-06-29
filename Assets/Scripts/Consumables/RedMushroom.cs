using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour, ConsumableInterface
{
    public Texture t;
    private int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void consumedBy(GameObject player)
    {
        // Jump boost
        player.GetComponent<PlayerController>().upSpeed += 10;
        StartCoroutine(removeEffect(player));
    }

    IEnumerator removeEffect(GameObject player)
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Removing jump buff");
        player.GetComponent<PlayerController>().upSpeed -= 10;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // update UI
            CentralManager.instance.addPowerup(t, index, this);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine(MushroomAbsorbRed());
        }
    }

    IEnumerator MushroomAbsorbRed()
    {
        Vector3 scaler = transform.localScale / (float)20;
        for (int i = 0; i < 5; ++i)
        {
            transform.localScale += scaler;
            yield return null;
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
