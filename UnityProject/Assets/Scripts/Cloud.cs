using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private float TimeCount = 0.0f; //Time of false Cloud
    public float PlayerReachPosition = 0.0f; //currentplayerposition
    public float MovingPosition =0.0f;
    public GameObject Player;
    private float MovingSpeed;
    private bool CountTimer;

	// Use this for initialization
	void Start () {
        CountTimer = false;
        this.gameObject.SetActive(true);
        MovingSpeed = Random.Range(2.3f, 4.0f);

    }
	
	// Update is called once per frame
	void Update () {

        CloudMoving();

        if (CountTimer)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount >= 10f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void CloudMoving()
    {
        if(Player.transform.position.z >= PlayerReachPosition)
        {
            CountTimer = true;
            var targetPosition = new Vector3(this.transform.position.x + MovingPosition, this.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * MovingSpeed);
        }
    }
}
