using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float damage;
    public float lifeTime;
    float alive;

    void Start()
    {
        alive = Time.time;
    }

    void Update() {
        transform.Translate(0f, 0f, speed, Space.Self);
        if (Time.time - lifeTime > alive) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            Manager.instance.playerHealth -= damage;
        }
        Destroy(gameObject);
    }
}
