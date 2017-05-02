using UnityEngine;
using System.Collections;

public class createHolders : MonoBehaviour {

	private GameObject shops;
	public GameObject placeHolder;
	private GameObject house4holders;
	
	void Awake(){
		shops = GameObject.Find ("ShopsTrue");
		house4holders = GameObject.Find ("house4holders");


		StartCoroutine(BuildHolders());
	}
	
	
	IEnumerator   BuildHolders(){
		foreach (Transform store in shops.transform) {
			GameObject newH = Instantiate(placeHolder);
			newH.name = store.name + "_holder";
			newH.transform.position = store.position;
			newH.transform.rotation = store.rotation;
			newH.transform.SetParent (house4holders.transform);
			
			yield return null;
			
		}

		house4holders.SetActive (false);
		
	}
	
}