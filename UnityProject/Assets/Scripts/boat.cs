using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{

    public StepUpSceneManager sceneManager;

    public float amplitude = 0.003f;
    public float floatingTime = 0.05f;
    public GameObject Wheel;
    Animator Wheelanim;


    void Start()
    {
        Wheelanim = Wheel.GetComponent<Animator>();
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, amplitude * Mathf.Sin(Time.frameCount * floatingTime) + transform.position.y, transform.position.z); //boat floationg moves

        if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {

                StartCoroutine("Wheelmoves");

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {

                StartCoroutine("Wheelmoves");

            }
        }
    }

    IEnumerator Wheelmoves()
    {
        Wheelanim.SetBool("Wheel", true);
        Wheelanim.SetBool("BackMotion", false);
        yield return new WaitForSeconds(1f);
        Wheelanim.SetBool("Wheel", false);
        Wheelanim.SetBool("BackMotion", true);
    }

}