using UnityEngine;
using System.Collections;

public class mapScore : MonoBehaviour {
	GameObject winUI;
	GameObject loseUI;

	void Awake(){
		 winUI = GameObject.Find("UI_mapscore_finished") as GameObject;
		 winUI.SetActive(false);
		 loseUI = GameObject.Find("UI_mapscore_try_again") as GameObject;
		 loseUI.SetActive(false);
	}
	public void mapScoreUIswitch(){
		if(GameControl.GetScore() > GameControl.thresh){
			winUI.SetActive(true);

		}
		else
		{
			loseUI.SetActive(true);

		}

	}
}
