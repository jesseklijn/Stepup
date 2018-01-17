using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public Text scoreDisplay;
    public Text gemScore;

    public Slider progressBar;

    public Movement movementScript;
    public StepUpSceneManager sceneManager;

    public bool timerRunning = false;

    public void Start()
    {
        DisplayScore(0);



    }

    public void Update()
    {
        progressBar.value = sceneManager.CurrentProgressDistanceTraveled;
    }

    public void DisplayScore(int score)
    {
        char[] scoreText = score.ToString().ToCharArray();

        int amount = 7;

        string display = "";
        for (int i = 0; i < scoreText.Length; i++)
        {
            amount--;
        }

        for (int i = 0; i < amount; i++)
        {
            display += "0";
        }

        display += score.ToString();
        scoreDisplay.text = display;
    }

    public void DisplayGemCount(int score)
    {
        gemScore.text = score.ToString();
    }




    public void ScoreAnimation(GameObject textObject)
    {



    }
    public IEnumerator Animate(int time, float startValue, float endValue)
    {

        if (timerRunning == false)
        {

            timerRunning = true;
            float t = 0;

            //Move while time is still below 1

            while (t < 1)
            {

                t += Time.deltaTime / time;
                yield return 0;

                //scale

                
            }


        }

    }
}
