using UnityEngine;
using System.Collections;
using UnityEngine.Animations;



public class AniCTR : MonoBehaviour
{
    //AnimationClip
    //[SerializeField] AnimationClip[] animations;
    private Animator anim;
    private Animator animStepMachine;
    public GameObject ChildObject; //ChildEffect Input
    public GameObject StepMachine; //StepMachine Input

    private GameObject EffectObject; //gamestart effect
    private GameObject StepAnimatedMachine; // step machine of minecart

    public StepUpSceneManager sceneManager;


    void Start()
    {
        anim = this.GetComponent<Animator>();
        StepAnimatedMachine = GameObject.Find(StepMachine.name);
        animStepMachine = StepAnimatedMachine.GetComponent<Animator>();
        EffectObject = gameObject.transform.Find(ChildObject.name).gameObject;
        EffectObject.SetActive(false);
           
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            if (sceneManager.gameStarted == false)
            {
                GameStart();

            }

            if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
            {
                StartCoroutine("RightStep");
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            if (sceneManager.gameStarted == false)
            {
                GameStart();

            }

            if (sceneManager.gameStarted == true && sceneManager.gameFinished == false)
            {
                StartCoroutine("LeftStep");
            }
        }

        if (sceneManager.gameFinished == true)
        {
            Goal();

        }

    }


    public IEnumerator RightStep()
    {
        anim.SetBool("RightStep", true);
        anim.SetBool("LeftStep", false);

        yield return new WaitForSeconds(0.05f);
        animStepMachine.SetBool("Right",true);
        animStepMachine.SetBool("Left",false);
    }

    public IEnumerator LeftStep()
    {
        anim.SetBool("LeftStep",true);
        anim.SetBool("RightStep", false);

        yield return new WaitForSeconds(0.05f);
        animStepMachine.SetBool("Left", true);
        animStepMachine.SetBool("Right", false);
    }

    public void GameStart()
    {

        anim.SetTrigger("Ride");
        EffectObject.SetActive(true);
    }

    public void Goal()
    {
        anim.SetTrigger("Goal");
    }
}