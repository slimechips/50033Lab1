using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableMushroomController : MonoBehaviour
{

    private Rigidbody2D body;
    public int velocity;
    private Vector2 direction;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        int rnd = Random.Range(0, 2);
        direction = rnd == 0 ? Vector2.left : Vector2.right;

        body.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        body.AddForce(direction * velocity, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stop && body.velocity == Vector2.zero)
        {
            body.AddForce(direction * velocity, ForceMode2D.Impulse);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stop = true;
            body.velocity = Vector2.zero;
            Debug.Log("Mush stop");
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            body.velocity = Vector2.zero;
            direction = -direction;
            body.AddForce(direction * velocity, ForceMode2D.Impulse);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
