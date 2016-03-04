using UnityEngine;
using System.Collections;

public class MoveStoresToHouse : MonoBehaviour {

	private GameObject shops;
	public  GameObject storeRoomPF;
	private GameObject storeHouse;

	
	
	void Start(){
		shops = GameObject.Find ("Shops");
		storeHouse = GameObject.Find ("UI_store_house");

//		CreateTiles();
	}
	
	// Update is called once per frame
	void CreateTiles(){

		foreach (Transform store in shops.transform) {

			GameObject storeRoom = Instantiate(storeRoomPF) as GameObject;
			storeRoom.name = store.name;
			storeRoom.transform.SetParent(storeHouse.transform,true);
//			store.transform.position = new Vector3(newPos.x,store.transform.position.y,newPos.z);
//			store.transform.SetParent(storeRoom.transform,false);
//			Vector3 newPos = Camera.main.ViewportToWorldPoint(storeRoom.transform.position);



		
		}
	}
}
