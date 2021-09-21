using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float downSpeed = 6.0f;
    private float leftSpeed = 6f; //missile should go slightly to the left while dropping.

    Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.down * downSpeed);
        transform.Translate(Vector3.left * leftSpeed * Time.deltaTime);

        if(transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }

    
}
