using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour {

	public bool isRandom;
	public bool isTriggerType;
	public float TriggerLineZ;
	bool triggerOn = false;
	public Vector3 SPEED;

	Transform playerTrans;

	// Use this for initialization
	void Start () {
		if (isRandom) {
			SPEED = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			SPEED *= 0.5f;
		}

		playerTrans = GameObject.Find ("Player/Camera Panel").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggerType) {
			if (transform.position.z - playerTrans.position.z <= TriggerLineZ)triggerOn = true;
			if(triggerOn)transform.Translate (SPEED*Time.deltaTime*10, Space.World);
		} else {
			transform.Translate (SPEED*Time.deltaTime*10, Space.World);
		}
	}


}
