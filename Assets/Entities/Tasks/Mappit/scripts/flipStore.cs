using UnityEngine;
using System.Collections;

public class flipStore : MonoBehaviour {
	GameObject curStore;

	public void rotateStoreRight(){

		if(MapDraw.store_selected!= null)
		{
		GameObject curStore = GameObject.Find(MapDraw.store_selected);

//		curStore.transform.Rotate(Vector3.up,90);
			print ("flip " + curStore.transform.localEulerAngles);
			Vector3 temp = curStore.transform.localEulerAngles;

			if(Mathf.Floor (temp.y) == 90){

				temp.y =0;

			}
			else if(Mathf.Floor (temp.y) == 0){
				temp.y =90;
			}

			curStore.transform.localEulerAngles = temp;

	}



	}
}
