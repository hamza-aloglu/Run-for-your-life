using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 14.0f;
    private float xBound = 17.0f;
    private float bulletBounce = 3.0f;

    bool isOnGround = true;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        ConstrainPlayerPosition();
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        
    }



    // Player right/left movement.
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (isOnGround)
        {
            playerRb.AddForce(Vector3.right * horizontalInput * speed);
        }
    }

    //Player can jump.
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    //Player movement/position constrained on left and right range.
    private void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    // Adjusting buffs, missiles, mines, bullets.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BuffHealth"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BuffSpeed"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Mine"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            // if hits, bounces player a little, if hits 3 time game ends.
            playerRb.AddForce(Vector3.left * bulletBounce, ForceMode.Impulse);
            Destroy(other.gameObject);
        }
    }



}
