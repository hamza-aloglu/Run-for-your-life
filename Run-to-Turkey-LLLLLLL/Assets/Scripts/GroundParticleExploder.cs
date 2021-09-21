using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleExploder : MonoBehaviour
{
    GroundParticleExplosion groundParticleExplosion;
    private AudioSource sound;
    public AudioClip explosion;
    // Start is called before the first frame update
    void Start()
    {
        groundParticleExplosion = GameObject.Find("Explosion Adjuster").GetComponent<GroundParticleExplosion>();

        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            groundParticleExplosion.transform.position = other.gameObject.transform.position; // Moves "Explosion Adjuster" object to position where missile was dropped so ensures particle effect occur in correct position.
            groundParticleExplosion.missileExplosionParticle.Play();
            sound.PlayOneShot(explosion);
        }
    }
}
