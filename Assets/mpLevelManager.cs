using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mpLevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadNextModule(){
		SceneManager.LoadScene(Experiment1.blockList[Experiment1.curModule]);
		print("loading module " +Experiment1.curModule + " " + Experiment1.blockList[Experiment1.curModule]);

	
		Experiment1.curModule ++;
	}



	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
