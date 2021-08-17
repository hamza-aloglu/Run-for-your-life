using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float xDestroy = -18.0f; // The position objects will be destroyed.

    public float speed = 2.0f;

    Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.left * speed);

        if(transform.position.x < xDestroy)
        {
            Destroy(gameObject);
        }
    }
}
