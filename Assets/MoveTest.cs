using UnityEngine;
using System.Collections;

public class MoveTest : ChrAttribute {

	private Transform player;
	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 1f;
	private float moveWaitTime = Constants.MOVEWAITTIME;


	// Use this for initialization
	void Start () {
		// extends variable

		initPos = new Vector3 (5,1.2f,-2);
		setMoveFlag = true;
		setFallFlag = false;

		// member variable
		transform.position = initPos;

		targetPosition = GetRandomPositionOnLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (getMoveFlag && Input.GetKeyDown (KeyCode.Space))
			setMoveFlag = false;
		if (!getMoveFlag && Input.GetKeyDown (KeyCode.H))
			setMoveFlag = true;
		if (getMoveFlag)
			Move();
		
	}
		
	private void Move(){
		float sqrDistanceToTarget = Vector3.SqrMagnitude (transform.position - targetPosition);
		if (sqrDistanceToTarget <= changeTargetSqrDistance) {
			targetPosition = GetRandomPositionOnLevel ();
		}
		Vector3 moveDirection = targetPosition - transform.position;
		moveDirection.Normalize ();
		transform.position += new Vector3((moveDirection.x * Constants.MOVESPEED),0,(moveDirection.z * Constants.MOVESPEED));

		print ("sqrDistance" + sqrDistanceToTarget);
		print ("normalize" + moveDirection);
		transform.rotation = Quaternion.identity;
	}
	public Vector3 GetRandomPositionOnLevel(){
		float xMin = 1f;
		float xMax = 8f;
		float zMin = -5f;
		float zMax = 3f;
		return new Vector3 (Random.Range (xMin, xMax), 1, Random.Range (zMin, zMax));
	}
}
