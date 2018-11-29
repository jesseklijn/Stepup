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
    private float Accel = 2.2f;

    public JoyconManager _joyconManager;
    public GameObject Hand_L;
    public GameObject Hand_R;
    private float Time_Hand;
    GameObject[] EnemiesCount;
    private AudioSource _attackSE;
    private GameObject AttackEnemies_L;
    private GameObject AttackEnemies_R;

    public GameObject Hand_L_Effect;
    public GameObject Hand_R_Effect;

    Animator rAnim, lAnim;
    public bool rCoolingDown, lCoolingDown;

    public bool testing;
    


    // Use this for initialization
    void Start()
    {
        Hand_L_Effect.SetActive(false);
        Hand_R_Effect.SetActive(false);


        Time_Hand = 0.0f;
        _attackSE = gameObject.GetComponent<AudioSource>();

        rCoolingDown = false;
        lCoolingDown = false;
        testing = false;

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
        Time_Hand += Time.deltaTime;
        EnemiesCount = GameObject.FindGameObjectsWithTag("EnemyObject");
        if (EnemiesCount.Length >= 1)
        {
            AttackEnemy();
        }

        if (!testing)
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
        if (Time_Hand >= 0.2f)
        {
            if (!rCoolingDown)
            {
                rAnim.SetTrigger("punch");
                _attackSE.Play();
                Hand_R_Effect.SetActive(true);
                Debug.Log("RightPunch!");
                StartCoroutine(rPunchCooldown());
            }
        }

    }

    void PlayJoyconHand_L() //Move  R Hand Object
    {
        if (Time_Hand >= 0.2f)
        {
            if (!lCoolingDown)
            {
                lAnim.SetTrigger("punch");
                _attackSE.Play();
                Hand_L_Effect.SetActive(true);
                Debug.Log("LeftPunch!");
                StartCoroutine(lPunchCooldown());
            }
        }
    }

    IEnumerator rPunchCooldown()
    {
        rCoolingDown = true;
        yield return new WaitForSeconds(0.2f);
        Hand_R_Effect.SetActive(false);
        rCoolingDown = false;
        Time_Hand = 0.0f;
    }

    IEnumerator lPunchCooldown()
    {
        lCoolingDown = true;
        yield return new WaitForSeconds(0.2f);
        Hand_L_Effect.SetActive(false);
        lCoolingDown = false;
        Time_Hand = 0.0f;
    }

    void AttackEnemy()
    {
        AttackEnemies_L = searchTag(Hand_L, "EnemyObject");
        AttackEnemies_R = searchTag(Hand_R, "EnemyObject");

        if (Vector3.Distance(Hand_L.transform.position, AttackEnemies_L.transform.position) <= 0.6f)
        {
            m_joyconL.SetRumble(160, 320, 0.8f, 200);
        }
        if (Vector3.Distance(Hand_R.transform.position, AttackEnemies_R.transform.position) <= 0.6f)
        {
            m_joyconR.SetRumble(160, 320, 0.8f, 200);
        }

    }

    GameObject searchTag(GameObject nowObj, string tagName) //search nearest Object with tag
    {
        float tmpDis = 0;
        float nearDis = 0;
        GameObject targetObj = null;
        //Tag Retrieve the specified object as an array
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //Get the distance between this itself and the acquired object
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        return targetObj; //Get the closest object in the tag

    }
}

