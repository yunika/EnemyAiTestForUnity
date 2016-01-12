using UnityEngine;
using System.Collections;

public class PlayerController : ChrAttribute{
	void Start(){
		initPos = new Vector3 (-5,1.2f,-2);
		this.transform.position = initPos;
		setMoveFlag = true;
		setFallFlag = false;
	}
	void Update(){
		if (this.getMoveFlag && Input.GetKeyDown (KeyCode.Space))
			this.setMoveFlag = false;
		if (!getMoveFlag && Input.GetKeyDown (KeyCode.H))
			this.setMoveFlag = true;
		if (getMoveFlag)
			Move ();
		if (getFallFlag) {
		}
	}
	void FixedUpdate(){
		if (this.transform.position.y < fallPoint) {
			setFallFlag = true;
			this.transform.position = this.initPos;
		}
	}
	private void Move(){
		var hor = Input.GetAxis ("Horizontal");
		var ver = Input.GetAxis ("Vertical");
		var xpos = transform.position.x + hor * Constants.MOVESPEED;
		var zpos = transform.position.z + ver * Constants.MOVESPEED;
		transform.position = new Vector3(xpos,transform.position.y,zpos);
	}
}
