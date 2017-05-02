using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Experiment1 : MonoBehaviour {

//	static Experiment1 instance = null;

	public List<string> tasks = new List<string>();
	public int numRuns = 2;
	static public int curModule = 0;
	public string guiScene;
	public string endScene;
	public bool gui = true;
	private static Experiment1 instance;
	static public List<string> blockList = new List<string>();
	static public List<string> runList = new List<string>();


	void Awake() {

		if (instance != null) {
			Destroy (gameObject);
			print("destroying game object");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			BuildBlockList();
			PlayerPrefs.SetString("playerID","test");
		
		}


	}



	// Use this for initialization
	void Start () {
		print(PlayerPrefs.GetFloat("playerID"));

  		   if(gui){
			SceneManager.LoadScene(guiScene);
		}
			
	}



	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
		print("load level" + name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextModule(){

		if( !(curModule == blockList.Count -1)){
		SceneManager.LoadScene(blockList[curModule]);
		print("loading module " +curModule + " " + blockList[curModule]);
		curModule ++;
		}
		else{

			LoadLevel(endScene);

		}
	}


	void BuildBlockList(){

		print("building block list");
		for(int run = 0; run < numRuns; run++)
		{
			foreach(string module in tasks){


				blockList.Add(module);

				string runName = run.ToString();
				runList.Add(runName);
			}
		}

	}

	void OnGUI(){

		if (GUILayout.Button("Debug-skip"))
			LoadNextModule();

	}


}
