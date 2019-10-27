using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 4;

    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collEvents;

    private void Start() {
        particle = GetComponent<ParticleSystem>();
        collEvents = new List<ParticleCollisionEvent>();
    }

    void Update() {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other) {
        Destroy(this.gameObject);
    }
}
