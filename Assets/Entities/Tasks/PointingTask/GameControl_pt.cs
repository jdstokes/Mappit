using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl_pt : MonoBehaviour {


	public void LoadLevel(string name){
		
		SceneManager.LoadScene(name);
		print("load level" + name);
	}
}
