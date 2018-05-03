using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	#region Variables

	public GameObject connectedItem;
	public bool switched;

	#endregion

	void Start () {
		switched = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.name == "Punch") {
			if (switched) {
				switched = false;
			} else {
				switched = true;
			}
		}
	}
}

/*	if (connectedItem.activeSelf) {
connectedItem.SetActive (false);
} else {
	connectedItem.SetActive(true);
}*/