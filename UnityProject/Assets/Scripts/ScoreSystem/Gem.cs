using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : ScoreItem {

    public GameObject onDeath;

    //2D Gem fields
    private GameObject eventGameObject;
    public GameObject gemSpritePrefab;
    public GameObject ParticleSystemPrefabs;

    public GameObject scoreTextPrefab;
    public GameObject scoreTextPrefabEventParent;
    void Start () {
        eventGameObject = GameObject.FindGameObjectWithTag("EventsObjects");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Destroy()
    {


        //Display particle
        //onDeath.SetActive(true);
        GameObject local = Instantiate(ParticleSystemPrefabs, new Vector3(transform.position.x,transform.position.y+0.5F,transform.position.z), Quaternion.identity, eventGameObject.transform);
        Destroy(local, 3);

        local = Instantiate(scoreTextPrefab, scoreTextPrefabEventParent.transform);
        local.GetComponent<ScoreTextEvent>().textToDisplay = currentScore.ToString();

        Singleton.audioController.PlaySFX("Pickup Gem", gameObject, false, true);
    
        AddScore();

        Instantiate(gemSpritePrefab, eventGameObject.transform);
        scoreSystem.gemCount++;
        scoreSystem.display.DisplayGemCount(scoreSystem.gemCount);
        base.Destroy();

    }
}
