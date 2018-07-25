using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : ScoreItem
{

    public enum GemType
    {
        Sapphire,
        Ruby,
        Diamond
    }


    public GameObject onDeath;

    public GemType gemType;

    //2D Gem fields
    private GameObject eventGameObject;
    public GameObject gemSpritePrefab;
    public GameObject ParticleSystemPrefabs;

    public GameObject scoreTextPrefab;
    public GameObject scoreTextPrefabEventParent;

    public bool pickupAble;
    private GemAnimation anim;

    void Start()
    {
        anim = GetComponent<GemAnimation>();
        eventGameObject = GameObject.FindGameObjectWithTag("EventsObjects");
        scoreTextPrefabEventParent = GameObject.FindGameObjectWithTag("Canvas");
        scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
    }

    public IEnumerator Animate()
    {
        if(pickupAble)
        {
            Destroy();
        }
        else
        {
            anim.OnGemFall();
            yield return new WaitForSeconds(3f);
            //Destroy();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Animate());
        //Destroy();
       
    }

    public override void Destroy()
    {

        //Display particle
        //onDeath.SetActive(true);
        GameObject local = Instantiate(ParticleSystemPrefabs, new Vector3(transform.position.x, transform.position.y + 0.5F, transform.position.z), Quaternion.identity, eventGameObject.transform);
        Destroy(local, 3);

        local = Instantiate(scoreTextPrefab, scoreTextPrefabEventParent.transform);
        local.GetComponent<ScoreTextEvent>().textToDisplay = currentScore.ToString();

        Singleton.audioController.PlaySFX("Pickup Gem", gameObject, false, true);

        AddScore();

        Instantiate(gemSpritePrefab, eventGameObject.transform);
        if (gemType == GemType.Sapphire)
        {
            scoreSystem.sapphireCount++;
        }
        else if (gemType == GemType.Ruby)
        {
            scoreSystem.rubyCount++;
        }
        else if (gemType == GemType.Diamond)
        {
            scoreSystem.diamondCount++;
        }
        scoreSystem.gemCount++;
        scoreSystem.display.DisplayGemCount(scoreSystem.gemCount);
        base.Destroy();

    }
}
