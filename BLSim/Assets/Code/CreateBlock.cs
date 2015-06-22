using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CreateBlock : MonoBehaviour,IPointerClickHandler
{

	public GameObject DefaultBlock; //DefaultBlock prefab
	public GameObject DynamicObjects;

	public void OnPointerClick(PointerEventData e){
		//Create default blocks to dynamicobjects parent
	 GameObject inst = (GameObject)Instantiate (DefaultBlock, new Vector3 (0, 0, 0), Quaternion.identity);
		inst.transform.SetParent (DynamicObjects.transform);
	}
}

