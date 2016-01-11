using UnityEngine;
using System.Collections;

public class MoveTest : ChrAttribute {
	float yPos;

	private Transform player;

	private Vector3 targetPosition;
	void Start () {
		// extends variable

		initPos = new Vector3 (5,1.2f,-2);
		//setMoveFlag = true;
		//setFallFlag = false;

		// member variable
		this.transform.position = initPos;
		this.yPos = transform.position.y;

		this.targetPosition = GetRandomPositionOnLevel ();
		this.player = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < fallPoint) {
			setFallFlag = true;
			this.transform.position = initPos;
		}
		if (getMoveFlag)
			Move();
	}

	void FixedUpdate(){
		this.yPos = transform.position.y;
	}
	private void Move(){
		GetRandomPositionOnLevel ();
//		var hor = Input.GetAxis ("Horizontal");
//		var ver = Input.GetAxis ("Vertical");
//		var xpos = transform.position.x + hor * Constants.MOVESPEED;
//		var zpos = transform.position.z + ver * Constants.MOVESPEED;
//		transform.position = new Vector3(xpos,transform.position.y,zpos);
	}
	public Vector3 GetRandomPositionOnLevel(){
		float xMin = 1.2f;
		float xMax = 8.0f;
		float zMin = -5.5f;
		float zMax = 3.4f;
		return new Vector3 (Random.Range (xMin, xMax), 1, Random.Range (zMin, zMax));
	}
}
