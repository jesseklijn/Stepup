using System;
using System.Collections;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconTest : MonoBehaviour {

    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private float Accel = 3f;
    //private Joycon.Button? m_pressedButtonL;
    //private Joycon.Button? m_pressedButtonR;

    public JoyconManager _joyconManager;
    public GameObject Hand_L;
    public GameObject Hand_R;
    public Transform HandBackPositionL;
    public Transform HandBackPositionR;
    //private GameObject NearestObj_R;
    //private GameObject NearestObj_L;

    private AudioSource _attackSE;
    private float Hand_Timer = 0.0f;
    private float AttackDuration = 0.15f;
    private float TargetToDistance = 0.01f;
    private float MoveSpeed = 30f;
    private float NonAttackRange = 4f;
    private float SmoothMove_Hand;
    private float ScaleFactor_Hand = 2f;
    bool ReachPoint_R;
    bool ReachPoint_L;

    Animator rAnim, lAnim;
    public bool rCoolingDown, lCoolingDown;

    public bool testing;
    


    // Use this for initialization
    void Start()
    {
        _attackSE = gameObject.GetComponent<AudioSource>();

        rCoolingDown = false;
        lCoolingDown = false;

        rAnim = Hand_R.GetComponent<Animator>();
        lAnim = Hand_L.GetComponent<Animator>();

        //Search Switch Joycon and info
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);

        //Check Connect Joycons
        if (m_joycons == null || m_joycons.Count <= 0)
        {
            Debug.Log("No Connect Joy-Con");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!testing)
        {
            if(m_joycons == null || m_joycons.Count <= 0) 
            {
                Debug.LogError("NO JOYCONS CONNECTED! Switching to Testing Mode");
                testing = true;
            }
        }

        if(!testing)
        {
            Vector3 JoyConL_Accel = m_joyconL.GetAccel();
            Vector3 JoyConR_Accel = m_joyconR.GetAccel();
            
            if (JoyConR_Accel.magnitude >= Accel || Input.GetKeyDown(KeyCode.J))
            {
                PlayJoyconHand_R();
            }
            else if (JoyConL_Accel.magnitude >= Accel|| Input.GetKeyDown(KeyCode.F)) 
            {
                PlayJoyconHand_L();
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayJoyconHand_R();
        }
        else if (Input.GetKeyDown(KeyCode.G)) 
        {
            PlayJoyconHand_L();
        }

    }

    void PlayJoyconHand_R() //Move  R Hand Object
    {
        if(!rCoolingDown)
        {
            rAnim.SetTrigger("punch");
            _attackSE.Play();
            Debug.Log("RightPunch!");
            StartCoroutine(rPunchCooldown());
        }
    }

    void PlayJoyconHand_L() //Move  R Hand Object
    {
        if(!lCoolingDown)
        {
            lAnim.SetTrigger("punch");
            _attackSE.Play();
            Debug.Log("LeftPunch!");
            StartCoroutine(lPunchCooldown());
        }
    }

    IEnumerator rPunchCooldown()
    {
        rCoolingDown = true;
        yield return new WaitForSeconds(0.75f);
        rCoolingDown = false;
    }

    IEnumerator lPunchCooldown()
    {
        lCoolingDown = true;
        yield return new WaitForSeconds(0.75f);
        lCoolingDown = false;
    }
}

