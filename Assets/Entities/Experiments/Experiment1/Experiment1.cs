using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Experiment1 : MonoBehaviour {

//	static Experiment1 instance = null;
	public List<string> tasks = new List<string>();
	private int numRuns = 20;
	static public int curModule = 0;
	public string guiScene;
	public bool gui = true;
	public bool debug_mode;
	private static Experiment1 instance;

	static public List<string> blockList = new List<string>();
	static public List<string> runList = new List<string>();
	static public int jrd_count = 0;
	static public int round_count = 1;
	static public int old_round_count;
	//MJS - 5/15/2017: add variable to count whole blocks
	public static int blocknum = 1; // updated in PointingTask.cs and logged in mapScore.cs

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
  		   if(gui){
			SceneManager.LoadScene(guiScene);
		}
			
	}


	static public void StartTask()
	{
	
		SceneManager.LoadScene(blockList[curModule]);
		print("loading module " +curModule + " " + blockList[curModule]);
	
	}

	static public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
		print("load level" + name);
	}

	static public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	static public void LoadNextModule(){

		if( !(curModule == blockList.Count -1)){
		old_round_count = round_count;
		round_count = 1;
		curModule ++;
		SceneManager.LoadScene(blockList[curModule]);
		print("loading module " +curModule + " " + blockList[curModule]);
		}
		else{

			LoadLevel("endScene");

		}
	}

	public void ReloadCurrentScene(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
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

		if(debug_mode){
		if (GUILayout.Button("Debug-skip"))
			LoadNextModule();

	    }
    }


}
