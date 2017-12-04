using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{

    public Point currentPoint;

    public bool isMoving = false;
    public bool isRotating = false;

    public bool leftShoe = false;
    public bool rightShoe = false;

    //Tutorial
    public GameObject LeftShoe;
    public GameObject RightShoe;
    public GameObject textStart;

    public CameraMovement cameraMovement;

    public RailwaySystem railwaySystem;

    public GameObject toMove;

    public float Duration;

    public Vector3[] rotations;

    private void Update()
    {
        if (isMoving == false)
        {
            if (leftShoe == false || rightShoe == false)
            {
                if (leftShoe == false)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
                    {
                        rightShoe = false;
                        leftShoe = true;


                        Move();

                    }
                }
                if (rightShoe == false)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) == true)
                    {
                        leftShoe = false;
                        rightShoe = true;

                        Move();
                      
                    }
                }
            }
            DisplayShoe();
        }
        else
        {
            DisableShoe();
        }
        

    }

    public void DisplayShoe()
    {
        if (isMoving == false)
        {
            if (leftShoe == true)
            {
                //Disable icon
                LeftShoe.SetActive(false);
            }
            else
            {
                //Enable icon
                LeftShoe.SetActive(true);
            }
            if (rightShoe == true)
            {
                //Disable icon
                RightShoe.SetActive(false);
            }
            else
            {
                //Enable Icon
                RightShoe.SetActive(true);
            }
        }
    }
    public void DisableShoe()
    {
        LeftShoe.SetActive(false);
        RightShoe.SetActive(false);
        textStart.SetActive(false);
    }
    public void Move()
    {
        int index = cameraMovement.IndexOfInt(railwaySystem.pointPositions, currentPoint.transform.position);

        if (index + 1 != railwaySystem.pointPositions.Length)
        {


            StartCoroutine(cameraMovement.MoveTowardsClosestWayPoint(currentPoint.transform.position, railwaySystem.pointPositions[index + 1], Duration, toMove));
            StartCoroutine(cameraMovement.RotateTowardsClosestWayPoint(currentPoint.transform.rotation.eulerAngles, railwaySystem.pointRotations[index + 1], 2, toMove));
            currentPoint = railwaySystem.pointList[index + 1];

            //rotating

            //toMove.transform.LookAt(railwaySystem.pointList[index + 1].transform);

            //int count = 0;

            
        }
    }
}
