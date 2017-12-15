using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : ScoreItem {

    public GameObject onDeath;
    public AudioClip soundOnDeath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Destroy()
    {


        //Display particle
        //onDeath.SetActive(true);

        //Play sound

        //TODO: Change this sound to SFX audiocontroller
        //gem.PlayOneShot(soundOnDeath);
        AddScore();
        scoreSystem.gemCount++;
        scoreSystem.display.DisplayGemCount(scoreSystem.gemCount);
        base.Destroy();

    }
}
