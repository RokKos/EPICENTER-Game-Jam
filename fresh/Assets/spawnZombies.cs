using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZombies : MonoBehaviour
{

    private float nextSpawn = 0.0f;
    public float spawnCheckDelay = 3.0f;

    public GameObject zombie;

    void Start() {
    }

    void Update() {
        if (Time.time > nextSpawn) {
            nextSpawn += spawnCheckDelay;

            if (numberOfZombies() < 5) {
                spawnZombie();
            }
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
