using UnityEngine;

public class SceneManager : BPMManager {

    
    public bool gameStarted = false;

    //Tutorial settings
    public bool tutorial = false;
    //If tutorial is false, then shotTutorial does not affect game
    public bool shortTutorial = true;


    public float timePassed;

    public Movement movementScript;
    public CountdownPlayer countDownPlayer;
	// Use this for initialization
	void Start () 
    {
        Initialize();
    }
	
	public void StartGame()
    {
        StartUpdating();
        gameStarted = true;
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
        if (tutorial == true && shortTutorial == true)
        {
            TutorialCheck();
        }
        if(movementScript.inputIsGiven == true)
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

    public void TutorialCheck()
    {
        if(current_Interval_Count == 10)
        {
            movementScript.DisableShoe();
            tutorial = false;
        }
        else
        {
           
        }
    }

}
