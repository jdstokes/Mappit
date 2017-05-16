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

	//MJS (5/15/2017) - Cooldown timer for JRD responses
	private bool inCooldown = false; //bool to indicate cooldown timer for response button
	public int cooldownTime; //input for a JRD response cooldown timer

	private long tmpJRDstartTime;



	void Awake () {
		StartCoroutine (responseCooldown ()); //MJS start the cooldown timer
		tmpJRDstartTime = System.DateTime.Now.Ticks / 100000;
	}



	void Start(){

        //Configure arrow heading
		arrowStartRot = arrow.transform.rotation; 

		//Get subject ID
		string playerID = PlayerPrefs.GetString("playerID");

		//Build output file path
		string appDir = Directory.GetCurrentDirectory();
		

		Directory.CreateDirectory(Application.dataPath + "/Data/" +  playerID);
		dataf = appDir + "/" + "Data" + "/" + playerID + "/"  + playerID + "_jrd.txt";
		newFile = new StreamWriter(dataf,true);
		if (Experiment1.curModule == 1 && index == 0) {
			newFile.WriteLine ("startTime\tendTime\tid\tblock\ttrial\tquestion\tresponse");
			// \taligned"); // removed as this is actually just logging how many attempts from the prior map task
		}
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
	
				if (!inCooldown && Input.GetKeyDown(KeyCode.Return)) //MJS-5/15/2017: added !inCooldown &&
                {
			         StartCoroutine(SetupNextTrial());
					 question.text = "";
			    
			    }
//			else if (!nextTrial)
//			{
////				question.text = "";
//			}
		    }
        }
		else{
		    
			Experiment1.jrd_count = index;
			Experiment1.blocknum++;
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
		StartCoroutine (responseCooldown ()); //MJS start the cooldown timer
		tmpJRDstartTime = System.DateTime.Now.Ticks / 100000;

	}


	void LogData(){
		string line = tmpJRDstartTime + "\t" + System.DateTime.Now.Ticks / 100000 + "\t" + PlayerPrefs.GetString ("playerID") + "\t" + Experiment1.blocknum + "\t" + index.ToString () + '\t' + question.text + '\t' + arrow.transform.localRotation.eulerAngles + '\t';
			//+ Experiment1.old_round_count; //removed as this is actually just logging how many attempts from the prior map task
//		File.AppendAllText( dataf,line);
//		TextWriter tw = new StreamWriter(dataf);
//		tw.WriteLine(line);
//		tw.Close();

		print(dataf + ": " + line);
		

		newFile = new StreamWriter(dataf,true);
		newFile.WriteLine(line);
		newFile.Close();
	}

	//MJS-5/15/2017: Cooldown function to be called to turn off response button for 3 seconds
	IEnumerator responseCooldown() {
		inCooldown = true;
		yield return new WaitForSeconds(cooldownTime);
		inCooldown = false;
	}

}
