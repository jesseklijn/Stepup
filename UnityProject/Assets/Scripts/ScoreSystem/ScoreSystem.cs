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

    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();

    }

    public void ProgressSetup()
    {
        ///Divide the slider equally by the sum of distance
    }

    public void ProgressSliderUpdate()
    {
        ///Check position on list
        //Get index
        //Compare index with list
        //
    }
}
