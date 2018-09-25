using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //this script attached Enemy
    public GameObject EnemyEffect;
    public GameObject EnemyObject;
    GameObject PlayerObject;
    AudioSource[] EnemyAudios;

    private float impulseMagnitude;
    private float EnemySpeed = 1.0f;

    StepUpSceneManager sceneManager;


    // Use this for initialization
    void Start() {
        EnemyAudios = gameObject.GetComponents<AudioSource>();
        EnemyEffect.SetActive(false);

        EnemyAudios[1].Play();
        impulseMagnitude = 3f;
        PlayerObject = GameObject.FindGameObjectWithTag("Shun");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<StepUpSceneManager>();
    }

    // Update is called once per frame
    void Update() {

        EnemyComing();
        EnemyDelete();
    }

    void EnemyComing() {
        var Distance = Vector3.Distance(PlayerObject.transform.position, this.transform.position);

        if(Distance <= 3)
        {
            EnemySpeed = 0.4f;
        }
        else 
        {
            EnemySpeed = 1f;
        }
        //Debug.Log("speed = " + EnemySpeed);
        var DistanceToPlayer = PlayerObject.transform.position - this.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(DistanceToPlayer);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * EnemySpeed);
        this.transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
    }

    public IEnumerator EnemyAction() {
        //Debug.Log("touchHand");
        EnemyAudios[0].Play(); //TouchEnemies sound

        //Animation
        float t = Time.deltaTime;

        yield return new WaitForSeconds(0.1f);
        EnemyObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * t;
        yield return new WaitForSeconds(0.05f);


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
            var rigid = this.gameObject.GetComponent<Rigidbody>();

            var EnemyDirection = rigid.gameObject.transform.position - PlayerObject.transform.position;

            var impulse = (EnemyDirection).normalized * impulseMagnitude;
            rigid.AddForceAtPosition(impulse, this.transform.position, ForceMode.Impulse);

            StartCoroutine("EnemyAction");
        }
    }

    void EnemyDelete(){

        //var WorldPosition = PlayerObject.transform.TransformDirection(Vector3.);
        //var EnemyWorldPosition = transform.TransformDirection(this.transform.position);

        //Debug.Log("Kappa:" + this.transform.position.z);

        if (this.transform.position.z - PlayerObject.transform.position.z <-0.5f)
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
