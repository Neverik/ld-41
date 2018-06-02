using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public static Manager instance;
    public float playerHealth;
    public float maxHealth;
    public float atk;
    public float regen;
    public float def;
    public Image img;
    public List<int> keys;
    public Text txt;
    public List<GameObject> toHide;
    public AudioSource Source {
        get {
            return GetComponent<AudioSource>();
        }
    }
    public AudioClip dft;
    public Vector3 saveState;
    public Transform camFollow;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        playerHealth = maxHealth;
    }

    void Start() {
        //FindObjectOfType<Controller>().rb.position = saveState;
        //playerHealth = maxHealth;
    }

    void Update() {
        img.fillAmount = playerHealth / maxHealth;
        if (playerHealth <= 0) {
            playerHealth = maxHealth;
            GameOver();
        }
        playerHealth += regen;
        playerHealth = Mathf.Clamp(playerHealth, 0f, maxHealth);
        foreach (var item in toHide)
        {
            item.SetActive(txt.text != "");
        }
    }

    public void GameOver() {
        Time.timeScale = 0.05f;
        txt.text = "You died!";
        StartCoroutine(Death());
    }

    IEnumerator Death () {
        yield return new WaitForSeconds(0.1f);
        txt.text = "";
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }
}
