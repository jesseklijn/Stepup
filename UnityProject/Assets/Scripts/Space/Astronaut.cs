using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour {


	int state;
	public bool frag;
	float TriggerLineZ = -7;
	float TriggerLineZ2 = -2;
	Vector3 TargetPosi;
	public Vector3 TargetDist;

    float interval1;
    float interval2;
    float randomLine1 = 5;
    float randomLine2 = 5;

	Transform playerTrans;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerTrans = GameObject.Find ("Player/Camera Panel").transform;
	}
	
	// Update is called once per frame
	void Update () {

		switch (state) {
		case 0:
			if (transform.position.z - playerTrans.position.z <= TriggerLineZ) {
				state = 1;
				anim.SetInteger ("AnimationPar", 1);
			}
			break;
		case 1:
			transform.position = Vector3.Lerp (transform.position, playerTrans.position + TargetDist, Time.deltaTime / 2f);
			transform.forward = Vector3.Lerp (transform.forward, Vector3.forward, Time.deltaTime );
                interval1 += Time.deltaTime;
			if (interval1>=randomLine1 | transform.position.z - playerTrans.position.z >= TargetDist.z * 0.5f) {
				state = 2;
				anim.SetInteger ("AnimationPar", 1);

                    interval1 = 0;
                    randomLine1 = Random.Range(2, 7);
			}
			if (transform.position.z >= 170)
				state = 3;
			break;
		case 2:
			transform.position = Vector3.Lerp (transform.position, playerTrans.position + TargetDist, Time.deltaTime / 5f);
			transform.forward = Vector3.Lerp (transform.forward, (playerTrans.position - transform.position).normalized, Time.deltaTime );
                interval2 += Time.deltaTime;
                if (interval2>= randomLine2 |transform.position.z - playerTrans.position.z <= 0){
				state = 1;
				anim.SetInteger ("AnimationPar", 1);

                    interval2 = 0;
                    randomLine2 = Random.Range(2, 4);
                }
			if (transform.position.z >= 170)
				state = 3;
			break;
		case 3:
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, transform.position.y, 220), Time.deltaTime / 5f);
			transform.forward = Vector3.Lerp (transform.forward, Vector3.forward, Time.deltaTime );
			if (transform.position.z >= 200) {
				state = 4;
				anim.SetInteger ("AnimationPar", 0);
			}
			break;
		case 4:
			transform.forward = Vector3.Lerp (transform.forward, (playerTrans.position - transform.position).normalized, Time.deltaTime );
			break;
		}






	}
}
