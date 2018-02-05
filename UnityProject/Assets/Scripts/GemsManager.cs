using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsManager : MonoBehaviour 
{
	public GameObject ruby, sapphire, diamond;
	public List<GameObject> gemsList = new List<GameObject>();

	private Vector3 startPos = new Vector3(-5.19311f+5.003111f, -2.59837f+2.560376f, 0);

	void Start () 
	{
		gemsList.Add(ruby);
		SpawnGem(gemsList.Count-1);
		gemsList.Add(sapphire);
		SpawnGem(gemsList.Count-1);
		gemsList.Add(diamond);
		SpawnGem(gemsList.Count-1);
	}

	public void AddGemsToList(float cv)
	{
		if(cv == 1)
		{
			gemsList.Add(ruby);
		}
		else if(cv == 2)
		{
			gemsList.Add(sapphire);
		}
		else if(cv == 3)
		{
			gemsList.Add(diamond);
		}
	}

	void SpawnGem(int i)
	{
		Instantiate(gemsList[i], new Vector3(startPos.x, startPos.y, startPos.z + (1*i)), Quaternion.identity);
	}
	
	void Update ()
	{
		
	}
}
