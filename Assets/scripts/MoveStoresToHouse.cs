﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MoveStoresToHouse : MonoBehaviour {

//	private GameObject shops;
//	private GameObject house;
//	private Vector3 startPosition;
//	private Vector3 colliderSize;
//	private Collider collider;
//	public float spacing = 1.5f; //multiplier of store size
//
//	private List<Transform> storeTrans = new List<Transform>();
//
//
//
//	
//	public static IEnumerator Init(){
//		shops = GameObject.Find ("ShopsTrue");
//		house = GameObject.Find ("house");
//		foreach (Transform store in shops.transform) {
//			storeTrans.Add(store);
//
//		}
//		startPosition = house.transform.position;
//		StartCoroutine(CreateRooms());
//		yield return null;
//	}
//
//
//	IEnumerator CreateRooms(){
//
//
//		ShuffleList(storeTrans);
//
//
//		foreach (Transform store in storeTrans) {
//
//			GameObject storeRoom = Instantiate(store.gameObject) as GameObject;
//			storeRoom.name = store.name;
//			storeRoom.transform.SetParent(house.transform,true);
//			storeRoom.transform.position = startPosition;
//			storeRoom.transform.localEulerAngles = new Vector3(0f,90f,0f);
//			collider = storeRoom.gameObject.GetComponent<Collider>();
//			colliderSize = collider.bounds.size;
//			startPosition = new Vector3(startPosition.x,startPosition.y ,startPosition.z - (colliderSize.z*spacing));
//			yield return null;
//		
//		}
//
//		shops.SetActive (false);
//	}
//
//
//	void ShuffleList(List<Transform> alpha ) {
//		for (int i = 0; i < alpha.Count; i++) {
//			Transform temp = alpha[i];
//			int randomIndex = Random.Range(i, alpha.Count);
//			alpha[i] = alpha[randomIndex];
//			alpha[randomIndex] = temp;
//		}
//
//	}


}




