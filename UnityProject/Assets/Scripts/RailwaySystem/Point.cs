using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    public Point B;

    private void Awake()
    {
        if (B != null)
            transform.LookAt(B.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.5F);
        if(B != null)
        Gizmos.DrawLine(transform.position, B.transform.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("point touched");
            other.gameObject.GetComponent<Movement>().currentPoint = this;
            other.gameObject.GetComponent<Movement>().RotateTowardsTarget(B);
            other.gameObject.GetComponent<Movement>().nextPoint = B;
        }
        
    }
}
