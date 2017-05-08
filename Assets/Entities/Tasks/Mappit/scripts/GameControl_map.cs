using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl_map : MonoBehaviour {


	public static string  selectedStoreName;
	public static Vector3 selectedStorePosition;
	public static Vector3 selectedStoreSize;
	public static List<Store> stores_all = new List<Store>();
	public static List<string> store_names = new List<string>();
	public static bool drawMode = true; 
	public static GameControl_map control;
	public static GetMapScore mapScore;
	public static float thresh = 8;
	public static string subjectID;
	public static int maxRounds = 2;

	void Awake () {
		if(control==null)
		{
			DontDestroyOnLoad(gameObject);
				control = this;
		}
		else if(control !=this)
		{
			Destroy(gameObject);
		}

	}

	void Start(){

		

	}


	public static float GetScore(){

		mapScore = new GetMapScore(stores_all);

		return mapScore.scoreTotal;

	}

	public  void GetID(){

		GameObject inputFieldGo = GameObject.Find("InputField_ID");
		InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
		subjectID = inputFieldCo.text;


	}


	public void NextModule(){
		Experiment1.LoadNextModule();
	}


	public void ReloadCurrentScene(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}


	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}


}


