﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    public int inGameScore = 0;
    public int gemCount = 0;
    public int[] increment;
    public List<ScoreItem> scoreToIncrease;
    public ScoreDisplay display;

    public SceneManager sceneManager;
    public RailwaySystem railWaySystem;
    public Movement movement;

    public Slider progressBar;
    //Private field
    int lowestIncrement;
    int scoreIncrement = 0;
    ScoreItem[] items;
    //Gem

    public void ScoreUpdate()
    {
        if (scoreToIncrease.Count >= 1)
        {
            scoreIncrement = 0;
            for (int i = 0; i < scoreToIncrease.Count; i++)
            {
                if (scoreToIncrease[i].currentScore >= ScoreIncrement(scoreToIncrease[i].currentScore))
                {
                    scoreIncrement += lowestIncrement;
                    scoreToIncrease[i].currentScore -= lowestIncrement;

                }
            }
            inGameScore += scoreIncrement;


            //Remove any empty scores
            for (int i = 0; i < scoreToIncrease.Count; i++)
            {
                if (scoreToIncrease[i].currentScore == 0)
                {
                    scoreToIncrease.Remove(scoreToIncrease[i]);
                }
            }
            display.DisplayScore(inGameScore);
        }


    }

    public int ScoreIncrement(int score)
    {



        for (int i = 0; i < increment.Length; i++)
        {
            if (increment[i] <= score)
            {
                lowestIncrement = increment[i];
            }
            if (increment[i] >= score)
            {
                return lowestIncrement;
            }
        }
        //error
        Debug.LogWarning("Increment list is empty!! Add increments to ScoreSystem");
        return 0;

    }




    // Use this for initialization
    void Start()
    {
        ProgressSetup();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
        sceneManager.CurrentProgressDistanceTraveled = CalculateCurrentDistance();
        progressBar.maxValue = sceneManager.distanceFromStartToFinish;
    }

    public void ProgressSetup()
    {
        sceneManager.distanceFromStartToFinish = CalculateTotalDistance(railWaySystem.pointList);
    }

    public float CalculateTotalDistance(List<Point> points)
    {
        float distance = 0;

        for (int i = 0; i < points.Count; i++)
        {
            distance += points[i].distanceToB;
        }
        return distance;
    }

    public float CalculateCurrentDistance()
    {
        //Get current point distance
        float distance = Vector3.Distance(movement.transform.position, movement.currentPoint.B.transform.position);
        bool currentPointHit = false;

        Debug.Log("currentPoint Distance: "+distance);

        //Get local distances
        for (int i = 0; i < railWaySystem.pointList.Count; i++)
        {
            if (currentPointHit == true)
            {
              distance += railWaySystem.pointList[i].distanceToB;
            }
            if (movement.currentPoint == railWaySystem.pointList[i])
            {
                currentPointHit = true;
            }
        }
        Debug.Log("local Distances pre : " + distance);
        //Calculate total distance

        distance = sceneManager.distanceFromStartToFinish - distance; 

        //DISTANCE = 100 

        //Current distance = 99

        

        // 100 - 99 = 1 

        Debug.Log("local Distances post: " + distance);
        //Return the value
        return distance;
    }
}
