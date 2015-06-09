using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	bool mouse1Down;
	Vector3 lastMousePosition;

	public float vRotateSpeed = 1.0f;
	public float hRotateSpeed = 1.0f;

	Vector3 offset;
	Vector3 rotation;

	void Start () {
		lastMousePosition = Input.mousePosition;
		offset = transform.position;
		rotation = transform.rotation.eulerAngles;
	}

	Vector3 offsetPosition(Quaternion rotation, Vector3 offset) {
		return rotation * (offset.z * Vector3.forward) + offset.y * Vector3.up + offset.x * Vector3.right;
	}

	// Update is called once per frame
	void Update () {
		Vector3 mouseDelta = lastMousePosition - Input.mousePosition;

		mouse1Down = !Input.GetMouseButtonUp(1) && (Input.GetMouseButtonDown(1) || mouse1Down);

		if (mouse1Down) {
			rotation += new Vector3(mouseDelta.y * vRotateSpeed, -mouseDelta.x * hRotateSpeed, 0);


			Quaternion rot = Quaternion.Euler(rotation);
			transform.position = offsetPosition(rot, offset); 
			transform.rotation = rot;
		}

		lastMousePosition = Input.mousePosition;
	}
}
