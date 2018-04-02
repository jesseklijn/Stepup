using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public bool Dead = false;
    public float speed;

	void Start () {
		
	}
	
	
	void Update () {
        if (gameObject.transform.position.y < -100)
        {
            Dead = true;
            return;
        }
        gameObject.transform.position += new Vector3(speed / 3, -speed, -speed / 3);
	}
}
