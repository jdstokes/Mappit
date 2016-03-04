using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class mapDraw : MonoBehaviour {
	private int count= 0;
	private Transform shop;
	private GameObject background;
	public static  string store_selected;
//	private Transform shopInstance;
	private GameObject mapDrawCanvas;
	private GameObject shops;


	void Start(){
		background = GameObject.Find ("Background");
		mapDrawCanvas = GameObject.Find ("Canvas");
		shops = GameObject.Find ("ShopsMapDraw");
		GetBaseCoordinates();

	}




		
	void GetBaseCoordinates(){
		foreach(Store store in GameControl.stores_all){
		foreach(Transform child in  shops.transform){
		
//				stores.Add (new Store (child.name, child.position, child.localEulerAngles));
				if(store.name == child.name){

					store.SetBaseLocation(store, child.position, child.localEulerAngles);
				}

		}
		}

	}

public void GetMapCoordinates(){
		foreach(Store store in GameControl.stores_all){
			foreach(Transform child in  shops.transform){
				
				//				stores.Add (new Store (child.name, child.position, child.localEulerAngles));
				if(store.name == child.name){
					
					store.SetMapLocation(store, child.position, child.localEulerAngles);
					
				}
				
				
				
			}
		}
		
		
		
		
	}
	


}



	


