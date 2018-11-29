using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] waves;
    //public GameObject Enemies;
    private GameObject[] tagObjects;
    private int currentWave;
    private float WaitTimes;

    public StepUpSceneManager sceneManager;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("InstantiateWaves");
    }

    // Update is called once per frame
    /*void Update()
    {

    }
    */

    public IEnumerator InstantiateWaves()
    {
        while (sceneManager.gameStarted == false)
            {
                yield return new WaitForEndOfFrame();
            }

        if (waves.Length == 0)
            {
                yield break;
            }


            while (true)
            {
                WaitTimes = Random.Range(2, 8);
                currentWave = Random.Range(0, waves.Length);

                // Instantiate waves
                Debug.Log("InstantiateWaves!");
                yield return new WaitForSeconds(WaitTimes);
                GameObject player = GameObject.FindGameObjectWithTag("Shun");
                Vector3 InstantiatePosition = new Vector3(0, 0, 20);
                GameObject wave = Instantiate(waves[currentWave], InstantiatePosition + transform.TransformDirection(player.transform.position), Quaternion.identity);

                // Make Wave a child element of EnemyManager (GameObject)
                wave.transform.parent = transform;

                // Wait until all enemies of Wave's child elements are deleted

                //destroy wave
                while (wave.transform.childCount != 0)
                {
                    yield return new WaitForEndOfFrame();
                }

                Destroy(wave);

            }
        }

        /*    void Check(string tagname)
            {
                tagObjects = GameObject.FindGameObjectsWithTag(tagname);
                if (tagObjects.Length == 0)
                {
                    Debug.Log(tagname + "There is no object attached this tag");
                }
            }
        */
        }
