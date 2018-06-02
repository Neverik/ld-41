using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAction : Action {
    public string toLoad;

    void Start() {
        if (toLoad == null) {
            toLoad = SceneManager.GetActiveScene().name;
        }
    }

    public override void Invoke () {
        SceneManager.LoadScene(toLoad);
    }
}
