using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour 
{
	Animator anim;

	void Start()
    {
        anim = this.GetComponent<Animator>();  
		anim.SetTrigger("Ride");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {    
			StartCoroutine("RightStep");      
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        { 
			StartCoroutine("LeftStep");
        }

    }

    public IEnumerator RightStep()
    {
		Debug.Log("Stepped Right");
        anim.SetBool("RightStep", true);
        anim.SetBool("LeftStep", false);

        yield return new WaitForSeconds(0.05f);
    }

    public IEnumerator LeftStep()
    {
		Debug.Log("Stepped Left");
        anim.SetBool("LeftStep",true);
        anim.SetBool("RightStep", false);

        yield return new WaitForSeconds(0.05f);
    }
}
