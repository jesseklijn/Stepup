using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenixController : MonoBehaviour {
    public GameObject Player;
    Animator FenixAnimator;
    bool Passing = false;
    public GameObject feather001, feather002;
    ParticleSystem _feather001, _feather002;

	void Start () {
        FenixAnimator = gameObject.GetComponent<Animator>();
        _feather001 = feather001.GetComponent<ParticleSystem>();
        _feather002 = feather002.GetComponent<ParticleSystem>();
    }
	

	void Update () {
        if (Passing)
        {
            return;
        }

        if(Player.transform.position.z > 150)
        {
            FenixAnimator.SetTrigger("Fly");
            _feather001.Play();
            _feather002.Play();
            Passing = true;
        }
       
	}
}
