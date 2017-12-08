using UnityEngine;

public class SceneManager : BPMManager {

    
    public bool gameStarted = false;
    public float timePassed;

    public Movement movementScript;
    public CountdownPlayer countDownPlayer;
	// Use this for initialization
	void Start () {
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
}
