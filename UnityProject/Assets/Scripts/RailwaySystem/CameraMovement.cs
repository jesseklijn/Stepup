using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public Movement movement;

    public IEnumerator MoveTowardsClosestWayPoint(Vector3 PointA, Vector3 PointB, float time, GameObject toMove)
    {
        //Check if character is already moving..
        //Debug.Log(PointA + " # " + PointB);
        if (movement.isMoving == false)
        {

            movement.isMoving = true;

            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / time;
                toMove.gameObject.transform.position = Vector3.Lerp(PointA, PointB, t);


                yield return 0;

            }

            //Reset Routine
            movement.isMoving = false;
        }
    }

    public IEnumerator RotateTowardsClosestWayPoint(Vector3 PointA, Vector3 PointB, float time, GameObject toMove)
    {
        //Check if character is already moving..
        //Debug.Log(PointA + " # " + PointB);
        if (movement.isRotating == false)
        {

            movement.isRotating = true;

            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / time;
                toMove.gameObject.transform.eulerAngles = Vector3.Lerp(PointA, (PointB - PointA), t);


                yield return 0;

            }

            //Reset Routine
            movement.isRotating = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 0.6F);
    }

    public int IndexOfInt(Vector3[] arr, Vector3 value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
}
