using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateStoreUIs : MonoBehaviour {

	private GameObject shops;
	private GameObject ui_all;
	public  Image storeName;

	
	void Start(){
		shops = GameObject.Find ("Shops");
		ui_all = GameObject.Find ("UI_other");
		CreateUIs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void CreateUIs(){

		Collider collider = gameObject.GetComponent<Collider> (); 


	
		foreach (Transform store in shops.transform) {
	
			collider = store.gameObject.GetComponent<Collider>();

			Rect rect = BoundsToScreenRect(collider.bounds);
			Image storeUI = Instantiate(storeName) as Image;
			RectTransform rectTransform = storeUI.GetComponent<RectTransform>();
			storeUI.name = store.name + "_ui";
			storeUI.transform.SetParent(ui_all.transform,true);
			storeUI.rectTransform.position = Camera.main.WorldToScreenPoint(collider.bounds.center);
//			Vector3 size = Camera.main.WorldToScreenPoint(collider.bounds.size);
			storeUI.rectTransform.sizeDelta= new Vector2(rect.width,rect.height);
			storeUI.rectTransform.localScale = new Vector3(1f,1f,1.0f);
			storeUI.gameObject.SetActive(false);

		}
		
	}



	public Rect BoundsToScreenRect(Bounds bounds)
	{
		// Get mesh origin and farthest extent (this works best with simple convex meshes)
		Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, 0f, bounds.max.z));
		Vector3 extent = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, 0f , bounds.min.z));

		// Create rect in screen space and return - does not account for camera perspective
		return new Rect(origin.x, Screen.height - origin.y, extent.x - origin.x, origin.y - extent.y);
	}

}
