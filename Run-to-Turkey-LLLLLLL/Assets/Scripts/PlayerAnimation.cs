using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private float walkTime = 0;
    private float walkSpeed = 0.8f;
    private float flyTime = 0; // how many seconds player is flying.

    public Animator playerAnim;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkAtBeginning();
    }
    //hey
    void WalkAtBeginning()
    {
        if(walkTime < 3)
        {
            playerAnim.SetFloat("Speed_f", 0.30f);
            playerAnim.SetBool("Static_b", false);
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);
            walkTime += Time.deltaTime;
        }
        else if(playerController.isOnGround)
        {
            playerAnim.SetFloat("Speed_f", 0.60f);
            playerAnim.SetBool("Grounded", true);
            flyTime = 0;
        }
        else
        {
           flyTime += Time.deltaTime;
        }

        if(flyTime > 1.11)
        {
            playerAnim.SetBool("Grounded", false); // if fly time more than 1.11 seconds, player should begin falling animation.
        }
    }
    
    public void JumpAnimation()
    {
            playerAnim.Play("Running_Jump", 3, 0);
    }

    
}
