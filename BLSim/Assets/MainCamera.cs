using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	bool mouse1Down;
	Vector3 lastMousePosition;

	public float vRotateSpeed = 1.0f;
	public float hRotateSpeed = 1.0f;

	Vector3 rotation;

	void Start () {
		lastMousePosition = Input.mousePosition;
		rotation = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouseDelta = lastMousePosition - Input.mousePosition;

		mouse1Down = !Input.GetMouseButtonUp(1) && (Input.GetMouseButtonDown(1) || mouse1Down);

		if (mouse1Down) {
			rotation += new Vector3(mouseDelta.y * vRotateSpeed, mouseDelta.x * hRotateSpeed, 0);
			transform.rotation = Quaternion.Euler(rotation);
		}

		lastMousePosition = Input.mousePosition;
	}
}
