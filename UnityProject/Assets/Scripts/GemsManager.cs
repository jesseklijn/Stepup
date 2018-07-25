using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsManager : MonoBehaviour 
{
	public GameObject ruby, sapphire, diamond;
	public List<GameObject> gemsList = new List<GameObject>();
	public GameObject player;

	private Vector3 spawnPos;

	void Start () 
	{
		// gemsList.Add(ruby);
		// SpawnGem();
		// gemsList.Add(sapphire);
		// SpawnGem();
		spawnPos = new Vector3(-5.19311f+5.003111f, -2.59837f+2.560376f, player.transform.position.z + 3);
		gemsList.Add(diamond);
		SpawnGem(true);
	}

	public void AddGemToList() //give the CV as an argument for different types of gems.
	{
		spawnPos = new Vector3(-5.19311f+5.003111f, player.transform.position.y, player.transform.position.z + 8);
		gemsList.Add(diamond);

		// if(cv >= 1)
		// {
		// 	gemsList.Add(ruby);
		// }
		// else if(cv <= 0.6)
		// {
		// 	gemsList.Add(diamond);
		// }
		// else
		// {
		// 	gemsList.Add(sapphire);
		// }
	}

	public void SpawnGem(bool _pickupAble)
	{
		int i = gemsList.Count-1;
		gemsList[i].GetComponent<Gem>().pickupAble = _pickupAble;

		if(!_pickupAble)
		{
			gemsList[i].GetComponent<BoxCollider>().center = new Vector3(0, 0.05268659f, -0.6f);
		}
		else
		{
			gemsList[i].GetComponent<BoxCollider>().center = new Vector3(0, 0.05268659f, -0.18f);
		}
		Instantiate(gemsList[i], new Vector3(spawnPos.x, spawnPos.y, spawnPos.z), Quaternion.identity);
	}
	
	
}
