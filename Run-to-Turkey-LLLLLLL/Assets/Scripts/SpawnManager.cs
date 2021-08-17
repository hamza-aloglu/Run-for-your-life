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
    private float ySpawnPos = 14.0f; // for missile.
    private float yGroundPos = 0.5f; // for mine.

    private float ySpawnRange = 12.0f; // for bullet.
    private float xSpawnRange = 17.0f; // for missile.
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMissile", 1, 1.2f);
        InvokeRepeating("SpawnMine", 1, 1.5f);
        InvokeRepeating("SpawnBullet", 1, 0.7f);
        InvokeRepeating("SpawnRandomBuff", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    private void SpawnBullet()
    {
        float yRandom = Random.Range(0, ySpawnRange);
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
        float xRandom = Random.Range(0, xSpawnRange);
        Vector3 spawnPos = new Vector3(xRandom, ySpawnPos, 0);
        Instantiate(missile, spawnPos, missile.transform.rotation);
    }

    private void SpawnRandomBuff()
    {
        int spawnIndex = Random.Range(0, buffs.Length);
        float yRandom = Random.Range(0, ySpawnRange);

        Vector3 spawnPos = new Vector3(xSpawnPos, yRandom, 0);

        Instantiate(buffs[spawnIndex], spawnPos, buffs[spawnIndex].transform.rotation);
    }
}
