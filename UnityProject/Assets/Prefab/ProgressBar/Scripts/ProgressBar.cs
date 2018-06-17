using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public GameObject progressFill;
	private float max_progress;
	
	
	// void Start()
	// {
	// 	StartProgressingBar(5, 0.25f);
	// }

	public void StartProgressingBar(int timeToComplete, float cv_value)
	{
		max_progress = CalculateProgress(cv_value);
		StartCoroutine(Progress(timeToComplete));
	}

	float CalculateProgress(float _cv)
	{
		float mProgress = 1; //Bar Full

		if(_cv > mProgress)
		{
			mProgress = 0;
		}
		else
		{
			mProgress -= _cv; //Make the bar less full if CV is higher than 0
		}

		return mProgress;
	}
	
	IEnumerator Progress(float time)
	{
		float rate = max_progress / time;
		float i = 0;
		while (i < max_progress)
		{
			i += Time.deltaTime * rate;
			progressFill.GetComponent<Renderer>().material.SetFloat("_Progress", i);
			yield return 0;
		}
	}
}