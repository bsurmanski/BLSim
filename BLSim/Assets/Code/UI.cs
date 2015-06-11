using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public Texture2D brickButton; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		Rect brickRect = new Rect(0, 0, 40, 40);
		GUI.Button (brickRect, brickButton);
	}
}
