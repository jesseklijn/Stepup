using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    public Point B;

    private void Awake()
    {
        transform.LookAt(B.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.5F);
        Gizmos.DrawLine(transform.position, B.transform.position);
    }
}
