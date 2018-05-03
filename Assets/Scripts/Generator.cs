using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public bool isPowered;
	WeakPoint weakpoint;
	// Use this for initialization
	void Start () {
		isPowered = true;
		weakpoint = gameObject.GetComponent (typeof(WeakPoint)) as WeakPoint;
	}
	
	// Update is called once per frame
	void Update () {
		if (weakpoint.isBroken) {
			isPowered = false;
		} else {
			isPowered = true;
		}
	}
}
