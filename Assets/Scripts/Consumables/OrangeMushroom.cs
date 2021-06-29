using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMushroom : MonoBehaviour, ConsumableInterface
{
    public Texture t;
    private int index = 0;
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
        player.GetComponent<PlayerController>().maxSpeed *= 2;
        StartCoroutine(removeEffect(player));
    }

    IEnumerator removeEffect(GameObject player)
    {
        yield return new WaitForSeconds(5.0f);
        player.GetComponent<PlayerController>().maxSpeed /= 2;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // update UI
            CentralManager.instance.addPowerup(t, index, this);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine(MushroomAbsorbOrange());
        }
    }

    IEnumerator MushroomAbsorbOrange()
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
