using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMeter : MonoBehaviour 
{
	public GameObject goodFace, greatFace, goodText, greatText;
	private double currentCV;

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

	
	public void PopUpHappyMeter(double _CV) 
	{
		currentCV = _CV;
		StartCoroutine(VisualizeMeter());
	}

	public IEnumerator VisualizeMeter() 
	{

		if(currentCV > 0.7f)
		{
			goodFace.active = true;
			greatFace.active = false;
			goodText.active = true;
			greatText.active = false;

			yield return new WaitForSeconds(3f);
			Reset();

		}
		else if(currentCV <= 0.7f)
		{
			goodFace.active = false;
			greatFace.active = true;
			goodText.active = false;
			greatText.active = true;

			yield return new WaitForSeconds(3f);
			Reset();
		}
	}
}
