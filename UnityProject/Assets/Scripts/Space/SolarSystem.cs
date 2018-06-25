using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour {


	public GameObject planetPrefab;
	public float planetInterval; 
	public float[] planetSizes = new float[7];
	public float[] planetSpeeds = new float[7];
	public Texture[] planetTex = new Texture[7];

	GameObject[] planets;
	float omegaCounter;

	void Start () {
		planets = new GameObject[planetSizes.Length];
		for (int i = 0; i < planetSizes.Length; i++) {
			planets [i] = Instantiate (planetPrefab, 
				transform.position + new Vector3 (planetSizes[i]+planetInterval*(i+1), 0, 0), Quaternion.identity);
			planets [i].transform.parent = transform;
			planets [i].transform.localScale *= planetSizes [i];
		}
		omegaCounter = Random.Range (0, 2 * Mathf.PI);
	}
	
	// Update is called once per frame
	void Update () {
		omegaCounter += Mathf.PI * 0.01f * Time.deltaTime;
		if (omegaCounter == 2 * Mathf.PI)
			omegaCounter = 0;
		for (int i = 0; i < planetSizes.Length; i++) {
			planets [i].transform.localPosition = planets [i].transform.localPosition.magnitude*new Vector3 (
				Mathf.Cos (planetSpeeds [i]*omegaCounter),
				0,
				Mathf.Sin (planetSpeeds [i]*omegaCounter));
		}
	}
}
