using UnityEngine;
using System.Collections;

public class MoveTest : ChrAttribute {
	float timer = 1.0f;

	private Transform player;
	private Vector3 targetPosition;

	public float speed = 1f;
	public float time = 1f;

	private float changeTargetSqrDistance = 1f;

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
		float sqrDistanceToTarget = Vector3.Magnitude (transform.position - targetPosition);
		if (sqrDistanceToTarget <= changeTargetSqrDistance) {
			targetPosition = GetRandomPositionOnLevel ();
		}
		Vector3 movingPos = targetPosition - transform.position;
		movingPos.Normalize ();
		transform.position += new Vector3((movingPos.x * Time.deltaTime * speed),0,(movingPos.z * Time.deltaTime * speed));
		print ("sqrDistance" + sqrDistanceToTarget);
		print ("normalize" + movingPos);
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
