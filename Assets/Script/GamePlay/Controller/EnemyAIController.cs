using UnityEngine;
using System.Collections;

public class EnemyAIController : ChrAttribute {

	public Transform turret;
	public Transform muzzle;
	public GameObject bulletPrefab;

	private float attackInterval = 2f;
	private float turretRotationSmooth = 0.8f;
	private float lastAttackTime;

	private Transform player;

	private float speed = 1f;
	private float rotationSmooth = 1f;

	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 10f;

	private void Start(){
		initPos = new Vector3 (5,1.2f,-2);
		transform.position = initPos;
		this.setMoveFlag = true;
		this.setFallFlag = false;
		targetPosition = GetRandomPositionOnLevel();
		player = GameObject.FindWithTag("Player").transform;
	}

	private void Update(){

//		if (this.getMoveFlag && Input.GetKeyDown (KeyCode.Space))
//			this.setMoveFlag = false;
//		if (!getMoveFlag && Input.GetKeyDown (KeyCode.H))
//			this.setMoveFlag = true;
		if (getMoveFlag)
			Move ();
		if (getFallFlag) {
		}
		// 目標地点との距離が小さければ、次のランダムな目標地点を設定する
		float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
		if (sqrDistanceToTarget < changeTargetSqrDistance){
			targetPosition = GetRandomPositionOnLevel();
		}

		// 目標地点の方向を向く
		Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

		// 前方に進む
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		// 砲台をプレイヤーの方向に向ける
		Quaternion atkTargetRotation = Quaternion.LookRotation(player.position - turret.position);
		turret.rotation = Quaternion.Slerp(turret.rotation, atkTargetRotation, Time.deltaTime * turretRotationSmooth);

		// 一定間隔で弾丸を発射する
		if (Time.time > lastAttackTime + attackInterval)
		{
			print ("atk");
			Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
			lastAttackTime = Time.time;
		}
	}
	public Vector3 GetRandomPositionOnLevel(){
		float levelSize = 10f;
		return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
	}

	void FixedUpdate(){
		if (this.transform.position.y < fallPoint) {
			setFallFlag = true;
			this.transform.position = this.initPos;
		}
	}
	private void Move(){
//		var hor = Input.GetAxis ("Horizontal");
//		var ver = Input.GetAxis ("Vertical");
//		var xpos = transform.position.x + hor * Constants.MOVESPEED;
//		var zpos = transform.position.z + ver * Constants.MOVESPEED;
//		transform.position = new Vector3(xpos,transform.position.y,zpos);
	}
}
