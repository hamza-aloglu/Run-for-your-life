using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBackground : MonoBehaviour
{
    MoveBackground moveBackground;
    // Start is called before the first frame update
    void Start()
    {
        moveBackground = GetComponent<MoveBackground>();
        moveBackground.enabled = false;
        Invoke("EnableBackground", 3); // Stopping the background for 3 seconds for player to walk to scene.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void EnableBackground()
    {
        moveBackground.enabled = true;
    }
}
