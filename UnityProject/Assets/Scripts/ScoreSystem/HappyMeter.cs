using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMeter : MonoBehaviour 
{
	public GameObject goodFace, greatFace, goodText, greatText;
	private bool acceptability;

	// Use this for initialization
	void Start () 
	{
		Reset();
	}

	void Reset()
	{
		goodFace.active = false;
		greatFace.active = false;
		goodText.active = false;
		greatText.active = false;
	}

	
	public void PopUpHappyMeter(bool _acceptable) 
	{
		acceptability = _acceptable;
		StartCoroutine(VisualizeMeter());
	}

	public IEnumerator VisualizeMeter() 
	{

		if(!acceptability) //GOOD
		{
			goodFace.active = true;
			greatFace.active = false;
			goodText.active = true;
			greatText.active = false;
			
			Singleton.audioController.PlayVoice(false);

			yield return new WaitForSeconds(3f);
			Reset();

		}
		else if(acceptability) //GREAT
		{
			goodFace.active = false;
			greatFace.active = true;
			goodText.active = false;
			greatText.active = true;

			Singleton.audioController.PlayVoice(true);

			yield return new WaitForSeconds(3f);
			Reset();
		}
	}
}
