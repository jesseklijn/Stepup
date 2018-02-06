using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsManager : MonoBehaviour 
{
	public GameObject ruby, sapphire, diamond;
	public List<GameObject> gemsList = new List<GameObject>();

	private Vector3 startPos = new Vector3(-5.19311f+5.003111f, -2.59837f+2.560376f, -1.5f);

	void Start () 
	{
		gemsList.Add(ruby);
		SpawnGem();
		gemsList.Add(sapphire);
		SpawnGem();
		gemsList.Add(diamond);
		SpawnGem();
	}

	public void AddGemToList(double cv)
	{
		if(cv >= 1)
		{
			gemsList.Add(ruby);
		}
		else if(cv <= 0.6)
		{
			gemsList.Add(diamond);
		}
		else
		{
			gemsList.Add(sapphire);
		}
	}

	public void SpawnGem()
	{
		int i = gemsList.Count-1;
		Instantiate(gemsList[i], new Vector3(startPos.x, startPos.y, startPos.z + (1.5f*i)), Quaternion.identity);
	}
	
	
}
