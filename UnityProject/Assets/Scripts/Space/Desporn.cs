using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desporn : MonoBehaviour {

	public int DespornZ;
	Transform PlayerTrfm;
	// Use this for initialization
	void Start () {
		PlayerTrfm = GameObject.Find ("Player/Camera Panel").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z - PlayerTrfm.position.z <= DespornZ) {
			Destroy (gameObject);
		}
	}
}
