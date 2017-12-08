using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public Movement movement;

    private void Start()
    {

    }

    public IEnumerator Accelerate(float xStart, float yTop, float time)
    {
        Accelerate AccelInstance = gameObject.AddComponent<Accelerate>();

        movement.acceleration.Add(AccelInstance);
        int i = movement.acceleration.IndexOf(AccelInstance);

        //Some fields
        float x = 0;
        float half = time / 2;

        float a = (half - xStart) * (half - time);
        float aFactor = yTop / a;

        float t = 0;
        //Move while time is still below 1
        while (t < 1)
        {

            t += Time.deltaTime / time;
            i = movement.acceleration.IndexOf(AccelInstance);
            x = Mathf.Lerp(xStart, time, t);

            movement.acceleration[i].acceleration = (aFactor * ((x) * (x - time)));

            yield return 0;

        }
      
        //Reset Routine
        movement.acceleration.Remove(AccelInstance);
        Destroy(AccelInstance);

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

                //Check A is positive or negative, change B to be positive or negative if A is negative/positive.

                Vector3 normalized = new Vector3(
                    Mathf.LerpAngle(PointA.x, PointB.x, t),
                    Mathf.LerpAngle(PointA.y, PointB.y, t),
                    Mathf.LerpAngle(PointA.z, PointB.z, t));

                toMove.gameObject.transform.eulerAngles = normalized;



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
