using UnityEngine;
using System.Collections;

public class mapLearn : MonoBehaviour {

	private GameObject shops;

	void Awake(){
		shops = GameObject.Find ("ShopsTrue");
		GetStoreCoordinates();

		//Advanced roundNum by 1
		GameControl.roundNum ++;

	}


	void  GetStoreCoordinates(){
		GameControl.stores_all.Clear ();
		foreach (Transform store in shops.transform) {
			GameControl.stores_all.Add (new Store (store.name, store.position, store.localEulerAngles));
			GameControl.store_names.Add (store.name);

			}
			
		}

}