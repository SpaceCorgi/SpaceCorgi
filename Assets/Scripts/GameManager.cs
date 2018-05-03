using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	#region Variavbles
	public int ShipHealth;
	public float Repair;
	public float CrackDrestructionRate;
	public float CrackHitPoints;
	public float CrackRepairByPunch;
	public float CrackRepairByWrench;

	public Text health;

	#endregion
	// Use this for initialization
	void Start () {
		ShipHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		health.text = ShipHealth.ToString();
		if (ShipHealth <= 0) {
			EndGame (false);
		} else if (ShipHealth > 100) {
			ShipHealth = 100;
		}
		
	}

	void EndGame(bool b){
		if (b) {
			print ("yay u win c: now pet doggo");
		} else {
			print ("nay you lose :c now pet doggo until u crash into sun");
		}
	}
}
