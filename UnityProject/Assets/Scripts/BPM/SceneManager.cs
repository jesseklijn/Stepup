using UnityEngine;

public class SceneManager : BPMManager {

    public bool inputIsGiven = false;

    public float timePassed;

	// Use this for initialization
	void Start () {
        Initialize();

        StartUpdating();
    }
	
	// Update is called once per frame
	void Update () {

     
    }

    public override void BPMUPDATE()
    {
        base.BPMUPDATE();
        timePassed += Time.deltaTime * 1;
    }

    public override void Interval()
    {
        base.Interval();

        if(inputIsGiven == true)
        {
            //move forward
        }
        else
        {
            //lower bpm
            current_BPM -= _BPM_DROP;
        }

    }
}
