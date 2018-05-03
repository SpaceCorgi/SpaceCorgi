using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour {
	#region Variables
	public GameManager gameManager;
	float repair;
	float crackDestructionRate;
	float crackHitPoints;
	float crackRepairByPunch;
	float crackRepairByWrench;

	float currentHitPoints;
	#endregion
	// Use this for initialization
	void Start () {
		repair = gameManager.Repair;
		crackDestructionRate = gameManager.CrackDrestructionRate;
		crackHitPoints = gameManager.CrackHitPoints;
		crackRepairByPunch = gameManager.CrackRepairByPunch;
		crackRepairByWrench = gameManager.CrackRepairByWrench;

		currentHitPoints = 0;
		StartCoroutine (DamageShip());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHitPoints >= crackHitPoints) {
			gameManager.ShipHealth += (int)repair;
			Destroy (gameObject);
		}
	}

	IEnumerator DamageShip(){
		while (true) {
			yield return new WaitForSeconds (crackDestructionRate);
			gameManager.ShipHealth -= 1;
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
