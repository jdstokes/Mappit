using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

 public class LoadJRDquestions : MonoBehaviour {


	public static List<JRD> JRDlist = new List<JRD>();

	void Awake () 
    {


		TextAsset textsText = Resources.Load(PlayerPrefs.GetString("playerID"))  as TextAsset;
		
		string[] parts = textsText.text.Trim().Split(new char[] { '\r','\n' });
		int cnt = 0;

		foreach(string line in parts){
			cnt ++;
		    if (line.Trim().Length > 0) JRDlist.Add(new JRD(line,cnt));

		}


    }
}
