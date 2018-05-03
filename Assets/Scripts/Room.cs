using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	bool isLit;
	// Use this for initialization
	void Start () {
		isLit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D c){
		if (c.gameObject.tag == "Fire") {
			isLit = true;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if (c.gameObject.tag == "Fire") {
			isLit = false;
		}
	}
}
