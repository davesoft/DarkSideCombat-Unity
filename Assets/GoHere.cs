using UnityEngine;
using System.Collections;

public class GoHere : MonoBehaviour {
	public SpawnGrid gc;// = GameObject.Find ("TileMan").GetComponent<SpawnGrid> ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		//Debug.Log ("yeah!");

		if (this.gc.isPlayersTurn) {
			this.gc.SelectedRobot.GetComponent<RobotController> ().HeadingTo = this.gameObject.transform.position;       
		}


	}

}
