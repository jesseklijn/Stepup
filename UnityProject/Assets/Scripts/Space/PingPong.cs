﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour {

	public float hurehaba;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0,10*Time.deltaTime*( Mathf.PingPong (Time.time*speed, hurehaba)-hurehaba/2f), 0));
	}
}
