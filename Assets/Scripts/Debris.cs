using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector3 scaler;
    // Start is called before the first frame update
    void Start()
    {
        scaler = transform.localScale / (float)30;
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("ScaleOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScaleOut()
    {
        Vector2 direction = new Vector2(Random.Range(-1.0f, 1.0f), 1);
        rigidbody.AddForce(direction.normalized * 10, ForceMode2D.Impulse);
        rigidbody.AddTorque(20, ForceMode2D.Impulse);
        yield return null;

        for (int step = 0; step < 30; ++step)
        {
            transform.localScale -= scaler;
            yield return null;
        }
        Destroy(gameObject);

    }
}
