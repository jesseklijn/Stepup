using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour {
    public GameObject Player;
    Animator BirdsAnimator;
    bool Passing = false;
    public GameObject[] feathers;
    ParticleSystem[] _feathers;

    void Start () {
        BirdsAnimator = gameObject.GetComponent<Animator>();
        _feathers = new ParticleSystem[feathers.Length];
        for(int i = 0; i < feathers.Length;i++)
        {
            _feathers[i] = feathers[i].GetComponent<ParticleSystem>();
        }
    }
	
	
	void Update () {
        if (Passing)
        {
            return;
        }

        if (Player.transform.position.z > 135)
        {
            BirdsAnimator.SetTrigger("Fly");           
            Passing = false;
        }
    }

    void PlayFeather()
    {
        for (int j = 0; j < _feathers.Length; j++)
        {
            _feathers[j].Play();
        }
    }
}
