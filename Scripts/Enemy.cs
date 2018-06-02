using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float activateDistance;
    public Action activate;
    public Rigidbody rb;
    public Anima anima;
    public float health;
    [Header("Attack")]
    public string state = "attack";
    public float attackDelay;
    public int numAttacks;
    public Transform player;
    public float attackSpeed;
    public float attackExtrapolate;
    public float atk;
    [Header("Wait")]
    public float waitTime;
    [Header("Flee")]
    public float fleeTime;
    public float fleeSpeed;
    bool fleeing;
    [Header("Shoot")]
    public float shootTime;
    public float shootDelay;
    public float shootOffset;
    public float shootRun;
    public Transform instantiateIn;
    public GameObject shootPrefab;
    [Header("Defense")]
    bool defending;
    public float defense;
    public float defendTime;
    public float defenseSpeed;
    public Action death;
    [Header("Clicker")]
    public float clickSpeed;
    float balance;
    public float clickTime;
    public float clashDamage;
    public AudioClip theme;
    bool lerp = true;
    Vector3 target;
    bool activated;
    AudioSource src;

    void Activate () {
        activated = true;
        StartCoroutine("Search");
	}

    void FixedUpdate() {
        if (lerp && activated)
        {
            rb.position = Vector3.Lerp(transform.position, target, attackSpeed);
        }
    }

    void Update() {
        if (health <= 0)
        {
            Destroy(src);
            AudioSource src2 = Manager.instance.gameObject.AddComponent<AudioSource>();
            src2.clip = Manager.instance.dft;
            src2.loop = true;
            src2.Play();
            death.Invoke();
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, player.position) < activateDistance && !activated) {
            Debug.Log("activated");
            activate.Invoke();
            Destroy(Manager.instance.Source);
            src = Manager.instance.gameObject.AddComponent<AudioSource>();
            src.clip = theme;
            src.loop = true;
            src.Play();
            Activate();
        }
        if (activated)
        {
            if (fleeing)
            {
                Avoid(fleeSpeed);
            }
            else if (defending)
            {
                Avoid(defenseSpeed);
            }
            else if (state == "clash")
            {
                balance -= clickSpeed;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    balance += 1;
                }
            }
            else if (state == "defense")
            {
                transform.LookAt(player);
                transform.Rotate(0, 180, 0);
            }
        }
    }

    IEnumerator Search () {
        while (true)
        {
            Debug.Log(state);
            switch (state)
            {
                case "attack":
                    for (int i = 0; i < numAttacks; i++)
                    {
                        Attack();
                        yield return new WaitForSeconds(attackDelay);
                    }
                    state = "wait";
                    break;
                case "wait":
                    target = transform.position;
                    yield return new WaitForSeconds(waitTime);
                    state = "flee";
                    break;
                case "flee":
                    fleeing = true;
                    lerp = true;
                    yield return new WaitForSeconds(fleeTime);
                    fleeing = false;
                    state = "shoot";
                    break;
                case "shoot":
                    float s = Time.time;
                    target = transform.position;
                    while (Time.time - shootTime < s)
                    {
                        Avoid(shootRun);
                        transform.LookAt(player);
                        transform.Rotate(new Vector3(0f, Random.Range(-shootOffset, shootOffset), 0f));
                        Instantiate(shootPrefab, instantiateIn.position, instantiateIn.rotation);
                        yield return new WaitForSeconds(shootDelay);
                    }
                    state = "defense";
                    break;
                case "defense":
                    lerp = false;
                    defending = true;
                    yield return new WaitForSeconds(defendTime);
                    defending = false;
                    state = "clash";
                    break;
                case "clash":
                    yield return new WaitForSeconds(clickTime);
                    if (balance < 0) {
                        Manager.instance.playerHealth -= clashDamage * Manager.instance.def;
                    } else {
                        state = "attack";
                    }
                    break;
            }
        }
    }

    public void Avoid (float speed) {
        Vector3 nm = (transform.position - player.position).normalized;
        transform.LookAt(player);
        target = transform.position + nm * speed;
    }

    public void Attack() {
        lerp = true;
        target = Lerp(transform.position, player.position, attackExtrapolate);
        transform.LookAt(player);
    }

    Vector3 Lerp (Vector3 a, Vector3 b, float t) {
        return a + (b - a) * t;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            if (state == "attack") {
                Manager.instance.playerHealth -= atk * Manager.instance.def;
            } else if (state == "defense" && player.GetComponent<Controller>().dashTimeOut > 0) {
                health -= Manager.instance.atk * defense;
            }
        }
    }
}
