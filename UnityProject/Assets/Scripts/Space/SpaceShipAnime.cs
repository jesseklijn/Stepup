using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAnime : MonoBehaviour {

	// Use this for initialization
	public float TriggerLineZ;
	GameObject[] ships;
	int shipSu;
	Transform playerTrans;

	public float spinLineX = 15;
	public float speed = 2;

	void Start () {
		shipSu = Random.Range (1, 10);
		ships = new GameObject[shipSu];
		for (int i = 0; i < shipSu; i++) {
			ships [i] = Instantiate (gameObject, transform.position - i*15 * transform.forward, transform.rotation);
			Destroy(ships[i].GetComponent<SpaceShipAnime>());
		}


		playerTrans = GameObject.Find ("Player/Camera Panel").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z - playerTrans.position.z <= TriggerLineZ)
			foreach (GameObject obj in ships) {
				obj.transform.Translate (speed * transform.forward,Space.World);
				if(Mathf.Abs(obj.transform.position.x)<=spinLineX){
					obj.transform.Rotate(transform.forward,360*(speed/(spinLineX*2)),Space.World);
				}
			}
	}
}
