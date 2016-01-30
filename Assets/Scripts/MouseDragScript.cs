using UnityEngine;
using System.Collections;

public class MouseDragScript : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	private float _lockedYPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseDrag();
//		OnMouseDown();
//		OnMouseUp();
	}
		
//	void OnMouseDown(){
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
//		Cursor.visible = false;
//	}

	void OnMouseDrag() {
		if (Input.GetMouseButton(0)) {
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}

//	void OnMouseUp(){
//		Cursor.visible = true;
//	}
}
