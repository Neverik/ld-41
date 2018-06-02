using UnityEngine;
using System.Collections;

public class IOHelper : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 mousePosGlobal;
    public float mouseDeltaX;
    public float mouseDeltaY;
    public float deltaX;
    public float deltaY;
    public float time;

	public void UpdateStats() {
        mousePosition = Input.mousePosition;
        mousePosGlobal = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDeltaX = Input.GetAxis("Mouse X");
        mouseDeltaY = Input.GetAxis("Mouse Y");
        deltaX = Input.GetAxis("Horizontal");
        deltaY = Input.GetAxis("Vertical");
        time = Time.time;
	}

    public void Log(object s) {
        Debug.Log(s);
    }
}
