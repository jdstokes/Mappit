using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeText : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
	    
		text = GetComponent<Text>();
		text.canvasRenderer.SetAlpha( 0.0f );
		text.CrossFadeAlpha(1.0f,.5f,false);
	}
	

}
