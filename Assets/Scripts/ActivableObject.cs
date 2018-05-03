using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableObject : MonoBehaviour {
	public bool isPowered;
	public bool hasSwitch;
	public bool switchOn;

	public Generator[] generators = new Generator[2];
	public Button button;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!generators [0].isPowered && !generators [1].isPowered) {
			isPowered = false;
		}

		if (isPowered) {
			if (hasSwitch) {
				if (button.switched) {
					foreach (Transform child in transform) {
						child.gameObject.SetActive (true);
					}
				} else {
					foreach (Transform child in transform) {
						child.gameObject.SetActive (false);
					}
				}
			} else {
				foreach (Transform child in transform) {
					child.gameObject.SetActive (true);
				}
			}
		} else {
			foreach (Transform child in transform) {
				child.gameObject.SetActive(false);
			}
		}
	}



}
