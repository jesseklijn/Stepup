using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

	public StepUpSceneManager sceneManager;
	public StepAnalytics2 stepAnalytics;

    public ParticleSystem[] particles;

    void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			gameObject.GetComponentInChildren<ParticleSystem>().Play();
			Singleton.audioController.PlaySFX("Yay", gameObject, false, false);
			sceneManager.gameFinished = true;
			stepAnalytics.Save();


            particles[0].Play();
            particles[1].Play();

        }
    }
	
}
