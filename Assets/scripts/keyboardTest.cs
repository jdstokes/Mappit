using UnityEngine;
using System.Collections;

public class keyboardTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
