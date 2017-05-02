using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class Task : MonoBehaviour {

	public Text question;
	private int index = 0;
	private bool nextTrial = true;
	public GameObject arrow;
	public GameObject compass;
	private Quaternion arrowStartRot;
	public float responseCoolDown = 1.0f;
	private string dataf;


	void Start(){

		arrowStartRot = arrow.transform.rotation; //Configure arrow heading

		//Get subject ID
		string playerID = PlayerPrefs.GetString("playerID");

		//Build output file path
		string appDir = Directory.GetCurrentDirectory();
		dataf = appDir + "/" + "Data" + "/" + playerID + "/"  + "test.txt";

		//Check to see if data file exists. If not,create file
		if (!File.Exists(dataf)){
		File.Create( dataf);
		}
		

	}


	void Update () {

		if(nextTrial)
		{
		JRD curJRD = LoadJRDquestions.JRDlist[index];
		question.text = curJRD.question;


		if (Input.GetKeyDown(KeyCode.Return)){



				StartCoroutine(SetupNextTrial());


		}

		}
		else if (!nextTrial)
		{
			question.text = "";

		}

		
	
		}


	IEnumerator SetupNextTrial()
	{
		print("next trial");
		nextTrial = false;
		index ++;
		LogData();
		compass.SetActive(false);

		yield return new WaitForSeconds(responseCoolDown);
		compass.SetActive(true);
		arrow.transform.rotation = arrowStartRot;
		nextTrial = true;

	}


	void LogData(){

		string line = index.ToString() + '\t' + question.text+ '\t' + arrow.transform.rotation + '\t' + '\n';
		File.AppendAllText( dataf,line);
		

	}

}
