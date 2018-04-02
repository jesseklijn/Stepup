using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreator : MonoBehaviour {
    public GameObject FireBall;
    public float MaxX, MinX;
    public float MaxZ, MinZ;
    public float Rate;
    public int Max_FireBall = 30;
    List<GameObject> objs = new List<GameObject>();
    float CreateCounter = 0.0f;
    const float ONESECOND = 1.0f;
    bool CreateFlag = false;

    bool Play = false;

    public GameObject Player;
    bool Passing = false; 
    void Start () {
		
	}
	
	
	void Update () {
        
        if (Play)
        {
            CreateCounter += Time.deltaTime;

            if (CreateCounter > ONESECOND / Rate || CreateFlag)
            {
                CreateCounter = 0.0f;
                CreateFlag = true;
                Create();
            }
        }
   
        if (Passing)
        {
            return;
        }

        if (Player.transform.position.z > 35)
        {
            Play = true;
            Passing = false;
        }
    }

    void LateUpdate()
    {
        Optimize();
    }

    void Create(){

        if (objs.Count >= Max_FireBall)
            return;

        CreateFlag = false;
        float X = Random.Range(MinX, MaxX);
        float Y = gameObject.transform.position.y;
        float Z = Random.Range(MinZ, MaxZ);
        
        GameObject tmp = (GameObject)Instantiate(FireBall, new Vector3(X, Y, Z), Quaternion.identity);
        objs.Add(tmp);
    }

    void Optimize()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            GameObject g = objs[i];
            if (objs[i].GetComponent<FireBallController>().Dead)
            {
                objs.RemoveAt(i);
                Destroy(g);
            }

        }
    }
}
