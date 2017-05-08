using UnityEngine;
using System.Collections;

public class mapLearn : MonoBehaviour {

	private GameObject shops;

	void Awake(){
		shops = GameObject.Find ("ShopsTrue");
		GetStoreCoordinates();

	}


	void  GetStoreCoordinates(){
		GameControl_map.stores_all.Clear ();
		foreach (Transform store in shops.transform) {
			GameControl_map.stores_all.Add (new Store (store.name, store.position, store.localEulerAngles));
			GameControl_map.store_names.Add (store.name);

			}
			
		}

}