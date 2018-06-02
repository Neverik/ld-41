using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public float healthBuff;
    public float regenBuff;
    public float atkBuff;
    public float defBuff;
    public float dashSpeedBuff;
    public float dashRechargeBuff;
    public float dashLengthBuff;
    public List<int> keys;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            Manager.instance.atk += atkBuff;
            Manager.instance.def += defBuff;
            Manager.instance.regen += regenBuff;
            Manager.instance.playerHealth += healthBuff;

            FindObjectOfType<Controller>().dashSpeed += dashSpeedBuff;
            FindObjectOfType<Controller>().dashRecharge += dashRechargeBuff;
            FindObjectOfType<Controller>().dashTime += dashLengthBuff;

            Manager.instance.keys.AddRange(keys);
            Destroy(gameObject);
        }
    }
}
