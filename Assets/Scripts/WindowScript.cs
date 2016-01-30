using UnityEngine;
using System.Collections;

public class WindowScript : MonoBehaviour {
	public Transform prefab;
	bool spriteActive = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("up") && this.spriteActive) {
			//print("up arrow key is held down");

			Vector3 pos = new Vector3(Random.value, Random.value, 4.39f);
			pos = Camera.main.ViewportToWorldPoint(pos);
			Instantiate(prefab, pos, Quaternion.identity);
			this.spriteActive = false;
		}
		
	
	}
}
