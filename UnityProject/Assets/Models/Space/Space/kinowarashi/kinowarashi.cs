using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinowarashi : MonoBehaviour {

	Rigidbody rigid ;

	string parent;

    float interval1;
    float randomLine1 = 2;

    void Start (){
		rigid = GetComponent<Rigidbody> ();
		rigid.AddTorque (new Vector3 (Random.Range (-180, 180), 0, Random.Range (-180, 180)));
	}
	
	// Update is called once per frame
	void Update () {


        interval1 += Time.deltaTime;
        if (interval1 >= randomLine1)
        {
            rigid.AddTorque(new Vector3(Random.Range(-180, 180), 0, Random.Range(-180, 180)));
            interval1 = 0;
            randomLine1 = Random.Range(2f, 7f);
        }
		
	}


	void nyokiPyon(){
		rigid.velocity = Vector3.zero;
		rigid.AddForce (transform.up.normalized * 5f,ForceMode.VelocityChange);
	}


}
