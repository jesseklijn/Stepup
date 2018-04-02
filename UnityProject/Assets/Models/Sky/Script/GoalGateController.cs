using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGateController : MonoBehaviour {
    public GameObject Center, Glow, Fire;
    private ParticleSystem _Center, _Glow, _Fire;

    void Start () {
        _Center = Center.GetComponent<ParticleSystem>();
        _Glow = Glow.GetComponent<ParticleSystem>();
        _Fire = Fire.GetComponent<ParticleSystem>();
    }
	
	
	void Update () {
        
	}

    public void FirePlay()
    {
        _Fire.Play();
    }

    public void CenterPlay()
    {
        _Center.Play();
        _Glow.Play();
    }
}
