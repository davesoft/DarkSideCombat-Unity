﻿using UnityEngine;
using System.Collections;

public class PickSlot3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		RobotController rc = GameObject.Find ("TileMan").GetComponent<SpawnGrid> ().SelectedRobot.GetComponent<RobotController> ();
		rc.slot1.equiped = false;
		rc.slot2.equiped = false;
		rc.slot3.equiped = true;
		
	}
}
