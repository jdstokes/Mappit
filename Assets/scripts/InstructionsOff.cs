using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class InstructionsOff : MonoBehaviour {

	public Transform startInstructions;
	public Transform playInstructions;

	private List<Transform> startStuff = new List<Transform>();
	private List<Transform> gameStuff = new List<Transform>();

	void Awake(){
		foreach(Transform child in startInstructions)
		{
			startStuff.Add(child);
		}

		foreach(Transform child in playInstructions)
		{
			gameStuff.Add(child);
			child.gameObject.SetActive (false);
		}




	}

	public void RemoveStartInstructions () {
	



			StartCoroutine(ToggleInstructions("start","off"));
			StartCoroutine(ToggleInstructions("game","on"));

		
		}
	
		
	




	IEnumerator ToggleInstructions(string instruxType,string mode){

		yield return StartCoroutine(WaitAndPrint(0.0F));


		if (instruxType =="start"){
		foreach(Transform ui1 in startStuff)
			
		{
			if (mode == "off"){
			ui1.gameObject.SetActive (false);
			} 
			else if (mode =="on"){
			ui1.gameObject.SetActive (true);
			}
			
		}
		}

		else if (instruxType =="game"){

		foreach(Transform ui1 in gameStuff)
			
		{
				if (mode == "off"){
					ui1.gameObject.SetActive (false);

				} 
				else if (mode =="on"){
					ui1.gameObject.SetActive (true);
				}
			
		}
		
		}
	
	}



	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
//		print("WaitAndPrint " + Time.time);
	}


}
