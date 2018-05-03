using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour {
	#region Variables
	public GameObject gameManager;
	GameManager gm;
	float repair;
	float crackDestructionRate;
	float crackHitPoints;
	float crackRepairByPunch;
	float crackRepairByWrench;

	float currentHitPoints;
	#endregion
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
		gm = gameManager.GetComponent<GameManager>() as GameManager;

		repair = gm.Repair;
		crackDestructionRate = gm.CrackDrestructionRate;
		crackHitPoints = gm.CrackHitPoints;
		crackRepairByPunch = gm.CrackRepairByPunch;
		crackRepairByWrench = gm.CrackRepairByWrench;

		currentHitPoints = 0;
		StartCoroutine (DamageShip());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHitPoints >= crackHitPoints) {
			gm.ShipHealth += (int)repair;
			Destroy (gameObject);
		}
	}

	IEnumerator DamageShip(){
		while (true) {
			yield return new WaitForSeconds (crackDestructionRate);
			gm.ShipHealth -= 1;
		}
	}


	void OnTriggerEnter2D(Collider2D c){
		print (c.name);
		if (c.gameObject.name == "Punch") {
			print (this.currentHitPoints+"/"+crackHitPoints);
			currentHitPoints += crackRepairByPunch;
		}
	}
}
