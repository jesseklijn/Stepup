using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : ScoreItem {

    public GameObject onDeath;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Destroy()
    {
       

        //Display particle
        //onDeath.SetActive(true);

        Singleton.audioController.PlaySFX("Pickup Gem", gameObject, false, true);
    
        
        base.Destroy();

    }
}
