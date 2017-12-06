using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMManager : MonoBehaviour
{

    public bool isCounting = false;

    public float _INTENDED_BPM = 100;
    public float _FULL_GAME_CYCLE = 60;

    //To calculate maximum and minimum BPM
    public float MIN_MAX_MULTIPLIER = 0.5F;

    public float MIN_BPM = 0;
    public float MAX_BPM = 150;

    public float _INTERVAL = 0.6F;
    public float SECOND = 1.0F;
    public float _BPM_DROP = 1.67F;

    public float current_Interval_Count = 0;
    public float current_BPM = 100;

    //graphics
    public float GRAPHICALMULTIPLIER = 0.1F;
    public Vector3 current_Position;
    public float STEP = 1;

    public LineRenderer lineRenderer;

    public IEnumerator BPM_UPDATE(float INTERVAL)
    {
        if (isCounting == false)
        {

            isCounting = true;

            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / INTERVAL;

                //Update every frame
                BPMUPDATE();

                yield return 0;
            }


            current_Interval_Count += SECOND;


            //Update after counting to display / modify speed etc
            Interval();



            //Reset Routine
            isCounting = false;

            //Check if count is reached
            if (current_Interval_Count != _INTENDED_BPM)
            {
                StartCoroutine(BPM_UPDATE(_INTERVAL));
            }
        }

    }

    public virtual void BPMUPDATE()
    {
        //Every cycle do something


    }
    public virtual void Interval()
    {

        //After every interval

        //increase size of line renderer position array
        SetSizeLineRenderer((int)current_Interval_Count + 1, lineRenderer);

        //Calculate new current position
        current_Position = CalculateNewPosition(current_Position, STEP, GRAPHICALMULTIPLIER);

        //Assign new position
        SetNewPosition(current_Position, (int)current_Interval_Count, lineRenderer);


    }


    public void Initialize()
    {
        //BPM Settings
        _INTERVAL = CalculateBPM_INTERVAL(_INTENDED_BPM, _FULL_GAME_CYCLE);
        MAX_BPM = CalculateMAX_BPM(MIN_MAX_MULTIPLIER, _INTENDED_BPM);
        GRAPHICALMULTIPLIER = Calculate_Step_Multiplier(_INTENDED_BPM);
        _BPM_DROP = CalculateBPM_DROP(_INTENDED_BPM);
        current_BPM = Set_Current_BPM(_INTENDED_BPM);
    }

    public void StartUpdating()
    {
        //Start counting
        StartCoroutine(BPM_UPDATE(_INTERVAL));
    }

    public Vector3 CalculateNewPosition(Vector3 currentPos, float step, float multiplier)
    {
        Vector3 newPosition = new Vector3(currentPos.x + (step * multiplier), currentPos.y, currentPos.z);
        return newPosition;
    }

    public void SetNewPosition(Vector3 newPosition, int index, LineRenderer lineRenderer)
    {
        lineRenderer.SetPosition(index, newPosition);
    }

    public void SetSizeLineRenderer(int size, LineRenderer lr)
    {
        lr.positionCount = size;
    }

    public float Set_Current_BPM(float intended_BPM)
    {
        return intended_BPM;

    }

    public float CalculateBPM_INTERVAL(float intended_BPM, float full_Game_Cycle)
    {
        float interval = full_Game_Cycle / intended_BPM;

        return interval;
    }
    public float CalculateBPM_DROP(float intended_BPM)
    {
        float bpm_Drop = intended_BPM / intended_BPM;

        return bpm_Drop;
    }
    public float Calculate_Step_Multiplier(float intended_BPM)
    {
        float scale = intended_BPM * (intended_BPM / 10);

        float newMultiplier = intended_BPM / scale;

        return newMultiplier;
    }
    public float CalculateMAX_BPM(float multiplier, float intended_BPM)
    {
        intended_BPM += (intended_BPM * multiplier);
        return intended_BPM;
    }


}
