using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {
	
	private Vector3 goPosition;
	private float changegoTargetSqrDistance = 40f;
	private float rotationfly = 1.0f;
	private float flyspeed = 0.5f;
	// Use this for initialization
	void Start () {
        goPosition = GetRandomPositionOnLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
		float sqrDistanceToTarget = Vector3.SqrMagnitude (goPosition - transform.position);
		if (sqrDistanceToTarget < changegoTargetSqrDistance) {
			goPosition = GetRandomPositionOnLevel ();
		}
		Quaternion targetRotation = Quaternion.LookRotation (goPosition - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationfly);
		transform.Translate (Vector3.forward * flyspeed * Time.deltaTime);
}
	Vector3 GetRandomPositionOnLevel(){ //ランダムに目標値を変えるメソッド
		//float levelSize = 15f;
		return new Vector3 (Random.Range (-7, 7), Random.Range (1, 3), Random.Range (190, 210)); //XZ座標において-levelSizeからlevelSizeまでの範囲で目標値を設置
	}
}
