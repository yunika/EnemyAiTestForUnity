using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	void Awake(){
		if (instance == null) 
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Init(){
		
	}

}
