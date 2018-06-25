using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiralStar : MonoBehaviour {

	bool underAnimation=true;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (underAnimation) {
			transform.localScale = new Vector3 (1, Mathf.Lerp (transform.localScale.y, 1, 0.1f),1);
			if (transform.localScale.y == 1)
				underAnimation = false;
		}
	}
}
