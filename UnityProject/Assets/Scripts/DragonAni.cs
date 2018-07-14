using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAni : MonoBehaviour
{

    Animator dra_ani;
    public StepUpSceneManager sceneManager;

    // Use this for initialization
    void Start()
    {
        dra_ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            if (sceneManager.gameStarted == false)
            {
                dra_ani.SetBool("Go", true);

            }

            if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
            {
                dra_ani.SetBool("Fly", true);
                dra_ani.SetBool("Go", false);
            }
        }


            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                if (sceneManager.gameStarted == false)
                {
                    dra_ani.SetBool("Go", true);

                }

                if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
                {
                    dra_ani.SetBool("Fly", true);
                    dra_ani.SetBool("Go", false);
                }
            }

        if (sceneManager.gameFinished == true)
        {
            dra_ani.SetBool("Fly", false);
            dra_ani.SetBool("Goal", true);

        }
    }
    }
