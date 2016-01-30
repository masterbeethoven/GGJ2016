using UnityEngine;
using System.Collections;

public class WindowScript : MonoBehaviour {
	public Transform prefab;
	bool spriteActive = true;
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
		
	
	}
}
