using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	public Color AlbedoColor;
	public Color EmissionColor;

	MeshRenderer mrend;
	// Use this for initialization
	void Start () {
		mrend = GetComponent<MeshRenderer> ();
		mrend.material.color = AlbedoColor;
		mrend.material.SetColor ("_EmissionColor", EmissionColor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
