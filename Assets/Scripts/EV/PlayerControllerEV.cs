using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEV : MonoBehaviour
{
    private float force;
    public IntVariable marioUpSpeed;
    public IntVariable marioMaxSpeed;
    public GameConstants gameConstants;
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private bool isDead = false;
    private bool isADKeyUp = true;
    private bool isSpaceBarUp = true;
    private bool faceRightState = true;
    private bool onGroundState = true;
    private bool countScoreState = false;
    private Animator animator;
    public PowerupCastEvent powerupCastEvent;


    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource skidAudio;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        marioUpSpeed.SetValue(gameConstants.playerMaxJumpSpeed);
        marioMaxSpeed.SetValue(gameConstants.playerStartingMaxSpeed);
        force = gameConstants.playerDefaultForce;
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (!isADKeyUp)
            {
                float direction = faceRightState ? 1.0f : -1.0f;
                Vector2 movement = new Vector2(force * direction, 0);
                if (body.velocity.magnitude < marioMaxSpeed.Value)
                {
                    body.AddForce(movement);
                }

                if ((body.velocity.x > 0) ^ faceRightState)
                {
                    animator.SetTrigger("onSkid");
                    //skidAudio.PlayOneShot(skidAudio.clip);
                    body.velocity = Vector2.zero;
                }

            }
            else if (Mathf.Abs(body.velocity.x) > 0.01)
            {
                animator.SetTrigger("onSkid");
                //skidAudio.PlayOneShot(skidAudio.clip);
                body.velocity = Vector2.zero;
            }

            if (!isSpaceBarUp && onGroundState)
            {
                body.AddForce(Vector2.up * marioUpSpeed.Value, ForceMode2D.Impulse);
                onGroundState = false;
                animator.SetBool("onGround", onGroundState);
                countScoreState = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", Mathf.Abs(body.velocity.x));
        isADKeyUp = !(Input.GetKey("a") || Input.GetKey("d"));

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


        if (!isSpaceBarUp)
        {
            isSpaceBarUp = Input.GetKeyUp("space");
        } else
        {
            if (Input.GetKeyDown("space"))
            {
                isSpaceBarUp = false;
            }
        }

        if (Input.GetKeyDown("z"))
        {
            powerupCastEvent.Raise(KeyCode.Z);
        }

        if (Input.GetKeyDown("x"))
        {
            powerupCastEvent.Raise(KeyCode.X);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Obstacle"))
        {
            onGroundState = true;
            animator.SetBool("onGround", onGroundState);
        }
    }

    void PlayJumpSound()
    {
        audio.PlayOneShot(audio.clip);
    }

    public void PlayerDiesSequence()
    {
        // Mario dies
        isDead = true;
        // do whatever you want here, animate etc
        // ...
        Time.timeScale = 0;
        StartCoroutine(SpinDeath());

    }

    IEnumerator SpinDeath()
    {
        while (transform.localScale.x >= 0)
        {
            Vector3 rotator = new Vector3(0, 0, 6);
            Vector3 scaler = new Vector3(0.01f, 0.01f, 0);
            transform.rotation = Quaternion.Euler(transform.eulerAngles - rotator);
            transform.localScale -= scaler;
            yield return null;
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }



}
