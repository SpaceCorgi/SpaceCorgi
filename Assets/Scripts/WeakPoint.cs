using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {
	public int hitPoints;
	public bool isBroken;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hitPoints <= 0 && !isBroken) {
			isBroken = true;
			Crack cr = gameObject.AddComponent<Crack>() as Crack;
		}
		if (isBroken) {
			
		}
	}
}
