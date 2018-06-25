using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour {

	public float MOVESPEED = 2f;
	public float SCALESPEED = 1.1f;

	Transform playerTrans;
	Vector3 moveDirec = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		playerTrans = GameObject.Find ("Player/Camera Panel").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTrans.position.z >= transform.position.z) {
			if(moveDirec.magnitude == 0){
				Vector3 vec = (playerTrans.position - transform.position).normalized;
				moveDirec = new Vector3 (vec.x, vec.y, vec.z);
			}
			transform.Translate (moveDirec * MOVESPEED);
			transform.localScale *= 1.1f;
		}
	}
}
