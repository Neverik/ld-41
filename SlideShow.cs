using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlideShow : MonoBehaviour {

    public Image img;
    public Sprite[] sprites;
    public string nextScene;
    int index;
    public bool loadNext = true;

    void Update() {
        img.sprite = sprites[index];
    }

    public void NextSlide() {
        index++;
        if (index == sprites.Length) {
            index--;
            if (loadNext)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
