using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class storeName : MonoBehaviour {
	Text txt;
	RectTransform rectTransform;
	float x;
	float y;
	float z;
//	public Camera camera;


	void Update() {
		txt = gameObject.GetComponent<Text>(); 
		rectTransform = gameObject.GetComponent<RectTransform>(); 

		txt.text=GameControl_map.selectedStoreName;
		x =GameControl_map.selectedStorePosition.x + GameControl_map.selectedStoreSize.x;
		y =GameControl_map.selectedStorePosition.y;
		z =GameControl_map.selectedStorePosition.z + GameControl_map.selectedStoreSize.z;
		gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(x,y,z)); 
//		Debug.Log (rectTransform.sizeDelta); 
//		Debug.Log (GameControl.selectedStoreSize);
		                                                               
	}

}

