using System;
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


    // Use this for initialization
    void Start()
    {

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

        ReachPoint_R = false;
        ReachPoint_L = false;
    }

    // Update is called once per frame
    void Update()
    {
        SmoothMove_Hand = MoveSpeed * Time.deltaTime;
        Hand_Timer += Time.deltaTime;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        //GetOrientation and InputJoycon
        Quaternion JoyConL_Orient = m_joyconL.GetVector();
        Quaternion JoyConR_Orient = m_joyconR.GetVector();
        Hand_L.transform.rotation = new Quaternion(0, 0, JoyConL_Orient.x, JoyConL_Orient.w);
        Hand_R.transform.rotation = new Quaternion(0, 0, -JoyConR_Orient.x, JoyConR_Orient.w);

        Vector3 JoyConL_Accel = m_joyconL.GetAccel();
        Vector3 JoyConR_Accel = m_joyconR.GetAccel();
        if (JoyConR_Accel.magnitude >= Accel)
        {
            PlayJoyconHand_R();
        }
        else if (JoyConL_Accel.magnitude >= Accel) 
        {
            PlayJoyconHand_L();
        }

        BackHands();


    }

    void BackHands()
    {
        if (ReachPoint_L)
        {
            var posL = Hand_L.transform.position;
            Hand_L.transform.position = Vector3.MoveTowards(posL, HandBackPositionL.transform.position, SmoothMove_Hand);
            Hand_L.transform.localScale = new Vector3(1f, 1f, 1f) * SmoothMove_Hand;
            if (Vector3.Distance(posL, HandBackPositionL.transform.position) < TargetToDistance)
            {
                ReachPoint_L = false;
            }
        }

        else if (ReachPoint_R)
        {
            var posR = Hand_R.transform.position;
            Hand_R.transform.position = Vector3.MoveTowards(posR, HandBackPositionR.transform.position, SmoothMove_Hand);
            Hand_R.transform.localScale = new Vector3(1f, 1f, 1f)* SmoothMove_Hand;
            if (Vector3.Distance(posR, HandBackPositionR.transform.position) < TargetToDistance)
            {
                ReachPoint_R = false;
            }
        }
    }

    void PlayJoyconHand_R() //Move  R Hand Object
    {
        int EnemyCount = GameObject.FindGameObjectsWithTag("EnemyObject").Length; //Count objects with tag "EnemyObject"

        if (Hand_Timer >= AttackDuration)
        {
            _attackSE = gameObject.GetComponent<AudioSource>();
            _attackSE.Play();
            var ForwardPositionR = new Vector3(HandBackPositionR.transform.position.x, HandBackPositionR.transform.position.y, HandBackPositionR.transform.position.z + 1.5f);
            var posR = Hand_R.transform.position;

            if (EnemyCount == 0)
            {
                Hand_R.transform.LookAt(ForwardPositionR);
                Hand_R.transform.localScale = new Vector3(ScaleFactor_Hand, ScaleFactor_Hand, ScaleFactor_Hand) * SmoothMove_Hand;
                Hand_R.transform.position = Vector3.MoveTowards(posR, ForwardPositionR, SmoothMove_Hand);
                if (Vector3.Distance(Hand_R.transform.position, ForwardPositionR) < TargetToDistance)
                {
                    Hand_Timer = 0.0f;
                    ReachPoint_R = true;
                    Debug.Log("RightPunch!");
                }
            }

            else if (EnemyCount >= 1)
            {
                GameObject NearestObj_R = searchTag(Hand_R, "EnemyObject");
                Debug.Log("R" + NearestObj_R);
                Hand_R.transform.LookAt(NearestObj_R.transform);
                Hand_R.transform.localScale = new Vector3(ScaleFactor_Hand, ScaleFactor_Hand, ScaleFactor_Hand) * SmoothMove_Hand;
                float NearestDistance = Vector3.Distance(HandBackPositionR.transform.position, NearestObj_R.transform.position);

                if (NearestDistance <= NonAttackRange)
                {
                    Hand_R.transform.position = Vector3.MoveTowards(posR, NearestObj_R.transform.position, SmoothMove_Hand);
                    if (Vector3.Distance(Hand_R.transform.position, NearestObj_R.transform.position) < TargetToDistance)
                    {
                        m_joyconR.SetRumble(160, 320, 0.6f, 150);
                        Hand_Timer = 0.0f;
                        ReachPoint_R = true;
                    }

                }

                else
                {
                    Hand_R.transform.position = Vector3.MoveTowards(posR, ForwardPositionR, SmoothMove_Hand);
                    if (Vector3.Distance(Hand_R.transform.position, ForwardPositionR) < TargetToDistance)
                    {
                        Hand_Timer = 0.0f;
                        ReachPoint_R = true;
                    }
                }
            }
        }
    }

    void PlayJoyconHand_L() //Move  R Hand Object
    {
        int EnemyCount = GameObject.FindGameObjectsWithTag("EnemyObject").Length; //Count objects with tag "EnemyObject"

        if (Hand_Timer >= AttackDuration)
        {
            _attackSE = gameObject.GetComponent<AudioSource>();
            _attackSE.Play();
            var ForwardPositionL = new Vector3(HandBackPositionL.transform.position.x, HandBackPositionL.transform.position.y, HandBackPositionL.transform.position.z + 1.5f);
            var posL = Hand_L.transform.position;

            if (EnemyCount == 0)
            {
                Hand_L.transform.LookAt(ForwardPositionL);
                Hand_L.transform.localScale = new Vector3(ScaleFactor_Hand, ScaleFactor_Hand, ScaleFactor_Hand) * SmoothMove_Hand;
                Hand_L.transform.position = Vector3.MoveTowards(posL, ForwardPositionL, SmoothMove_Hand);
                if (Vector3.Distance(Hand_L.transform.position, ForwardPositionL) < TargetToDistance)
                {
                    Hand_Timer = 0.0f;
                    ReachPoint_L = true;
                    Debug.Log("LeftPunch 0!");
                }
            }

            else if (EnemyCount >= 1)
            {
                GameObject NearestObj_L = searchTag(Hand_L, "EnemyObject");
                Hand_L.transform.LookAt(NearestObj_L.transform);
                Hand_L.transform.localScale = new Vector3(ScaleFactor_Hand, ScaleFactor_Hand, ScaleFactor_Hand) * SmoothMove_Hand;
                float NearestDistance = Vector3.Distance(HandBackPositionL.transform.position, NearestObj_L.transform.position);

                if (NearestDistance <= NonAttackRange)
                {
                    Hand_L.transform.position = Vector3.MoveTowards(posL, NearestObj_L.transform.position, SmoothMove_Hand);
                    if (Vector3.Distance(Hand_L.transform.position, NearestObj_L.transform.position) < TargetToDistance)
                    {
                        m_joyconL.SetRumble(160, 320, 0.6f, 150);
                        Hand_Timer = 0.0f;
                        ReachPoint_L = true;
                        Debug.Log("LeftPunch 1!");
                    }

                }

                else
                {
                    Hand_L.transform.position = Vector3.MoveTowards(posL, ForwardPositionL, SmoothMove_Hand);
                    if (Vector3.Distance(Hand_L.transform.position, ForwardPositionL) < TargetToDistance)
                    {
                        Hand_Timer = 0.0f;
                        ReachPoint_L = true;
                        Debug.Log("LeftPunch 2!");
                    }
                }
            }
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

