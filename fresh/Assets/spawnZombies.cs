using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZombies : MonoBehaviour
{

    private float nextSpawn = 0.0f;
    public float spawnCheckDelay = 5.0f;
    public GameObject zombie;
    private int maxZombies = 5;

    private float maxZombieInceseTime = 15.0f;
    private float maxZombieIncreaseInterval = 10.0f; 

    void Start() {
    }

    void Update() {
        if (Time.time > nextSpawn) {
            nextSpawn += spawnCheckDelay;

            spawnCheckDelay -= 0.2f;

            if (spawnCheckDelay < 0.5f)
                spawnCheckDelay = 0.5f;

            if (numberOfZombies() < maxZombies) {
                spawnZombie();
            }
        }
        if (Time.time > maxZombieInceseTime) {
            maxZombieInceseTime += maxZombieIncreaseInterval;
            maxZombies++;
            if (maxZombies > 25)
                maxZombies = 25;
        }
    }

    int numberOfZombies() {
        return GameObject.FindGameObjectsWithTag("Zombie").Length;
    }

    void spawnZombie() {
        int x = Random.Range(-20, 20);
        int z = Random.Range(-20, 20);

        if (x < 16 || z > -13) {
            Instantiate(zombie, new Vector3(x, 0.5f, z), Quaternion.identity);
        }
    }
}
