using System.Collections;
using UnityEngine;

public class SceneManager : BPMManager
{


    public bool gameStarted = false;
    public bool gameFinished = false;

    //Tutorial settings
    public bool tutorial = false;
    public int timeForTutorialToTurnOff = 3;
    public bool timerRunning = false;

    public float distanceFromStartToFinish = 0;
    public float CurrentProgressDistanceTraveled;

    public float timePassed;

    public Movement movementScript;
    public CountdownPlayer countDownPlayer;
    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    public void StartGame()
    {
        StartUpdating();
        gameStarted = true;
        StartCoroutine(Timer(0, timeForTutorialToTurnOff));
    }
    public void StartCountDown()
    {
        StartCoroutine(countDownPlayer.CountDownFrom(3, countDownPlayer.audioClips, 1));
    }
    public override void BPMEARLYUPDATE()
    {
        base.BPMEARLYUPDATE();
        movementScript.DisplayShoe();

    }

    public override void BPMUPDATE()
    {
        base.BPMUPDATE();
        timePassed += Time.deltaTime * 1;
    }

    public override void Interval()
    {
        base.Interval();

        if (movementScript.inputIsGiven == true)
        {
            //move forward   

        }
        else
        {
            //lower bpm
            current_BPM -= _BPM_DROP;

        }

        movementScript.inputIsGiven = true;
    }

    public IEnumerator Timer(int time, int limit)
    {
        if (timerRunning == false)
        {
            timerRunning = true;
            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / 1;
                yield return 0;
            }
            time += 1;
            if (time != limit)
            {
                
                timerRunning = false;
                StartCoroutine(Timer(time, limit));
            }
            else
            {
                Debug.Log("Should turn off Tutorial!");
                timerRunning = false;
                movementScript.DisableShoe();
                tutorial = false;
            }
        }
    }



}
