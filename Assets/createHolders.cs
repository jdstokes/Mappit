using UnityEngine;
using System.Collections;

public class createHolders : MonoBehaviour {

	private GameObject shops;
	public GameObject placeHolder;
	private GameObject house;
	
	void Awake(){
		shops = GameObject.Find ("ShopsTrue");
		house = GameObject.Find ("House");


		StartCoroutine(BuildHolders());
	}
	
	
	IEnumerator   BuildHolders(){
		Debug.Log ("Build House");
		foreach (Transform store in shops.transform) {
			GameObject newH = Instantiate(placeHolder);
			newH.name = store.name + "_holder";
			newH.transform.position = store.position;
			newH.transform.rotation = store.rotation;
			newH.transform.SetParent (house.transform);
			
			yield return null;
			
		}

		house.SetActive (false);
		
	}
	
}