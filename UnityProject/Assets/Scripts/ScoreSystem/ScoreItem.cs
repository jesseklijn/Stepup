using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour {

    public int score = 0;
    public int currentScore = 0;
    public ScoreSystem scoreSystem;

    public void AddScore()
    {
       //scoreSystem.scoreToIncrease[]

    }
    public virtual void Destroy()
    {
        Destroy(gameObject,0.1F);
        //TODO: remove 0.1F after sound is fixed from audiocontroller


        //particle effect
        //play particle
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy();
    }
}
