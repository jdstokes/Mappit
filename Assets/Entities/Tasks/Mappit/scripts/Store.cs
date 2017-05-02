using UnityEngine;
using System.Collections;


public class Store : MonoBehaviour {

	public string name;
	public Vector3 position_true;
	public Vector3 rotation_true;
	public Vector3 position_base;
	public Vector3 rotation_base;
	public Vector3 position_map;
	public Vector3 rotation_map;
	public Vector3 position_distance_base;
	public Vector3 position_distance_map;


	public Store(string newName, Vector3 newPosition, Vector3 newRotation)
	{
		name = newName;
		newPosition = new Vector3(newPosition.x,0f,newPosition.z); 

		position_true = newPosition;
		rotation_true = newRotation;

	}

	public void SetBaseLocation(Store store, Vector3 newPosition, Vector3 newRotation){
		newPosition = new Vector3(newPosition.x,0f,newPosition.z); 
		store.position_base = newPosition;
		store.rotation_base = newRotation;
		store.position_distance_base =  position_true - position_base;


	}

	public void SetMapLocation(Store store, Vector3 newPosition, Vector3 newRotation){
		newPosition = new Vector3(newPosition.x,0f,newPosition.z); 
		store.position_map = newPosition;
		store.rotation_map = newRotation;
		store.position_distance_map =  position_true - position_map;


	}
}
