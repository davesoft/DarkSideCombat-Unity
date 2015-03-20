using UnityEngine;
using System.Collections;

public class SpawnGrid : MonoBehaviour {

	public GameObject SelectedRobot;
	public bool isPlayersTurn = true;
	public int  turnTimeLeft =900;


	public void Slot1(){
		RobotController rc = this.SelectedRobot.GetComponent<RobotController> ();
		rc.slot1.equiped = true;
		rc.slot2.equiped = false;
		rc.slot3.equiped = false;
	}

	public void Slot2(){
		RobotController rc = this.SelectedRobot.GetComponent<RobotController> ();
		rc.slot1.equiped = false;
		rc.slot2.equiped = true;
		rc.slot3.equiped = false;
	}

	public void Slot3(){
		RobotController rc = this.SelectedRobot.GetComponent<RobotController> ();
		rc.slot1.equiped = false;
		rc.slot2.equiped = false;
		rc.slot3.equiped = true;
	}

	// Update is called once per frame
	void Update () {
		this.SelectedRobot.GetComponent<RobotController> ().speed = GameObject.Find("SpeedSlider").GetComponent<UnityEngine.UI.Slider>().value;	
		this.SelectedRobot.GetComponent<RobotController> ().atk = GameObject.Find("AtkSlider").GetComponent<UnityEngine.UI.Slider>().value;	
		this.turnTimeLeft -= 1;
		if (this.turnTimeLeft < 1) 
		{
			this.isPlayersTurn = !this.isPlayersTurn;
			this.turnTimeLeft=900;
		}
		GameObject.Find ("TicksLeft").GetComponent<UnityEngine.UI.Text> ().text = this.turnTimeLeft.ToString();  
	}

	// Use this for initialization
	void Start () {
		for (int x = 0; x<16; x++) {
			for (int y = 0; y<16; y++) {
				GameObject ng = new GameObject(x.ToString() + "," + y.ToString());
				ng.transform.position = new Vector3(x*0.65f,y*0.65f);
				ng.transform.SetParent (this.transform);
				ng.AddComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
				ng.GetComponent<SpriteRenderer>().sortingLayerName="Tiles";
				ng.AddComponent<BoxCollider2D>().isTrigger=true;
				ng.AddComponent<GoHere>().gc=this;

				ng.layer=0;
			}

		}
	}
	

}
