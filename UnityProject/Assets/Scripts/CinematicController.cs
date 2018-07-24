using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CinematicController : MonoBehaviour 
{
	public List<CinemachineVirtualCamera> camList;
	public List<TimelineAsset> cinematics;

	public PlayableDirector director;

	public bool introDoing = false, introDone = false, turnDoing = false;

	void OnEnableScan()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
			introDone = true;
			Debug.Log("DIRECTOR HAS QUIT!!!");
			OnDisableScan();
		}
    }	

	// Use this for initialization
	void Update () 
	{
		if((Input.GetKey(KeyCode.LeftArrow) && introDoing == false) || (Input.GetKey(KeyCode.RightArrow ) && introDoing == false) )
		{
			introDoing = true;
			OnEnableScan();

			PrioCam(1);
			PlayCinematic(0);
		}
	}

	public void PlayCinematic(int cinematicNumber)
	{
		director.Play(cinematics[cinematicNumber]);
	}

	
	// Update is called once per frame
	public void PrioCam(int camNumber) 
	{
		for(int i = 0; i < camList.Count; i++)
		{
			if(i == camNumber)
			{
				camList[i].Priority = 10;
			}
			else
			{
				camList[i].Priority = 0;
			}
		}
	}

	void OnDisableScan()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
}
