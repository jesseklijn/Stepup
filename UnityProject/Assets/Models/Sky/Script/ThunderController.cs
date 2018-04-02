using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour {
    public GameObject Player;
    public GameObject ThunderA, ThunderB;
    private ParticleSystem _ThunderA, _ThunderB;
    private bool Passing = false;

    void Start () {
        _ThunderA = ThunderA.GetComponent<ParticleSystem>();
        _ThunderB = ThunderB.GetComponent<ParticleSystem>();
	}
	
	
	void Update () {
        if (Passing)
        {
            return;
        }


        if (Player.transform.position.z > 25)
        {
            _ThunderA.Play();
            _ThunderB.Play();
            Passing = true;
        }
    }
}
