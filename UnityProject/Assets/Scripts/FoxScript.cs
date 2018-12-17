using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxScript : MonoBehaviour
{
    Animator FoxAnimation;
    float MoveSpeed = 3.0f;
    public GameObject Player;
    bool reachPoint = false;
    float DeleteTime = 0.0f;

    public GameObject Dragon_model;
    float DragonAnimationSpeed = 1.0f;
    Animator DragonAnimation;

    // Start is called before the first frame update
    void Start()
    {
        FoxAnimation = this.GetComponent<Animator>();
        DragonAnimation = Dragon_model.GetComponent<Animator>();
        IdleAnimationCTR();
        Dragon_model.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveFox();
        if(Player.transform.position.z >= 128.0f)
        {
            reachPoint = true;
        }
    }

    void MoveFox()
    {
        if (!reachPoint)
        {
            if ((this.transform.position.z - Player.transform.position.z) <= 15)
            {
                var target = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 20);
                var RotatePosion = Quaternion.LookRotation(target - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, RotatePosion, Time.deltaTime * MoveSpeed); //RotateToPlayer
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * MoveSpeed); //MoveToPoint
                WalkAnimationCTR();
            }
            else
            {
                IdleAnimationCTR();
            }
        }
        else if (reachPoint)
        {
            Dragon_model.gameObject.SetActive(true);


            DeleteTime += Time.deltaTime;
            RunAnimationCTR();
            var target = new Vector3(this.transform.position.x, this.transform.position.y, Player.transform.position.z + 50);
            var RotatePosion = Quaternion.LookRotation(target - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, RotatePosion, Time.deltaTime * MoveSpeed); //RotateToPlayer
            MoveSpeed = 8.0f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * MoveSpeed); //MoveToPoint
            //Debug.Log("Time = "+ DeleteTime);

            if (DeleteTime >= 8f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void WalkAnimationCTR()
    {
        FoxAnimation.SetBool("Walk", true);
        FoxAnimation.SetBool("Run", false);
        FoxAnimation.SetBool("Idle", false);
    }

    void IdleAnimationCTR()
    {
        FoxAnimation.SetBool("Walk", false);
        FoxAnimation.SetBool("Run", false);
        FoxAnimation.SetBool("Idle", true);
        var targetPosition = new Vector3(Player.transform.position.x, 0,Player.transform.position.z);
        var FoxPosion = new Vector3(this.transform.position.x, 0,this.transform.position.z);
        var RotatePosion = Quaternion.LookRotation(targetPosition - FoxPosion);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, RotatePosion, Time.deltaTime *2.0f);
    }

    void RunAnimationCTR()
    {
        FoxAnimation.SetBool("Walk", false);
        FoxAnimation.SetBool("Run", true);
        FoxAnimation.SetBool("Idle", false);
    }

    void DragonAnimationCTR()
    {

    }
}
