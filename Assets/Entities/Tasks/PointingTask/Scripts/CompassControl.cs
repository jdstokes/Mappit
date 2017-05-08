using UnityEngine;
using System.Collections;

public class CompassControl : MonoBehaviour {

	public float speed = 50.0f; //adjustable Speed variable


	GameObject compass;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.back* Time.deltaTime*speed);
			//transform.position += new Vector3(-speed,0,0);//Would also work
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(Vector3.forward* Time.deltaTime*speed);
		}


	
	}
}
