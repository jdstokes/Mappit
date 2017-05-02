using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class cameraMove : MonoBehaviour {
//
	public Camera camera;
	public Transform shops;
	private List<Transform> storeLocations = new List<Transform>();
	public void StartTour(){
		StartCoroutine(Tour());
	}


	IEnumerator Tour() {
		print ("tour check again");
		Vector3 startPosition = camera.transform.position;
		Vector3 newPosition = new Vector3();
		float startSize = camera.orthographicSize;
		print("Starting " + Time.time);
		yield return StartCoroutine(WaitAndPrint(2.0F));
		print("Done " + Time.time);

		foreach(Transform child in shops)
					{
						storeLocations.Add(child);
						print (child.position);
			newPosition = new Vector3(child.position.x,camera.transform.position.y,child.position.z);
			yield return StartCoroutine(LerpToPosition(camera, 3.0f,newPosition));
			yield return StartCoroutine(Zoom(camera, 2.0f,10));
			yield return StartCoroutine(WaitAndPrint(1.0F));
			yield return StartCoroutine(Zoom(camera, 2.0f,50));
			

				
					}
					yield return StartCoroutine(LerpToPosition(camera, 3.0f,startPosition));
					yield return StartCoroutine(Zoom(camera, 2.0f,startSize));
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		print("WaitAndPrint " + Time.time);
	}


	IEnumerator LerpToPosition(Camera moveObject, float lerpSpeed, Vector3 newPosition)
	{    

		float t = 0.0f;
		Vector3 startingPos = moveObject.transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);
			
			moveObject.transform.position = Vector3.Lerp(startingPos, newPosition, t);
			yield return 0;
		}    
	}

	IEnumerator Zoom(Camera moveObject, float lerpSpeed, float newSize)
	{    
		
		float t = 0.0f;
		float startingSize = camera.orthographicSize;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);
			camera.orthographicSize = Mathf.Lerp(startingSize, newSize, t);

			yield return 0;
		}    
	}


}