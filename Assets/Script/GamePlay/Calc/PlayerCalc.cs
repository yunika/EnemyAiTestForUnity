using UnityEngine;
using System.Collections;

public class PlayerCalc : MonoBehaviour {
	PlayerController player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.getFallFlag) {
			Debug.Log ("playerFallDamage : " + Constants.FALLDAMAGE);
			player.setFallFlag = false;
		}
	}
}
