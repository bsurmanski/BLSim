using UnityEngine;
using System.Collections;

public class Snap : MonoBehaviour {

	public bool isSnapping = false;
	void Start(){
		isSnapping =false;
	}
	void OnTriggerEnter( Collider col){	
		if (col.gameObject.CompareTag("Block") ) //if collides with a Block
		{
			isSnapping = true;
			Debug.Log("COLLIDE! "+col.gameObject.name +" triggered "+ gameObject.name +" "+ transform.parent.name);//collided object with snap
		}
	}

}
