using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class MapDraw : MonoBehaviour {


	private Transform shop;
	private GameObject background;
	public static  string store_selected;
//	private Transform shopInstance;
	private GameObject mapDrawCanvas;
	private GameObject shops;
	private GameObject house;
	private Vector3 startPosition;
	private Vector3 colliderSize;
	private Collider curCollider;
	public float spacing = 1.5f; //multiplier of store size
	
	private List<Transform> storeTrans = new List<Transform>();
	public StreamWriter newFile;


	
	
	void Awake(){

		background = GameObject.Find ("Background");
		mapDrawCanvas = GameObject.Find ("Canvas");
	    Directory.CreateDirectory(Application.dataPath + "/Data/");
		newFile = new StreamWriter(GameControl_map.subjectID + "_output.txt",true);
		newFile.Close();


	}

	void Start(){
		shops = GameObject.Find ("ShopsTrue");
		house = GameObject.Find ("house");
		startPosition = house.transform.position;
		StartCoroutine(Init());  

	}




		
	void GetBaseCoordinates(){

		foreach(Store store in GameControl_map.stores_all){
		foreach(Transform child in  house.transform){
		
//				stores.Add (new Store (child.name, child.position, child.localEulerAngles));
				if(store.name == child.name){

					store.SetBaseLocation(store, child.position, child.localEulerAngles);
				}

		}
		}

	}

public void GetMapCoordinates(){



		foreach(Store store in GameControl_map.stores_all){
			foreach(Transform child in  house.transform){
				
				//				stores.Add (new Store (child.name, child.position, child.localEulerAngles));
				if(store.name == child.name){
					
					store.SetMapLocation(store, child.position, child.localEulerAngles);

//					string line = PlayerPrefs.GetFloat("playerID") + "," + GameControl.roundNum + ","+ System.DateTime.Now + "," +
//						store.name +"," + child.position +"," + child.localEulerAngles;
//
//					print (line);
//					newFile = new StreamWriter(appDir+"/data/"+PlayerPrefs.GetString("playerID") + "/" + "output.txt",true);
//					newFile.WriteLine(line);
//					newFile.Close();

				}

			}
		}

	}

	public void LogData(){
		string appDir = Directory.GetCurrentDirectory();
		string line = PlayerPrefs.GetString("playerID") ;
		print (line);
		newFile = new StreamWriter(appDir+"/data/"+PlayerPrefs.GetString("playerID") + "/" + "output.txt",true);
		newFile.WriteLine(line);
		newFile.Close();


	}




	
	
	
public  IEnumerator Init(){
	
	foreach (Transform store in shops.transform) {
		storeTrans.Add(store);
		yield return null;
	}
	StartCoroutine(CreateRooms());
	
}

	
IEnumerator CreateRooms(){

	
	ShuffleList(storeTrans);
	
	
	foreach (Transform store in storeTrans) {
		
		GameObject storeRoom = Instantiate(store.gameObject) as GameObject;
		storeRoom.name = store.name;
		storeRoom.transform.SetParent(house.transform,true);
		storeRoom.transform.position = startPosition;
		storeRoom.transform.localEulerAngles = new Vector3(0f,90f,0f);
		curCollider = storeRoom.gameObject.GetComponent<Collider>();
		colliderSize = curCollider.bounds.size;
		startPosition = new Vector3(startPosition.x,startPosition.y ,startPosition.z - (colliderSize.z*spacing));
		yield return null;
		
	}

	GetBaseCoordinates();
	shops.SetActive (false);
}
	
	
void ShuffleList(List<Transform> alpha ) {
	for (int i = 0; i < alpha.Count; i++) {
		Transform temp = alpha[i];
		int randomIndex = Random.Range(i, alpha.Count);
		alpha[i] = alpha[randomIndex];
		alpha[randomIndex] = temp;
	}
	
}



}



	


