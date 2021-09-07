using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float score = 0;
    public int health = 3;

    public bool isGameOver = false;
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
