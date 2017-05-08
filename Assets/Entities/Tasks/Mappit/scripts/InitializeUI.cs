using UnityEngine;
using System.Collections;

public class InitializeUI : MonoBehaviour {
	GameObject ui_ID;
	GameObject ui_learn;


	void Awake(){
		ui_ID = GameObject.Find("SubjectID") as GameObject;
		ui_ID.SetActive(false);
		ui_learn = GameObject.Find("Instructions") as GameObject;
		ui_learn.SetActive(false);
	}
	void Start () {

		if (GameControl_map.subjectID == null){

			ui_ID.SetActive(true);

		}
		else {

			ui_learn.SetActive(true);



		}
	
	}

}
