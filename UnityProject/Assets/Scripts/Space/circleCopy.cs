using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleCopy : MonoBehaviour {


	public float[] radius;
	public int[] copySu;

	// Use this for initialization
	void Start () {
		for (int j = 0; j < radius.Length; j++) {
			float angle = 2 * Mathf.PI / (float)copySu[j];
			for (int i = 1; i <= copySu[j]; i++) {
				GameObject ins = Instantiate (gameObject, new Vector3 (radius[j] * Mathf.Cos (i * angle), radius[j] * Mathf.Sin (i * angle), transform.position.z)
				, transform.rotation);
				ins.GetComponent<circleCopy> ().enabled = false;
			}
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
