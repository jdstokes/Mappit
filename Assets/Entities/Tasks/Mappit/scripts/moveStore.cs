﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class moveStore : MonoBehaviour {

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
	private bool mouseDrag = false;
	private bool overHolder = false;
	private 		RaycastHit hit;

	void Start(){

		shops = gameObject.transform.parent.GetComponent<Shops>();
		dragable = shops.dragable;


	}
void Update(){

		LayerMask myLayerMask = (1 << 8);

		if(dragable && mouseDrag && MapDraw.store_selected == gameObject.name){
		Vector3 origin = new Vector3( gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
		Vector3 fwd = transform.TransformDirection(Vector3.down);
			if(Physics.SphereCast (origin,15,fwd,out hit,Mathf.Infinity,myLayerMask))
			{				

				if(hit.collider.gameObject.tag == "holder"){
				print("There is something in front of the object: " + hit.transform.name);
					overHolder =true;
				}
				else {
					overHolder =false;

				}
		} else {

				overHolder =false;

			}
	}

	}
	


void OnMouseDown(){

		if(dragable){
		mouseDown = true;
		GameControl_map.selectedStoreName = "";
		MapDraw.store_selected = gameObject.name;
        
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
			mouseDrag = false;
//			mapDraw.store_selected = "";
			if(overHolder){

				Vector3 center = new Vector3(hit.collider.bounds.center.x,gameObject.transform.position.y,hit.collider.bounds.center.z);
				gameObject.transform.position = center;

				gameObject.transform.rotation = hit.collider.gameObject.transform.rotation;


			}


	


	
		}

}
void OnMouseDrag()
{

	if(dragable)
	{

	
	mouseDrag = true;
	GameControl_map.selectedStoreName = "";
	screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
	offset = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) - gameObject.transform.position - cursorOffset;
	gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, gameObject.transform.position + offset, ref  velocity, .02F);

	}
}



		


void OnMouseEnter() {
		PresentStoreNameOn();				
}
	
void OnMouseExit() { 
		PresentStoreNameOff();
}




void PresentStoreNameOn(){
		if (!mouseDown) {
			GameControl_map.selectedStoreName = gameObject.name;
			GameControl_map.selectedStorePosition = gameObject.transform.position;
			
			Collider collider = gameObject.GetComponent<Collider> (); 
			GameControl_map.selectedStoreSize = collider.bounds.size;
		}	

	}

void PresentStoreNameOff(){
		GameControl_map.selectedStoreName = "";

	}



void FindTrueRotation(){

	foreach(Store store in GameControl_map.stores_all){

		if(gameObject.name == store.name){

			gameObject.transform.eulerAngles=store.rotation_true;
		}

	}


}

}
	

