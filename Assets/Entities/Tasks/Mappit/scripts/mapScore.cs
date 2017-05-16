using UnityEngine;
using System.Collections;
using System.IO;

public class mapScore : MonoBehaviour {
	GameObject winUI;
	GameObject loseUI;
	public StreamWriter newFile;

	void Awake(){
		 winUI = GameObject.Find("UI_mapscore_finished") as GameObject;
		 winUI.SetActive(false);
		 loseUI = GameObject.Find("UI_mapscore_try_again") as GameObject;
		 loseUI.SetActive(false);

 		Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/");
		newFile = new StreamWriter(Directory.GetCurrentDirectory()+"/data/"+PlayerPrefs.GetString("playerID") + "/" + PlayerPrefs.GetString("playerID") + "_map.txt",true);
		if (Experiment1.curModule == 0 && Experiment1.round_count == 1) {
			newFile.WriteLine ("time\tid\tblock\tattempt\tscore");
		}
		newFile.Close();



	}
	public void mapScoreUIswitch(){
		LogData();

		if(GameControl_map.GetScore() >= GameControl_map.thresh){
			winUI.SetActive(true);
		}
		else if(Experiment1.round_count == GameControl_map.maxRounds - 1){
			winUI.SetActive(true);
		}
		else
		{   
			Experiment1.round_count ++;
			print("Round: " + Experiment1.round_count);
			loseUI.SetActive(true);

		}

	}




	public void LogData(){
		// retrieve the subject ID, map drawing attempt for this block, and the score they got on this attempt... log it.
		string line = System.DateTime.Now.Ticks/100000 + "\t" + PlayerPrefs.GetString("playerID") + "\t" + Experiment1.blocknum + "\t" + Experiment1.round_count + "\t" + GameControl_map.GetScore();
		// ^^ NOTE: time is being printed in miliseconds. For RT in seconds (2 decimals), subtract two stamp values and divide by 100
		print (line);
		newFile = new StreamWriter(Directory.GetCurrentDirectory()+"/data/"+PlayerPrefs.GetString("playerID") + "/" + PlayerPrefs.GetString("playerID") + "_map.txt",true);
		newFile.WriteLine (line);
		newFile.Close();

	}


}
