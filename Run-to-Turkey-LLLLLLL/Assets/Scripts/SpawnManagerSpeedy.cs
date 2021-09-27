using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSpeedy : MonoBehaviour
{
    public GameObject missile;
    public GameObject bullet;
    public GameObject mine;
    public GameObject[] buffs;



    private float xSpawnPos = 20.0f; // for mine.
    private float yGroundPos = 0.5f; // for mine.

    private float ySpawnBottomPos = 2.1f; // for bullet and buffs.
    private float ySpawnUpPos = 9.0f; // for bullet and buffs.

    private float ySpawnPos = 18.0f; // for missile.
    private float xSpawnUpPos = 25.0f; // for missile.
    private float xSpawnBottomPos = 5.0f; // for missile.

    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        InvokeRepeating("SpawnMissile", 10, 4.2f);
        InvokeRepeating("SpawnMissile", 16, 3.5f);

        InvokeRepeating("SpawnMine", 10, 3.6f);
        InvokeRepeating("SpawnMine", 16, 3f);

        InvokeRepeating("SpawnBullet", 10, 2.5f);
        InvokeRepeating("SpawnBullet", 16, 2.1f);

        InvokeRepeating("SpawnRandomBuff", 10, 7.1f);
        InvokeRepeating("SpawnRandomBuff", 16, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.DisplayHealth() <= 0)
        {
            // CancelInvoke("SpawnBullet");
            // CancelInvoke("SpawnMine");
            CancelInvoke();// Stops spawning after game is over
            this.enabled = false;
        }
            
    }

    public void SpawnBullet()
    {
        float yRandom = Random.Range(ySpawnBottomPos, ySpawnUpPos);
        Vector3 spawnPos = new Vector3(xSpawnPos, yRandom, 0);
        Instantiate(bullet, spawnPos, bullet.transform.rotation);
    }

    public void SpawnMine()
    {
        Vector3 spawnPos = new Vector3(xSpawnPos, yGroundPos, 0);
        Instantiate(mine, spawnPos, mine.transform.rotation);
    }

    public void SpawnMissile()
    {
        float xRandom = Random.Range(xSpawnBottomPos, xSpawnUpPos);
        Vector3 spawnPos = new Vector3(xRandom, ySpawnPos, 0);
        Instantiate(missile, spawnPos, missile.transform.rotation);
    }

    public void SpawnRandomBuff()
    {
        int spawnIndex = Random.Range(0, buffs.Length);
        float yRandom = Random.Range(ySpawnBottomPos, ySpawnUpPos);

        Vector3 spawnPos = new Vector3(xSpawnPos, yRandom, 0);

        Instantiate(buffs[spawnIndex], spawnPos, buffs[spawnIndex].transform.rotation);
    }
}
