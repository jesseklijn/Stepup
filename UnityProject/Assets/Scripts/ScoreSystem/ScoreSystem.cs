using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float distance = Vector3.Distance(movement.currentPoint.transform.position, movement.currentPoint.B.transform.position);

        //get all until now
        List<Point> points = new List<Point>();
        for (int i = 0; i < railWaySystem.pointList.Count; i++)
        {
            if(movement.currentPoint == railWaySystem.pointList[i]) { }
        }


        return distance;
    }



    public float CalculateTotalCurrentDistance()
    {
        return 0;
    }
}
