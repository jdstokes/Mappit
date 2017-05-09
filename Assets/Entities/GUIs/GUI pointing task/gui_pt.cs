using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class gui_pt : MonoBehaviour {

	public static string subjectID;
	public string studyCode = "s";
	public Text warning;
	private bool checkID = false;
	public Button start;
	public Button reset;
	private GameObject inputFieldID;

	// Use this for initialization
	void Start () {

		//Disable start button
		start.gameObject.SetActive(false);
		reset.gameObject.SetActive(false);
		//Initialize ID input filed
		inputFieldID = GameObject.Find("inputField_ID");

	
	}
	
	// Update is called once per frame
	void Update () {

		if(checkID){
			//Launch start button
			start.gameObject.SetActive(true);
			reset.gameObject.SetActive(true);
			InputField inputFieldCo = inputFieldID.GetComponent<InputField>();
			inputFieldCo.enabled = false;

		}
	
	
	}




public void GetID(){

		InputField inputFieldCo = inputFieldID.GetComponent<InputField>();
	    subjectID = inputFieldCo.text;

	
}

public void CheckID(){

	string appDir = Directory.GetCurrentDirectory();
    TextAsset textsText = Resources.Load(PlayerPrefs.GetString("playerID"))  as TextAsset;      

	if(!textsText){
			print(PlayerPrefs.GetString("playerID")+ ".txt does not exist");
			warning.text = "Incorrect ID";

	}
	else if (!Directory.Exists(appDir + "/data/" + studyCode + subjectID)) {
		    Directory.CreateDirectory(appDir + "/data/" + studyCode + subjectID);
			warning.text = "";
			print(subjectID + " data directory created");
			PlayerPrefs.SetString("playerID",studyCode + subjectID);
			checkID = true;
	}
	else
		{		
			warning.text = subjectID + " already exists";
			print(subjectID + " already exists");
	}


	
}

	public void ResetID(){

		InputField inputFieldCo = inputFieldID.GetComponent<InputField>();
		start.gameObject.SetActive(false);
		reset.gameObject.SetActive(false);
		inputFieldCo.enabled = true;
		inputFieldCo.text ="";
		subjectID = "";

		checkID = false;

	}


	public void StartTask(){
		Experiment1.StartTask();

	}


}