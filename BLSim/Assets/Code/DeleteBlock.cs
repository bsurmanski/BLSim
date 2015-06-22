using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DeleteBlock : MonoBehaviour  ,IDropHandler
{
	public GameObject receivingBlock;
	
	public void OnDrop(PointerEventData e)
	{	//Debug.Log (e.pointerDrag.name);
		Debug.Log ("on drop");
		GameObject dropBlock = GetDropBlock (e);
		if (dropBlock != null) {
			Debug.Log(dropBlock);
			//Destroy (dropBlock);
		}
	}


	private GameObject GetDropBlock(PointerEventData e)
	{
		GameObject blockObject = e.pointerDrag;
		Debug.Log ("Print getDrop" );
		Transform getComponent = blockObject.GetComponent<Transform> ();
//		GameObject blockObj = blockObject.GetComponent<GameObject>();
//		if (blockObj == null)
//			return null;
//			
		return getComponent.gameObject;
	}


}
