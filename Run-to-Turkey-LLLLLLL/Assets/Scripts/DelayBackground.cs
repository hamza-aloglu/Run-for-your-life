using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBackground : MonoBehaviour
{
    MoveBackground moveBackground;

    private AudioSource audioSource;
    
    void Start()
    {
        moveBackground = GetComponent<MoveBackground>();
        moveBackground.enabled = false;
        Invoke("EnableBackground", 3); // Stopping the background for 3 seconds for player to walk to scene.

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void EnableBackground()
    {
        moveBackground.enabled = true;
        audioSource.Play();
    }
}
