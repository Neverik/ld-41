using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
    public Transform toFollow;
    public float followSpeed;
    Vector3 offset;

    void Start() {
        offset = transform.position - toFollow.position;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, toFollow.position + offset, followSpeed);
	}
}
