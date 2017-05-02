using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

 public class LoadJRDquestions : MonoBehaviour {


	public static List<JRD> JRDlist = new List<JRD>();

	void Awake () {
		string appDir = Directory.GetCurrentDirectory();

		StreamReader reader=  new StreamReader(Application.dataPath + "/textFiles/" + PlayerPrefs.GetString("playerID") + ".txt");

		int cnt =0;
		while(!reader.EndOfStream)
		{
			string curLine = reader.ReadLine();
			if(!string.IsNullOrEmpty(curLine)){
			cnt++;
//			print(curLine);
			JRDlist.Add(new JRD(curLine,cnt));
			}

		}

		reader.Close();
	}



}
