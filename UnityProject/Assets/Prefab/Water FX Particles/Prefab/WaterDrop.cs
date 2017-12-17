using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterDrop : MonoBehaviour
{

    ParticleSystem drop;

    void Start()
    {
        drop = this.GetComponent<ParticleSystem>();
        drop.Play(); 
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("testdrip");
        Singleton.audioController.PlaySFX("Drip", gameObject, false, true);

    }
}
