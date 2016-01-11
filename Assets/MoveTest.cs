using UnityEngine;
using System.Collections;

public class MoveTest : ChrAttribute {
	private Transform player;

	public float speed = 10f;

	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 8f;

	// Use this for initialization
	void Start () {
		// extends variable

		initPos = new Vector3 (5,1.2f,-2);
		setMoveFlag = true;
		setFallFlag = false;

		// member variable
		transform.position = initPos;
		//this.yPos = transform.position.y;

		targetPosition = GetRandomPositionOnLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.getMoveFlag && Input.GetKeyDown (KeyCode.Space))
			this.setMoveFlag = false;
		if (!getMoveFlag && Input.GetKeyDown (KeyCode.H))
			this.setMoveFlag = true;
		if (transform.position.y < fallPoint) {
			setFallFlag = true;
			transform.position = initPos;
		}
		if (getMoveFlag)
			Move();
		
	}

	void FixedUpdate(){
		
	}
	private void Move(){
		var horizontalPosition = transform.position.x + Constants.MOVESPEED;
		var verticalPosition = transform.position.z + Constants.MOVESPEED;

		float sqrDistanceToTarget = Vector3.Magnitude (transform.position - targetPosition);
		if (sqrDistanceToTarget < changeTargetSqrDistance) {
			targetPosition = GetRandomPositionOnLevel ();
		}
		transform.position = targetPosition;
		print (sqrDistanceToTarget);
//		transform.Translate(targetPosition,Space.World);
		transform.rotation = Quaternion.identity;
	}
	public Vector3 GetRandomPositionOnLevel(){
		float xMin = 1.2f;
		float xMax = 8f;
		float zMin = -5f;
		float zMax = 3f;
		return new Vector3 (Random.Range (xMin, xMax), 1, Random.Range (zMin, zMax));
	}
}
