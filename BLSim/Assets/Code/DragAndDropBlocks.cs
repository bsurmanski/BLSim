using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragAndDropBlocks : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
	//Editer configs
	[Range(0.0f,1.0f)]
	public float  mouseDragSensitity = Mathf.Abs(0.0f); //Always positive unless direction is left or down.


	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.white;
	private bool dragging = false;
	//private bool cursorOn = false; experimental
	private float distance;
	private Vector3 initialPos;
	private float direction;

	public void OnPointerClick (PointerEventData eventData)
	{
		//Debug.Log("OnPointerClick");
	}
//	//OnMouseEnter() Turns the block to a new highlighted color
//	void OnMouseEnter(){
//		Debug.Log("mouseenter");
//	}
	public void OnPointerEnter(PointerEventData e)
	{
		//cursorOn = true;
		//Debug.Log("pointerEnter");
		GetComponent<Renderer>().material.color = mouseOverColor;
	}

	/*
	OnMouseExit() Returns the block to original color when mouse isn't on top of it.
	 */
	public void OnPointerExit(PointerEventData e) 
	{
		//cursorOn = false;
		//Debug.Log("pointerExit");
		GetComponent<Renderer>().material.color = originalColor;
	}

	/*
	OnMouseUp() left mouse click is not clicked
	 */
	public	void OnPointerUp(PointerEventData e)
	{
		//Debug.Log ("on pointer up");

		dragging = false;
	}

	public void OnPointerDown(PointerEventData e)
	{
		if(Input.GetMouseButton(1)==true)//Ignore right clicks
			return;
		//Debug.Log ("on pointer down");
		initialPos = transform.position;
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);//Change x and y
		dragging = true;
	}


	void FixedUpdate () // Usually Update()
	{
		if (dragging //&& cursorOn experimenting
		    ) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			//transform.position = rayPoint;
			Debug.Log("Initial pos"+initialPos);
			Debug.Log("raypoint"+rayPoint);

//			if(Vector3.Distance(initialPos,rayPoint)>9){
//				Debug.Log(initialPos+rayPoint);
//				//Debug.Log("dont move");
//				return;
//			}

			//Warning do not remove negative sign in front of mouseDragSensitity
			if(Input.GetAxis("Mouse X")<-(mouseDragSensitity)) //Go left
			{
				//Debug.Log("Going left");
				transform.position = transform.position+ Vector3.left;
			}
			if (Input.GetAxis("Mouse X")>mouseDragSensitity)// Go right
			{
			//	Debug.Log("Going right");
				transform.position = transform.position+ Vector3.right;
			}
//			else{
//				if(Input.GetAxis("Mouse Z")<-(mouseDragSensitity)){
//					Debug.Log("Going back");
//					transform.position = transform.position + Vector3.back;
//				}
//				if(Input.GetAxis("Mouse Z")>mouseDragSensitity){
//					Debug.Log("Going forward");
//					transform.position = transform.position + Vector3.forward;
//				}
//			}
		}
	}
}