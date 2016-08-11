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

		txt.text=GameControl.selectedStoreName;
		x =GameControl.selectedStorePosition.x + GameControl.selectedStoreSize.x;
		y =GameControl.selectedStorePosition.y;
		z =GameControl.selectedStorePosition.z + GameControl.selectedStoreSize.z;
		gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(x,y,z)); 
//		Debug.Log (rectTransform.sizeDelta); 
//		Debug.Log (GameControl.selectedStoreSize);
		                                                               
	}

}

