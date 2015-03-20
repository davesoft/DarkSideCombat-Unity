using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

	public bool playerControlled = true;
	public Vector3 graveyard=new Vector3();
	public float atk = 0;
	public float def = 0;
	//public float meleeRange = 0;

	public RobotAttack slot1;
	public RobotAttack slot2;
	public RobotAttack slot3;

	public int busyFor = 0;
	public GameObject busyIcon;
	public Vector3 _headingTo;
	public Vector3 HeadingTo {
		get {
			return _headingTo;
		}
		set {
			if (!this._busy ){
				this._headingTo = value;
			}
		}
	}

	public float distanceFrom=0.25f;
	public float speed=0.01f;
	private bool _busy = false;

	public bool Busy {
		get {
			return _busy;
		}
		set {
			_busy = value;
			if (busyIcon != null){busyIcon.GetComponent<SpriteRenderer>().enabled=value;}
		}
	}

	// Use this for initialization
	void Start () {
		if (this.playerControlled) {
			this.OnMouseUp ();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (this._headingTo != null)
		{
			//am i close?
			if (Vector3.Distance (this.transform.position,this._headingTo) > distanceFrom)
			{
				Busy=true;
				this.transform.position = Vector3.MoveTowards (this.transform.position,this._headingTo,speed);
			} else {
				Busy=false;
				if (this.slot1.equiped) {this.slot1.tryFire ();}
				if (this.slot2.equiped) {this.slot2.tryFire ();}
				if (this.slot3.equiped) {this.slot3.tryFire ();}
				this.busyFor-=1;
				this.Busy=(this.busyFor>0);


			}
		}
	}

	void OnMouseUp()
	{

		if (this.playerControlled) {
			Debug.Log (this.name);
			GameObject.Find ("TileMan").GetComponent<SpawnGrid> ().SelectedRobot = this.gameObject;
			GameObject.Find ("SpeedSlider").GetComponent<UnityEngine.UI.Slider> ().value = this.speed;
			GameObject.Find ("AtkSlider").GetComponent<UnityEngine.UI.Slider> ().value = this.atk;
			GameObject.Find ("Main Camera").transform.parent = this.gameObject.transform;
			GameObject.Find ("Main Camera").transform.position =  new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,-10.0f);
			GameObject.Find ("RobotName").GetComponent<UnityEngine.UI.Text> ().text = this.name;

			GameObject.Find ("btnSlot1").GetComponent<UnityEngine.UI.Image> ().sprite = this.slot1.image;
			GameObject.Find ("btnSlot2").GetComponent<UnityEngine.UI.Image> ().sprite = this.slot2.image;
			GameObject.Find ("btnSlot3").GetComponent<UnityEngine.UI.Image> ().sprite = this.slot3.image;
		}

	}





}
