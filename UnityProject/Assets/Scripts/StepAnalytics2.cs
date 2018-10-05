using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StepAnalytics2 : MonoBehaviour 
{
	private const float CompareIsZeroTolerance = 0.000000000001f;

	private String sceneName;
	private double _cv, _lcv, _rcv, _currentCV;
	private List<double> TimeStamps = new List<double>();
	private List<double> LeftTimeStamps = new List<double>();
	private List<double> RightTimeStamps = new List<double>();
	public List<double> RecentTimeStamps = new List<double>();
	public List<double> RestTimes = new List<double>();
	public List<double> RestFrames = new List<double>();
	public List<double> LegAngles = new List<double>();
	public float avgAngle;
	//private List<string> feet = new List<string>();
	private List<string[]> rowData = new List<string[]>();

	public double bpm;
	public float happyMeterInterval;

	void Start()
	{
		sceneName = SceneManager.GetActiveScene().name;
	}

	void OnApplicationQuit()
    {
		//Save();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

	public void AddRest(float _restTime, float _restFrames)
	{
		RestTimes.Add(_restTime);
		RestFrames.Add(_restFrames);

		Debug.LogWarning("CURRENT REST WAS: " + _restTime + " seconds and " + _restFrames + " frames.");
	}

	public void AddTimeStamp (float time, string foot) 
	{
		if(foot == "Left")
		{
			if(!(LeftTimeStamps.Count == 0))
			{
				LeftTimeStamps.Add(time-(LeftTimeStamps[LeftTimeStamps.Count-1]));
			}
			else
			{
				LeftTimeStamps.Add(time);
			}

			if(!(TimeStamps.Count == 0))
			{
				TimeStamps.Add(time-(TimeStamps[TimeStamps.Count-1]));
				RecentTimeStamps.Add(time-(TimeStamps[TimeStamps.Count-1]));
			}
			else
			{
				TimeStamps.Add(time);
				RecentTimeStamps.Add(time);
			}
		}

		else if(foot == "Right")
		{
			if(!(RightTimeStamps.Count == 0))
			{
				RightTimeStamps.Add(time-(RightTimeStamps[RightTimeStamps.Count-1]));
			}
			else
			{
				RightTimeStamps.Add(time);
			}
			if(!(TimeStamps.Count == 0))
			{
				TimeStamps.Add(time-(TimeStamps[TimeStamps.Count-1]));
				RecentTimeStamps.Add(time-(TimeStamps[TimeStamps.Count-1]));
			}
			else
			{
				TimeStamps.Add(time);
				RecentTimeStamps.Add(time);
			}
			
		}
		
		//feet.Add(foot);
	}

	public Double GetCurrentCV()
	{
		_currentCV = ConvertToCV(RecentTimeStamps);
		return _currentCV;
	}


	public Double GetCV()
	{
		_lcv = ConvertToCV(LeftTimeStamps);
		_rcv = ConvertToCV(RightTimeStamps);
		_cv = (_lcv + _rcv)/2;

		return _cv;
	}

	public bool IsAmountOfstepsAcceptable()
	{
		double _beatsPerInterval = bpm/60 * happyMeterInterval;
		float _beatsMargin = 2;

		if(RecentTimeStamps.Count <= _beatsPerInterval + _beatsMargin &&  RecentTimeStamps.Count >= _beatsPerInterval - _beatsMargin)
		{
			Debug.Log("Acceptable because; " + RecentTimeStamps.Count + "is between the margins of: " + _beatsPerInterval);
			return true;
		}
		else
		{
			Debug.Log("NOT Acceptable because; " + RecentTimeStamps.Count + "is NOT between the margins of: " + _beatsPerInterval);
			return false;
		}
	}

	public void Save(){

		Debug.Log(TimeStamps.Count);

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[6];
        rowDataTemp[0] = "cv";
        rowDataTemp[1] = "lcv";
		rowDataTemp[2] = "rcv";
		rowDataTemp[3] = "SceneName";
		rowDataTemp[4] = "StepsAmount";
		rowDataTemp[5] = "LegAngle";
        rowData.Add(rowDataTemp);

		//ConvertToCV(TimeStamps);
		_lcv = ConvertToCV(LeftTimeStamps);
		Debug.Log(_lcv);
		_rcv = ConvertToCV(RightTimeStamps);
		Debug.Log(_rcv);
		_cv = (_lcv + _rcv)/2;
		Debug.Log(_cv);

		CalculateAngle(RestTimes, RestFrames);

		rowDataTemp = new string[6];
        rowDataTemp[0] = _cv.ToString();
		rowDataTemp[1] = ""+_lcv;
		rowDataTemp[2] = _rcv.ToString();
		rowDataTemp[3] = sceneName;
		rowDataTemp[4] = TimeStamps.Count.ToString();
		rowDataTemp[5] = avgAngle.ToString();
		rowData.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++)
		{
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.AppendText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }
 
	public double ConvertToCV(List<double> data)
	{
		double mean = data.Mean();
		double sd = data.StandardDeviation(); 

		double cv = CoefficientOfVariance(sd, mean);

		//Change from seconds to beats
		cv = cv * (bpm/60);

		//Debug.Log("CV:" + cv +"mean: " + mean + "sd: " + sd);

		return cv;
	}
		
	public static double CoefficientOfVariance(double sd, double mean)
	{
		if (Math.Abs(mean - 0) < CompareIsZeroTolerance) return 0;
		return sd / mean;
	}

    // Following method is used to retrive the relative path as device platform
    private string getPath()
	{
        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Saved_data.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
        #else
        return Application.dataPath +"/"+"Saved_data.csv";
        #endif
    }

	private void CalculateAngle(List<double> _RestTimes, List<double> _RestFrames)
	{
		for(int i = 0; i < _RestTimes.Count; i++)
		{
			float mHeight = 0; // the height in degree of the leg being raised.
			float mRestTime = (float) _RestTimes[i]; //time that both feet are on the ground.
			float mRestFrames = (float) _RestFrames[i]; //frames that both feet are on the ground.
			float mBpm = (float) bpm;

			mHeight = (180.262f-406.435f) * (mRestTime / mRestFrames) - 0.652f * mBpm;
			LegAngles.Add(mHeight);
		}

		for(int j = 0; j < LegAngles.Count; j++)
		{
			avgAngle += (float) LegAngles[j];
		}

		avgAngle = avgAngle / LegAngles.Count;
	}
	
}

public static class MyListExtensions
{

	public static double Mean(this List<double> values)
	{
		return values.Count == 0 ? 0 : values.Mean(0, values.Count);
	}

	private static double Mean(this IList<double> values, int start, int end)
	{
		double s = 0;

		for (int i = start; i < end; i++)
		{
			s += values[i];
		}

		return s / (end - start);
	}

	private static double Variance(this IList<double> values, double mean, int start, int end)
	{
		double variance = 0;
		int i;
		for (i = start; i < end; i++)
		{
			variance += Math.Pow((values[i] - mean), 2);
		}

		int n = end - start;
		if (start > 0) n -= 1;
		return variance / (n);
	}

	public static double StandardDeviation(this List<double> values)
	{
		return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
	}

	private static double StandardDeviation(this IList<double> values, int start, int end)
	{
		double mean = values.Mean(start, end);
		double variance = values.Variance(mean, start, end);

		return Math.Sqrt(variance);
	}
}
