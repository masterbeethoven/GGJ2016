using UnityEngine;
using System.Collections;

public class WindowScript : MonoBehaviour {
	public Transform prefab;
	public bool spriteActive = true;
	int prefabLimit = 10;
	public int prefabCount; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("up") && this.spriteActive) {
			prefabCount ++;
			Debug.Log(prefabCount);

			Vector3 pos = new Vector3(Random.value, Random.value, 4.39f);
			pos = Camera.main.ViewportToWorldPoint(pos);
			Instantiate(prefab, pos, Quaternion.identity);
			this.spriteActive = false;

		}

		if (prefabCount >=prefabLimit){
			Debug.Log ("stop lol");
			this.spriteActive = false; 
			//CancelInvoke("prefab");
		}
	
		OnMouseDrag();

	}

	void OnMouseDrag() {
		
		if (Input.GetMouseButton(0) && this.spriteActive) {
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
			transform.position = curPosition;
		}

	}
}
