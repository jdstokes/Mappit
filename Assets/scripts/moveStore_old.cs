using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class moveStore_old : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPosition;
	private Vector3 endingPosition;
	private Vector3 cursorOffset;


	private Vector3 velocity = Vector3.zero;

	private bool mouseDown = false;
	private bool getStartingPosition = true;
	private bool reset = false;
	private Shops shops;
	private bool dragable;

	void Awake(){

		shops = gameObject.transform.parent.GetComponent<Shops>();
		dragable = shops.dragable;

	}
void Start(){
//
//		if(dragable){
//		foreach (string name in GameControl.store_names){
//			if(name == gameObject.name){
//				
//			   int I = GameControl.store_names.IndexOf (name);
//			   Store store = GameControl.stores_all[I];
//			   store = store.SetBaseLocation(GameControl.stores_all[I],
//					                    gameObject.transform.position,gameObject.transform.localEulerAngles);
//			   GameControl.stores_all[I] = store;
//
//		}
//		}
//	}
}

void Update(){


//		ResetPosition();

	}
	


void OnMouseDown(){

		if(dragable){
		mouseDown = true;
		GameControl.selectedStoreName = "";


		if (getStartingPosition) {

			startingPosition = gameObject.transform.position;
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			cursorOffset = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) -startingPosition;
			getStartingPosition =false;
		}
	}

}

void OnMouseUp(){


	if(dragable){
	mouseDown = false;
	getStartingPosition = true;

	
		}

}
void OnMouseDrag(){

			if(dragable){
			GameControl.selectedStoreName = "";
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			offset = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) - gameObject.transform.position - cursorOffset;
			gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, gameObject.transform.position + offset, ref  velocity, .02F);
	
		}
		}


//void OnTriggerStay(Collider collision) {
//		if(dragable){
//		if (!mouseDown) {
//			reset = true;
//
//		}
//		}
//	}
		


void OnMouseEnter() {
		PresentStoreNameOn();				
}
	
void OnMouseExit() { 
		PresentStoreNameOff();
}


///// Other
//void ResetPosition(){
//		if (!mouseDown & reset & mapDraw.store_selected == gameObject.name ) {
//			//			gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, startingPosition, ref  velocity, .02F);
//			gameObject.transform.position = startingPosition;	
//			reset = false;
//		}
//}


void PresentStoreNameOn(){
		if (!mouseDown) {
			GameControl.selectedStoreName = gameObject.name;
			GameControl.selectedStorePosition = gameObject.transform.position;
			
			Collider collider = gameObject.GetComponent<Collider> (); 
			GameControl.selectedStoreSize = collider.bounds.size;
		}	

	}

void PresentStoreNameOff(){
		GameControl.selectedStoreName = "";

	}
	
}
	

