using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
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

    public float gameTime = 0;

    SpawnManagerSpeedy spawnManagerSpeedy;
    GameManager gameManager;

    void Start()
    {
        spawnManagerSpeedy = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerSpeedy>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("SpawnMissile", 4, 6.2f);
        InvokeRepeating("SpawnMine", 4, 4.1f);
        InvokeRepeating("SpawnBullet", 4, 2.3f);
        InvokeRepeating("SpawnRandomBuff", 4, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > 30 && gameManager.DisplayHealth() > 0)
        {
            CancelInvoke();
            spawnManagerSpeedy.enabled = true;
            this.enabled = false;
        }

        if (gameManager.DisplayHealth() <= 0)
            CancelInvoke();
    }


    
    private void SpawnBullet()
    {
        float yRandom = Random.Range(ySpawnBottomPos, ySpawnUpPos);
        Vector3 spawnPos = new Vector3(xSpawnPos, yRandom, 0);
        Instantiate(bullet, spawnPos, bullet.transform.rotation);
    }

    private void SpawnMine()
    {
        Vector3 spawnPos = new Vector3(xSpawnPos, yGroundPos, 0);
        Instantiate(mine, spawnPos, mine.transform.rotation);
    }

    private void SpawnMissile()
    {
        float xRandom = Random.Range(xSpawnBottomPos, xSpawnUpPos); 
        Vector3 spawnPos = new Vector3(xRandom, ySpawnPos, 0);
        Instantiate(missile, spawnPos, missile.transform.rotation);
    }

    private void SpawnRandomBuff()
    {
        int spawnIndex = Random.Range(0, buffs.Length);
        float yRandom = Random.Range(ySpawnBottomPos, ySpawnUpPos);

        Vector3 spawnPos = new Vector3(xSpawnPos, yRandom, 0);

        Instantiate(buffs[spawnIndex], spawnPos, buffs[spawnIndex].transform.rotation);
    }
}
