using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private float maxWalkTime = 2.7f;
    private float walkTime = 0;
    private float walkSpeed = 0.8f;
    private float maxFlyTime = 1.11f;
    private float flyTime = 0; // how many seconds player is flying.

    public Animator playerAnim;
    public PlayerController playerController;

    public ParticleSystem runParticle;
    public ParticleSystem missileExplosionParticle;
    public ParticleSystem mineExplosionParticle;
    

    void Start()
    {   
        playerAnim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        WalkAtBeginning();
    }
    
    void WalkAtBeginning()
    {
        if(walkTime < maxWalkTime)
        {
            playerAnim.SetFloat("Speed_f", 0.30f);
            playerAnim.SetBool("Static_b", false);
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);
            walkTime += Time.deltaTime;
            runParticle.Stop();
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

        if(flyTime > maxFlyTime)
        {
            playerAnim.SetBool("Grounded", false); // if fly time more than 1.11 seconds, player should begin falling animation.
        }
    }
    
    public void JumpAnimation()
    {
            playerAnim.Play("Running_Jump", 3, 0);
    }

    void EnablePlayerControllerScript()
    {
        playerController.enabled = true;
    }
    
}
