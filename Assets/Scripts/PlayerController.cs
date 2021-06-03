using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float upSpeed;
    private Rigidbody2D marioBody;
    private SpriteRenderer sprite;
    private bool faceRightState = true;
    public float maxSpeed;
    private bool onGroundState;

    public Transform enemyLocation;
    public Text scoreText;
    private int score = 0;
    private bool countScoreState = false;

    private int health;
    [SerializeField] private int maxHealth;

    private Animator animator;
    private AudioSource audio;

    private bool stop = true;
    void Start()
    {
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        health = maxHealth;
        MenuController.Instance.HealthText.UpdateHealth(health);
    }

    void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < maxSpeed)
                marioBody.AddForce(movement * speed);

        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            // Lab 2
            if (Mathf.Abs(marioBody.velocity.x) > 0.01)
            {
                Debug.Log("skidding");
                animator.SetTrigger("onSkid");
            }

            Debug.Log("asdf");
            marioBody.velocity = Vector2.zero;
        }


        if (Input.GetKeyDown("space") && onGroundState)
        {
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            countScoreState = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
        animator.SetBool("onGround", onGroundState);

        // toggle state
        if (Input.GetKeyDown("a") && faceRightState)
        {
            faceRightState = false;
            sprite.flipX = true;
        }

        if (Input.GetKeyDown("d") && !faceRightState)
        {
            faceRightState = true;
            sprite.flipX = false;
        }

        // when jumping, and Gomba is near Mario and we haven't registered our score
        if (!onGroundState && countScoreState)
        {
            if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f)
            {
                countScoreState = false;
                score++;
                Debug.Log(score);
            }
        }

    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Obstacle")) onGroundState = true;
        countScoreState = false; // reset score state
        scoreText.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Gomba!");
            health--;
            MenuController.Instance.HealthText.UpdateHealth(health);
            if (health <= 0)
            {
                MenuController.Instance.GameOver();
            }
        }
    }



    // Lab 2
    void PlayJumpSound()
    {
        audio.PlayOneShot(audio.clip);
    }

}
