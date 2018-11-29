using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //this script attached Enemy
    public GameObject EnemyEffect;
    public GameObject EnemyObject;
    GameObject TargetObject;
    AudioSource[] EnemyAudios;
    Animator EnemyAnimator;

    private float impulseMagnitude;
    private float EnemySpeed = 1.0f;
    private float AnimationTime = 0.0f;

    //public JoyconManager _joyconManager;
    StepUpSceneManager sceneManager;


    // Use this for initialization
    void Start() {
        EnemyAudios = gameObject.GetComponents<AudioSource>();
        EnemyAnimator = EnemyObject.GetComponent<Animator>();
        EnemyEffect.SetActive(false);

        EnemyAudios[1].Play();
        impulseMagnitude = 3f;
        TargetObject = GameObject.FindGameObjectWithTag("Shun");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<StepUpSceneManager>();

    }

    // Update is called once per frame
    void Update() {
        AnimationTime += Time.deltaTime;
        if (AnimationTime >= 1.0f)
        {
            EnemyAnimator.SetBool("Flying", true);
        }

        EnemyComing();
        EnemyDelete();
    }

    void EnemyComing() {
        var Distance = Vector3.Distance(TargetObject.transform.position, this.transform.position);

        if (Distance <= 3)
        {
            EnemySpeed = 0.4f;
        }
        else 
        {
            EnemySpeed = 1f;
        }
        //Debug.Log("speed = " + EnemySpeed);
        var DistanceToPlayer = TargetObject.transform.position - this.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(DistanceToPlayer);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * EnemySpeed);
        this.transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
    }

    public IEnumerator EnemyAction() {
        
        yield return new WaitForSeconds(0.25f);
        //DestroyEnemies
        EnemyEffect.SetActive(true);
        EnemyAudios[1].Play(); //DestroyEnemies sound
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);


    }

    private void OnTriggerEnter(Collider HandCollision) // when this enemy touch player hand, do
    {
        if (HandCollision.gameObject.tag == "Hand")
        {
            EnemyAudios[0].Play();
            EnemyAnimator.SetBool("Damage", true);
            EnemyAnimator.SetBool("Flying", false);
            //EnemyEffect.SetActive(true);
            StartCoroutine("EnemyAction");
        }
    }

    void EnemyDelete(){

        if (this.transform.position.z - TargetObject.transform.position.z <-0.5f)
        {
            Destroy(this.gameObject);
        }

        else if (sceneManager.gameStarted == false)
        {
            Destroy(this.gameObject);
        }
    }



    /*
    GameObject searchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;
        float nearDis = 0;
        GameObject targetObj = null;
        //Tag Retrieve the specified object as an array
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //Get the distance between this itself and the acquired object
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        return targetObj; //Get the closest object in the tag

    }
    */
}
