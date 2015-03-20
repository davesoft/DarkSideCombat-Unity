using UnityEngine;
using System.Collections;

public class RobotAttack : MonoBehaviour {

	public string Description;
	public GameObject hostRobot;
	public RobotController hostController;
	public float damage = 0;
	public float range = 0;
	public float equipDefBonus = 0;
	public bool unequipAfterUse=false;
	public int busyFor=0;
	public float refireDelay=0;
	public bool _equiped = false;
	public bool equiped {
		get{return this._equiped;}
		set{
			if (value & !this._equiped){
				//fresh equip
				this.hostController.def+=this.equipDefBonus;
			}
			if (!value & this._equiped){
				//fresh unequip
				this.hostController.def-=this.equipDefBonus;
			}
			this._equiped=value;

		}
	}


	public Sprite image;


	// Use this for initialization
	void Start () {
		this.hostRobot = this.gameObject;
		this.hostController = this.hostRobot.GetComponent<RobotController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void tryFire()
	{
		if (!this.hostController.Busy)
		{
			
			if (this.damage > 0 & this.equiped)
			{
				//anyone around to fight?
				foreach(GameObject g in GameObject.FindGameObjectsWithTag ("robot"))
				{
					if (g != this.gameObject)
					{
						if (Vector3.Distance ( this.transform.position,g.transform.position) < this.range)
						{
							//whack em!
							RobotController rc = g.GetComponent<RobotController> ();
							if (rc.playerControlled != this.hostController.playerControlled){
								this.hostController.Busy=true;
								this.hostController.busyFor+=this.busyFor;

								if (rc.def <= this.damage + this.hostController.atk)
								{
									rc.transform.position = rc.graveyard;// new Vector3(0,0,rc.transform.position.z);
									rc.Busy=false;
									rc.HeadingTo=new Vector3();
									if (this.unequipAfterUse) {this.equiped=false;}
									Debug.Log ("Yeah!");
									return;
								}
							}
							
						}
					}
					this.hostController.Busy=false;
				}
			}
		}

	}



}
