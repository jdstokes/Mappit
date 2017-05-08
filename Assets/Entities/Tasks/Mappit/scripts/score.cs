using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
	
	Text txt;
	float score2print;
	
	// Use this for initialization
	void Start(){
		score2print = GameControl_map.GetScore();
    	txt = gameObject.GetComponent<Text>(); 
		txt.text="Score : " + score2print.ToString ("F0") + " correct";

	}
	
	 
}