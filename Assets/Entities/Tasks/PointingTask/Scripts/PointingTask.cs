using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class PointingTask : MonoBehaviour {

	public Text question;
	private int index = 0;
	private int count;
	private bool nextTrial = true;
	private int numTrials = 28;

	public GameObject arrow;
	public GameObject compass;
	private Quaternion arrowStartRot;
	public float responseCoolDown = 1.0f;
	private string dataf;
	private StreamWriter newFile;

	void Start(){

        //Configure arrow heading
		arrowStartRot = arrow.transform.rotation; 

		//Get subject ID
		string playerID = PlayerPrefs.GetString("playerID");

		//Build output file path
		string appDir = Directory.GetCurrentDirectory();
		

		Directory.CreateDirectory(Application.dataPath + "/Data/" +  playerID);
		dataf = appDir + "/" + "Data" + "/" + playerID + "/"  + "test.txt";
		newFile = new StreamWriter(dataf,true);
		newFile.Close();
		//Check to see if data file exists. If not,create file
//		if (!File.Exists(dataf)){
//		File.Create(dataf);
//		}

		//Initiate overall index
		index = Experiment1.jrd_count;
		//Intial within block count
        count = 0;


	}


	void Update () {


		if(count<numTrials)
        {

			if(nextTrial)
			{
	
			
			    JRD curJRD = LoadJRDquestions.JRDlist[index];
	
			    question.text = curJRD.question;
	
			    if (Input.GetKeyDown(KeyCode.Return))
                {
			         StartCoroutine(SetupNextTrial());
			    
			    }
			else if (!nextTrial)
			{
				question.text = "";
			}
		    }
        }
		else{
		    
			Experiment1.jrd_count = index;
			Experiment1.LoadNextModule();
		}
	}


	IEnumerator SetupNextTrial()
	{
		print("next trial");
		nextTrial = false;
		index ++;
		count ++;
		LogData();
		compass.SetActive(false);

		yield return new WaitForSeconds(responseCoolDown);
		compass.SetActive(true);
		arrow.transform.rotation = arrowStartRot;
		nextTrial = true;

	}


	void LogData(){
		string line = index.ToString() + '\t' + question.text+ '\t' + arrow.transform.rotation + '\t' + '\n';
//		File.AppendAllText( dataf,line);
//		TextWriter tw = new StreamWriter(dataf);
//		tw.WriteLine(line);
//		tw.Close();

		print(dataf + ": " + line);
		

		newFile = new StreamWriter(dataf,true);
		newFile.WriteLine(line);
		newFile.Close();
	}

}
