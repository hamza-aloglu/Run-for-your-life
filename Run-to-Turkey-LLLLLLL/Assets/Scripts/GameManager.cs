using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private float time = 0;
    private float score = 0;
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        

    }

    public void AddHealth(int amount)
    {
        health += amount;
        System.Console.WriteLine("Health: "+ health);
    }

    
}
