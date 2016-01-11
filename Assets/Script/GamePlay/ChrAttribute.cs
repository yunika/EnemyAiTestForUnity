using UnityEngine;
using System.Collections;

public class ChrAttribute : MonoBehaviour{ // used by Controller
	protected float fallPoint = Constants.AREAOUTHEIGHT;
	protected Vector3 initPos;

	private bool MoveFlag;
	private bool FallFlag;

//----------Setter----------//
	public bool setMoveFlag{
		set{this.MoveFlag = value; }
	}
	public bool setFallFlag {
		set{ this.FallFlag = value; }
	}


//----------Getter----------//
	public bool getMoveFlag{
		get{ return this.MoveFlag; }
	}
	public bool getFallFlag {
		get{ return this.FallFlag; }
	}
}
