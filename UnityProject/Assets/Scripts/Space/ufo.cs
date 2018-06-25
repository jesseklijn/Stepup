using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo : MonoBehaviour {

	Material lightMat;
	public Color EmissionColorBright;
	public Color EmissionColorDark;

	Vector3 TargetPosi=new Vector3(0,0,0);

    float interval1;
    float randomLine1 = 2;


    // Use this for initialization
    void Start () {
		lightMat = GetComponent<MeshRenderer> ().materials [1];
		//ChangeRandomTargetPosi ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, (Mathf.PingPong (Time.time, 0.5f)-0.25f)*Time.deltaTime*10, 0)); //上下運動
		lightMat.SetColor("_EmissionColor",Color.Lerp(EmissionColorBright,EmissionColorDark,Mathf.PingPong(Time.time,1f)));

		if(TargetPosi.magnitude!=0)transform.position = Vector3.Slerp (transform.position, TargetPosi, Time.deltaTime/2f);

        interval1 += Time.deltaTime;
        if (interval1 >= randomLine1) {
			ChangeRandomTargetPosi ();
            interval1 = 0;
            randomLine1 = Random.Range(2f, 7f);
		}
	}


	void ChangeRandomTargetPosi(){
		TargetPosi.x = Random.Range (-30, 30f);
		TargetPosi.y = Random.Range (-30, 30f);
		TargetPosi.z = Random.Range (0, 70f);
	}
}
