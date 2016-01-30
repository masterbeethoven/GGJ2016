using UnityEngine;
using System.Collections.Generic;

public class WindowScript : MonoBehaviour {

	public Transform prefab;
	public bool spriteActive = true;
	public int prefabCount; 
	int prefabLimit = 10;
	public static List <GameObject> prefabs = new List<GameObject>();

	public List <KeyCode> correctSeq = new List<KeyCode> {KeyCode.A, KeyCode.B, KeyCode.C};
	public List <KeyCode> playerSeq = new List <KeyCode> (); //calling constructor, list of keycodes 

	// Use this for initialization
	void Start () {
		Object[] objects = Resources.LoadAll("Prefabs", typeof(GameObject));
		foreach (GameObject obj in objects) {    
			GameObject gameObj = (GameObject)obj;
			prefabs.Add(gameObj);
		}
	}

	// Update is called once per frame
	void Update () {

		Vector3 pos = new Vector3(Random.value, Random.value, 10f);
		pos = Camera.main.ViewportToWorldPoint(pos);

		if (Input.GetKeyDown("up") && this.spriteActive) {
			prefabCount ++;
			Debug.Log(prefabCount);

			if (!(prefabCount >= prefabLimit)) {
				Instantiate (prefab, pos, Quaternion.identity);
				this.spriteActive = false;
			}
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

	void OnGUI() {
		if (spriteActive) {
			Vector3 pos = new Vector3 (Random.value, Random.value, 10f);
			pos = Camera.main.ViewportToWorldPoint (pos);

			if (Event.current.keyCode != KeyCode.None && Event.current.type == EventType.KeyDown) {
				playerSeq.Add (Event.current.keyCode);
				if (!(playerSeq [playerSeq.Count - 1] == correctSeq [playerSeq.Count - 1])) {
					Debug.Log ("wrong");
					playerSeq.Clear ();
				} else {
					if (playerSeq.Count == correctSeq.Count) {
						playerSeq.Clear ();
						Instantiate (prefab, pos, Quaternion.identity);
						this.spriteActive = false;
					}
				}
			}
		}
	}
}
