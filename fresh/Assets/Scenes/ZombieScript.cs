using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{    
    public GameObject Player;
    public float movementSpeed = 1;
    public Transform player;
    public NavMeshAgent agent;

    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Player.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet"){
        health--;
        if (health <= 0) {
            Destroy(this.gameObject);
        }
        }
    }
}
