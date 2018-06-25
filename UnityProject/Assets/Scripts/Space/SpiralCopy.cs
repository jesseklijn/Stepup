using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralCopy : MonoBehaviour {


	public float radius;
	public int copySu;
	public float endZ;
	public float interZ;

	public float startAngle;

	public Color[] BaseColor = new Color[3];
	public Color[] EmissionColor = new Color[3];



	// Use this for initialization
	void Start () {
		int i = 1;
		float angle = 2 * Mathf.PI / (float)copySu;
		for (float nowZ = transform.position.z; nowZ<= endZ; nowZ += interZ) {
			GameObject ins = Instantiate (gameObject, new Vector3 (radius * Mathf.Cos (i * angle +startAngle*Mathf.PI), radius * Mathf.Sin (i * angle+startAngle*Mathf.PI),nowZ)
					, transform.rotation);
			i++;
			ins.GetComponent<SpiralCopy> ().enabled = false;


			//int index = Mathf.Min (Mathf.FloorToInt(nowZ / 65f), BaseColor.Length-1);
			int index = Random.Range (0, 3);
		
			index = Mathf.Min (index, BaseColor.Length - 1);
			Debug.Log (index.ToString());
			ins.GetComponent<ColorChange>().AlbedoColor = BaseColor [index];
			ins.GetComponent<ColorChange>().EmissionColor = EmissionColor[index];
			if(transform.parent != null)ins.transform.parent = transform.parent;
		}
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}

}
