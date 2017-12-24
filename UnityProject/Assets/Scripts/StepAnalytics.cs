using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class StepAnalytics : MonoBehaviour {

	private List<float> timestamps = new List<float>();
	private List<string> feet = new List<string>();
	private List<string[]> rowData = new List<string[]>();

	// Use this for initialization
	void Start () 
	{

	}

	void OnApplicationQuit()
    {
		Save();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
	
	public void AddTimeStamp (float time, string foot) 
	{
		timestamps.Add(time);
		feet.Add(foot);
	}

	 void Save(){

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[2];
        rowDataTemp[0] = "time";
        rowDataTemp[1] = "foot";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for(int i = 0; i < timestamps.Count; i++){
            rowDataTemp = new string[3];
            rowDataTemp[0] = timestamps[i].ToString(); // the time
            rowDataTemp[1] = feet[i]; // which foot
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++){
            output[i] = rowData[i];
        }

        int     length         = output.GetLength(0);
        string     delimiter     = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.AppendText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(){
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
}
