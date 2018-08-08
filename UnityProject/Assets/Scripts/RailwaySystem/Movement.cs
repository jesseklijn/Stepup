using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public StepUpSceneManager sceneManager;
    public StepAnalytics2 stepAnalytics;

    public bool inputIsGiven = false;

    public Point currentPoint;
    public Point nextPoint;

    public ParticleSystem[] particleSystems;

    //Movement
    public bool Accelerating = false;
    public float baseSpeed = 1;
    public float accelSpeed = 0;
    public float velocitySpeed = 0;

    public float amountToAccelerate = 3;
    public float accelerateTimeFrame = 1;
    public List<Accelerate> acceleration = new List<Accelerate>();

    public bool isRotating = false;

    //Displaying
    public bool leftShoe = false;
    public bool rightShoe = false;

    //Tutorial
    public GameObject LeftShoe;
    public GameObject RightShoe;
    public GameObject textStart;

    public CameraMovement cameraMovement;

    public RailwaySystem railwaySystem;

    public GameObject toMove;

    //Shun Animation setup byTanaka
    /*public GameObject FindShunObject;
    AniCTR aniCTR;

     

    void Start() //byTanaka
    {
        //Find AnimatedObject(ShunModel)
        GameObject AnimatedObject = GameObject.Find(FindShunObject.name);
        Debug.Log(AnimatedObject);
        aniCTR = AnimatedObject.GetComponent<AniCTR>();
    }*/

    private void Awake()
    {
        //Check for soundtrack, stop it
        if (GameObject.Find("Soundtrack") != null)
        {
            Destroy(GameObject.Find("Soundtrack"));
        }

    }   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true && Singleton.cinematicController.introDone)
        {

            rightShoe = false;
            leftShoe = true;

            if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
            {
                stepAnalytics.AddTimeStamp(sceneManager.timePassed, "Left");
                Accelerate();
                particleSystems[0].Play();
                particleSystems[2].Play();


                //aniCTR.StartCoroutine("LeftStep");//byTanaka
            }    

            if (sceneManager.gameStarted == false)
            {

                sceneManager.StartCountDown();

                textStart.SetActive(false);
            }
            

            if (inputIsGiven == true)
            {
                
                inputIsGiven = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true && Singleton.cinematicController.introDone)
        {

            leftShoe = false;
            rightShoe = true;

            if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
            {
                stepAnalytics.AddTimeStamp(sceneManager.timePassed, "Right");
                Accelerate();
                particleSystems[1].Play();
                particleSystems[3].Play();

                //aniCTR.StartCoroutine("RightStep"); //byTanaka
            }

            if (sceneManager.gameStarted == false)
            {
                sceneManager.StartCountDown();

                textStart.SetActive(false);
            }

            if (inputIsGiven == true)
            {
                
                inputIsGiven = false;
            }
            
        }
       
        if (sceneManager.gameStarted == true)
        {
            UpdateMovement();
        }
    }

    public void DisplayShoe()
    {
        if (sceneManager.tutorial == true)
        {
            if (leftShoe == true)
            {
                //Disable icon
                LeftShoe.SetActive(false);
            }
            else
            {
                //Enable icon
                LeftShoe.SetActive(true);
            }
            if (rightShoe == true)
            {
                //Disable icon
                RightShoe.SetActive(false);
            }
            else
            {
                //Enable Icon
                RightShoe.SetActive(true);
            }
        }
        else
        {
            DisableShoe();
        }
    }
    public void DisableShoe()
    {
        LeftShoe.SetActive(false);
        RightShoe.SetActive(false);
        textStart.SetActive(false);
    }
    public void Accelerate()
    {
        if (sceneManager.gameStarted == true)
        {
        Singleton.audioController.PlaySFX("Cart Clang", gameObject, false, true);
        Singleton.audioController.PlaySFX("Woosh", gameObject, false, true);
        }

        StartCoroutine(cameraMovement.Accelerate(0, amountToAccelerate, accelerateTimeFrame));
    }
    public void UpdateMovement()
    {


        accelSpeed = CalculateTotalAcceleration();
        velocitySpeed = baseSpeed + accelSpeed;

        gameObject.transform.position = Vector3.MoveTowards(transform.position, nextPoint.transform.position, velocitySpeed * Time.deltaTime);
        //Execute movement towards A - B target by speed + acceleration * delta

        //Always smoothly look at target



    }
    public void RotateTowardsTarget(Point point)
    {
        StartCoroutine(cameraMovement.RotateTowardsClosestWayPoint(currentPoint.transform.rotation.eulerAngles, point.transform.rotation.eulerAngles, 2, toMove));
    }
    public float CalculateTotalAcceleration()
    {

        float numberToReturn = 0;

        for (int i = 0; i < acceleration.Count; i++)
        {
            numberToReturn += acceleration[i].acceleration;
        }


        return numberToReturn;
    }
}
