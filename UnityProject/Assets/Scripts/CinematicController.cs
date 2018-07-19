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
	

	// Use this for initialization
	void Update () 
	{
		if(Input.GetKey(KeyCode.P))
		{
			PrioCam(1);
			PlayCinematic(0);
		}

		// if(Input.GetKey(KeyCode.O))
		// {
		// 	PrioCam(0);
		// 	PlayCinematic(1);
		// }
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
}
