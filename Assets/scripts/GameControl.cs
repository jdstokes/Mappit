using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


	public static string  selectedStoreName;
	public static Vector3 selectedStorePosition;
	public static Vector3 selectedStoreSize;
	public static List<Store> stores_all = new List<Store>();
	public static List<string> store_names = new List<string>();
	public static bool drawMode = true; 
	public static GameControl control;
	public static GetMapScore mapScore;
	public static float thresh = 50f;

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


public static float GetScore(){

		mapScore = new GetMapScore(stores_all);

		return mapScore.score;

}

	

}
