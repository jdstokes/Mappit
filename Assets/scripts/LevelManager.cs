using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel+1);
	}



	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			print ("space!");
			Application.LoadLevel (Application.loadedLevel + 1);
		} else if (Input.GetKeyDown (KeyCode.Backspace)) {
			print ("delete!");
			
			Application.LoadLevel (Application.loadedLevel - 1);
		}

	}




}
