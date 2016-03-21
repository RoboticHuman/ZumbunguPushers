﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	void Awake () {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		Time.fixedDeltaTime = (float)0.008;

		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}