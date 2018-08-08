using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StepUpSceneManager : BPMManager
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
    public GemsManager gemsManager;
    public HappyMeter hMeter;

    public float gemInterval; 

    //Shun StepMachineSettings by Tanaka
    /*public GameObject ShunObject;
    AniCTR _aniCTR; 
    */

    // Use this for initialization
    void Start()
    {
        Initialize();

        /*//Find AnimatedObject(ShunModel) byTanaka
        GameObject AnimatedObject = GameObject.Find(ShunObject.name);
        _aniCTR = AnimatedObject.GetComponent<AniCTR>();
        */
    }

    public void RefreshGems()
    {
        if(timePassed >= 3)
        {
            {      
                double m_cv = gameObject.GetComponent<StepAnalytics2>().GetCV();
                gemsManager.AddGemToList();
                gemsManager.SpawnGem(true);               
            }
        }
    }

    public void StartGame()
    {
        if(Singleton.cinematicController.introDone)
        {
            StartUpdating();
            gameStarted = true;
            InvokeRepeating("NextGemCheck", gemInterval, gemInterval);
            InvokeRepeating("ResetRecentStepsList", gemInterval+1, gemInterval);
            StartCoroutine(Timer(0, timeForTutorialToTurnOff));
        }
        else
        {
            StartGame();
        }
        
    }

    public void CancelInvokes()
    {
        CancelInvoke("NextGemCheck");
        CancelInvoke("ResetRecentStepsList");
    }

    public void StartCountDown()
    {
        if(Singleton.cinematicController.introDone && !Singleton.cinematicController.turnDoing)
        {
            StartCoroutine(countDownPlayer.CountDownFrom(3, countDownPlayer.audioClips, 1));

            Singleton.cinematicController.turnDoing = true;
            Singleton.cinematicController.PlayCinematic(1); //Rotate to player's back cutscene
            Singleton.cinematicController.PrioCam(0);
            ///_aniCTR.GameStart(); //byTanaka
        }
        
    }
    public override void BPMEARLYUPDATE()
    {
        base.BPMEARLYUPDATE();
        movementScript.DisplayShoe();

    }

    public void NextGemCheck()
	{
        movementScript.stepAnalytics.happyMeterInterval = gemInterval; //Set the gem interval inside the Analytics script before checking for the BPM;
        //double _currentCV = movementScript.stepAnalytics.GetCurrentCV();
        bool _correctBPM = movementScript.stepAnalytics.IsAmountOfstepsAcceptable();
        //Debug.Log("Current CV is: " + _currentCV);
        hMeter.PopUpHappyMeter(_correctBPM);

        if(_correctBPM) //GREAT
        {
            //gemsManager spawn pickup-able gem
            gemsManager.AddGemToList();
            gemsManager.SpawnGem(true);
        }
        else
        {
            //gemsManager spawn dropping gem
            gemsManager.AddGemToList();
            gemsManager.SpawnGem(false);
        }
    }

    public void ResetRecentStepsList()
	{
        //Debug.Log("Current List Length is: " + movementScript.stepAnalytics.RecentTimeStamps.Count);
		movementScript.stepAnalytics.RecentTimeStamps.Clear();
	}

    public override void BPMUPDATE()
    {

        base.BPMUPDATE();
        timePassed += Time.deltaTime * 1;

        if (Input.GetKeyDown(KeyCode.Escape)) { RestartScene(); }
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
            //RefreshGems();
        movementScript.inputIsGiven = true;
    }

    //Turns off tutorial at certain time
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

    void RestartScene()
    {
        //Restarts the game when called

       

    }


}
