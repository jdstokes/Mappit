using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GetMapScore : MonoBehaviour {

//	public float scoreDist;
	public int scoreTotal = 0;

	public GetMapScore(List<Store> store_list){
		float positionScoreMap = 0;
//		float rotationScoreMap = 0;
		float positionScoreBase = 0;
//		float rotationScoreBase = 0;
		int numStores = store_list.Count;

	foreach(Store store in store_list){

			positionScoreBase += store.position_distance_base.magnitude;
		    positionScoreMap  += store.position_distance_map.magnitude;

			if((store.position_map - store.position_true).magnitude < 1){   //store.position_map == store.position_true
				scoreTotal++;
			}
					
	}

	
//		positionScoreMap  /= numStores;
//
//		scoreDist = (1 - positionScoreMap/positionScoreBase)*100;
}

}

