using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float xDestroy = -18.0f; // The position objects will be destroyed.

    public float speed = 122;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Moves objects and destroys if they pass "xDestroy" position.
    void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < xDestroy)
        {
            Destroy(gameObject);
        }
    }
}
