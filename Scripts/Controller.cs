using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float moveSpeed;
    public float horMult;
    public float dashSpeed;
    public float dashTime;
    public float dashRecharge;
    public float dashTimeOut;
    public Anima anima;
    [HideInInspector]
    float rechargeTimeOut;
    public Rigidbody rb;
    Vector3 dashDirection;

    void Start()
    {
        Camera.main.GetComponent<Follow>().toFollow = Manager.instance.transform;
        transform.position = Manager.instance.saveState;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Manager.instance.saveState = transform.position;
            Manager.instance.transform.position = Camera.main.GetComponent<Follow>().toFollow.position;
        }
        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            vel.z = moveSpeed;
            anima.current = 1;
        }
         else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            vel.x = -moveSpeed * horMult;
            anima.current = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            vel.z = -moveSpeed;
            anima.current = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            vel.x = moveSpeed * horMult;
            anima.current = 1;
        } else {
            anima.current = 0;
        }
        if (rechargeTimeOut <= 0) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                rechargeTimeOut = dashRecharge;
                dashDirection = new Vector3(0f, 0f, 1f);
                dashTimeOut = dashTime;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rechargeTimeOut = dashRecharge;
                dashDirection = new Vector3(-1f, 0f, 0f) * horMult;
                dashTimeOut = dashTime;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rechargeTimeOut = dashRecharge;
                dashDirection = new Vector3(0f, 0f, -1f);
                dashTimeOut = dashTime;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rechargeTimeOut = dashRecharge;
                dashDirection = new Vector3(1f, 0f, 0f) * horMult;
                dashTimeOut = dashTime;
            }
        }
        if (dashTimeOut > 0)
        {
            vel = dashDirection * dashSpeed;
            dashTimeOut -= Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dashDirection, transform.up);
            anima.current = 2;
        }
        if (rechargeTimeOut > 0)
        {
            rechargeTimeOut -= Time.deltaTime;
        }
        rb.velocity = vel;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Door") {
            Door door = other.GetComponent<Door>();
            foreach (var item in door.keys)
            {
                if (!Manager.instance.keys.Contains(item))
                {
                    rb.position = Vector3.Lerp(transform.position, Camera.main.gameObject.GetComponent<Follow>().toFollow.position, 0.2f);
                    Manager.instance.txt.text = "You  don't have  the  key  to  this  area!";
                    DeleteText(2f);
                    return;
                }
            }
            if (door.entered) {
                Camera.main.gameObject.GetComponent<Follow>().toFollow = door.oldFocus;
            } else {
                Camera.main.gameObject.GetComponent<Follow>().toFollow = door.newFocus;
            }
            door.entered = !door.entered;
        }
    }

    public static void DeleteText (float t) {
        FindObjectOfType<Controller>().StartCoroutine(DelTxt(t));
    }

    static IEnumerator DelTxt (float t) {
        yield return new WaitForSeconds(t);
        Manager.instance.txt.text = "";
    }
}
