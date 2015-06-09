using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragAndDropBlocks : MonoBehaviour {

	private GameObject blockObjects;
	void Start(){
		blockObjects = GameObject.Find ("Blocks");
		//Debug.Log (blockObjects);
	}

	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.white;
	private bool dragging = false;
	private float distance;
	private float direction;
	/*
	OnMouseEnter() Turns the block to a new highlighted color
	 */
	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = mouseOverColor;
	}
	
	/*
	OnMouseExit() Returns the block to original color when mouse isn't on top of it.
	 */
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = originalColor;
	}

	/*
	OnMouseUp() left mouse click is not clicked
	 */
	void OnMouseUp()
	{
		dragging = false;
	}

	void OnMouseDown()
	{
		distance = Vector2.Distance(transform.position, Camera.main.transform.position);//Change x and y
		dragging = true;
	}
	


//	void OnMouseUpAsButton()
//	{
//		//Getcom
//	}
	
	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}


	}

}