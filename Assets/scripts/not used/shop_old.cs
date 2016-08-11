//using UnityEngine;
//using System.Collections;
//
//public class shop_old : MonoBehaviour {
//
//	private Vector3 screenPoint;
//	private Vector3 offset;
//	public float gridSize;
//	public string storeName;
//	public Vector3 curScreenPoint;
//	public Vector3 curPosition;
//	public Vector3 startingPosition;
//	public Vector3 endingPosition;
//	public bool canMove = false;
//
//	
//	public Transform realShop;
//	public Transform testShop;
//
//	public Renderer rend;
//	private Vector3 velocity = Vector3.zero;
//
//	private bool mouseDown = false;
//	private bool startCheck = false;
//	private
//	void Start() {
//		rend = GetComponent<Renderer>();
//
////
////		realShop  = transform.Find("real");
////		testShop = transform.Find("fake");
//
//	}
//	void Update(){
//		if (Physics.Raycast (transform.position, offset, 20)) {
//			print ("There is something in front of the object!");
//			contact = true;
//		} else {
//			contact = false;
//		}
//
//	}

//void OnMouseDown(){
//		canMove = true;
//		print("onmousedown");
//	}
//
//void OnMouseUp(){
//
//		canMove = false;
//	}
//
//void Update(){
//
//
//		if (goahead) {
//
//			realShop.position=Vector3.SmoothDamp(testShop.position, realShop.position, ref  velocity, .02F);
//
//		}
//
//
//}
//	
//
//void OnMouseDown(){
//
//		mouseDown = true;
//		startingPosition = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//
//}
//
//void OnMouseUp(){
//
//	mouseDown = false;
//	startCheck = true;
//		endingPosition = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//
//}
//void OnMouseDrag(){  
//		if (mouseDown) {
//			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//			offset = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) - gameObject.transform.position;
//		}
//
//	}
//
//void OnCollisionEnter(Collision collision) {
//
//			shop.position = Vector3.SmoothDamp (testShop.position, realShop.position, ref  velocity, .02F);
//		
//}
//	
////void Update(){
////
////		if (badMove) {
////			gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position,endingPosition , ref  velocity, .02F);
////			badMove = false;
////		}
////
////
////}
//
//
//
//
////IEnumerator CheckForCollision (Transform target)
////{
////	while(Vector3.Distance(transform.position, target.position) > 0.05f)
////	{
////		transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
////		
////		yield return null;
////	}
////	
////	print("Reached the target.");
////	
////	yield return new WaitForSeconds(3f);
////	
////	print("MyCoroutine is now finished.");
////}
//
//
//
//
//
//
//
//	
//}
