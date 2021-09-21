using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float runSpeed = 125f;
    private float jumpSpeed = 28.5f;
    private float xBound = 10.0f;
    private float bulletBounce = 40.0f;
    private float groundPos = 0.47f;

    private Vector3 myGravity = new Vector3(0, -35, 0);

    public bool isOnGround = true;
    public bool canDoubleJump = false;
    

    private Rigidbody playerRb;
    private GameManager gameManager;
    private PlayerAnimation playerAnimation;
    private MoveBackground moveBackground;

    private AudioSource sounds;
    public AudioClip allahuAkbarSound;
    public AudioClip elhamdulillahSound;
    public AudioClip damagedSound;
    public AudioClip missileExplosionSound;
    public AudioClip mineExplosionSound;
    public AudioClip deathSound;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        sounds = GetComponent<AudioSource>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        moveBackground = GameObject.Find("Background").GetComponent<MoveBackground>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        ConstrainPlayerPosition();
        PlayerOnTheGround(); // Making sure player is not below the ground.
        PlayerIsDead(); // When health is 0, game stops and death animation begins.
        Crouch();

        Physics.gravity = myGravity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnimation.runParticle.Play();
        }
        
    }



    // Player right/left movement.
    private void MovePlayer()
    {
        if(gameManager.isGameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.right * horizontalInput * runSpeed);
        }
        
    }

    //Player can jump BUT CANNOT DOUBLE JUMP.S
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameOver == false)
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                isOnGround = false;
                canDoubleJump = true;
                playerAnimation.JumpAnimation();
                playerAnimation.runParticle.Stop();
            }
            else
            {
                if (canDoubleJump && gameManager.isGameOver == false)
                {
                    playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                    canDoubleJump = false;
                    playerAnimation.JumpAnimation();
                }
                
            }
            
        }
    }

    //Player movement/position constrained on left and right range.
    private void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            //playerRb.velocity = Vector3.zero;
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            //playerRb.velocity = Vector3.zero;
        }
    }

    // Adjusting buffs, missiles, mines, bullets.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BuffHealth"))
        {
            Destroy(other.gameObject);
            gameManager.AddHealth(1);
            sounds.PlayOneShot(elhamdulillahSound);
        }
        else if (other.gameObject.CompareTag("BuffSpeed"))
        {
            Destroy(other.gameObject);
            StartCoroutine(BuffSpeedDelay());
            sounds.PlayOneShot(allahuAkbarSound);
        }
        else if (other.gameObject.CompareTag("Missile"))
        {
            playerAnimation.missileExplosionParticle.Play();
            Destroy(other.gameObject);
            gameManager.AddHealth(-3);
            sounds.PlayOneShot(missileExplosionSound);
        }
        else if (other.gameObject.CompareTag("Mine"))
        {
            Destroy(other.gameObject);
            gameManager.AddHealth(-3);
            playerAnimation.mineExplosionParticle.Play();
            sounds.PlayOneShot(mineExplosionSound);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            // if hits, bounces player a little, if hits 3 time game ends.
            playerRb.AddForce(Vector3.left * bulletBounce, ForceMode.Impulse);
            Destroy(other.gameObject);
            gameManager.AddHealth(-1);
            sounds.PlayOneShot(damagedSound);
        }
    }

    IEnumerator BuffSpeedDelay()
    {
        float orgPlayerSpeed = runSpeed;

        runSpeed *= 4;

        yield return new WaitForSeconds(5);

        runSpeed = orgPlayerSpeed;
    }

    void PlayerOnTheGround()
    {
        if(transform.position.y < groundPos)
        {
            transform.position = new Vector3(transform.position.x, groundPos, transform.position.z);
        }
    }

    void PlayerIsDead()
    {
        if(gameManager.health <= 0)
        {
            gameManager.isGameOver = true;
            playerAnimation.playerAnim.SetBool("Death_b", true);
            playerAnimation.playerAnim.SetInteger("DeathType_int", 2);
            moveBackground.enabled = false;
            playerAnimation.runParticle.Stop();
            sounds.PlayOneShot(deathSound);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) && gameManager.isGameOver == false)
        {
            playerAnimation.playerAnim.SetInteger("WeaponType_int", 2);
        }
        else
        {
            playerAnimation.playerAnim.SetInteger("WeaponType_int", 0);
        }

    }
}
