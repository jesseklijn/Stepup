using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCopy : MonoBehaviour {


	public bool isRandomScale;
	public float RANGE;
	public int Su;

	// Use this for initialization

	void Start () {
		for (int i = 0; i < Su; i++) {
			GameObject ins = Instantiate (gameObject, transform.position+new Vector3 (Random.Range (-RANGE, RANGE),
				                 Random.Range (-RANGE, RANGE), Random.Range (-RANGE, RANGE)), transform.rotation);
			ins.GetComponent<RandomCopy> ().enabled = false;
			if (new Vector2(ins.transform.position.x,ins.transform.position.y).magnitude<3)
				Destroy (ins);
			if(isRandomScale)ins.transform.localScale*=Random.Range(0.2f,1f);
		}
		Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
