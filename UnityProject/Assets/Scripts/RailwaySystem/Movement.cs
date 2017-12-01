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

    public CameraMovement cameraMovement;

    public RailwaySystem railwaySystem;

    public GameObject toMove;

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
                else if (rightShoe == false)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) == true)
                    {
                        leftShoe = false;
                        rightShoe = true;

                        Move();
                    }
                }
            }
        }
    }


    public void Move()
    {
        int index = cameraMovement.IndexOfInt(railwaySystem.pointPositions, currentPoint.transform.position);
        Debug.Log(index);
        if (index + 1 != railwaySystem.pointPositions.Length)
        {


            StartCoroutine(cameraMovement.MoveTowardsClosestWayPoint(currentPoint.transform.position, railwaySystem.pointPositions[index + 1], 5, toMove));
            toMove.transform.LookAt(railwaySystem.pointList[index + 1].transform);
            currentPoint = railwaySystem.pointList[index + 1];

            //rotating
            
            //int count = 0;

            //for (int i = index; i < railwaySystem.pointRotations.Length; i++)
            //{
               
            //    if (count == 3)
            //    {
            //        break;

            //    }
            //    count++;
                
            //}
            //rotations = new Vector3[count];
            //count = 0;

            //for (int i = index; i < railwaySystem.pointRotations.Length; i++)
            //{

            //    if (count == 3)
            //    {
            //        break;

            //    }

            //    rotations[count] = railwaySystem.pointRotations[i];

            //    count++;
            //}

            //StartCoroutine(cameraMovement.RotateTowardsClosestWayPoint(currentPoint.transform.position, railwaySystem.pointPositions[index + 1], 2, toMove));
        }
    }
}
