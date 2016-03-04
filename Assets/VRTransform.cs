using UnityEngine;
using System.Collections;




public class VRTransform : MonoBehaviour {

	public Transform VRcamera;
	void Update () {
//		transform.localRotation = InputTracking.GetLocalRotation(VRcamera) * Quaternion.Euler(45, 0, 0);
		transform.localRotation = VRcamera.localRotation * Quaternion.Euler(45, 0, 0);

	} 
}
