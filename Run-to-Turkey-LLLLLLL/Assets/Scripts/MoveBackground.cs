using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 0.6f;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector3(Time.time * speed, 0, 0);
    }
}
