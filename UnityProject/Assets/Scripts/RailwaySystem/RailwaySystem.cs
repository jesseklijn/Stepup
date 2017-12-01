using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailwaySystem : MonoBehaviour
{

    public List<Point> pointList = new List<Point>();

    public LineRenderer lineRenderer;

    public Vector3[] pointPositions;
    public Vector3[] pointRotations;


    private void Start()
    {
        DrawLines(pointList);
    }

    //private void FixedUpdate()
    //{
    //    DrawLines(pointList);
    //}

    public void ConnectPoint(List<Point> points)
    {

        for (int i = 0; i < points.Count; i++)
        {

        }
    }

    public void DrawLines(List<Point> points)
    {
        pointPositions = new Vector3[points.Count];
        pointRotations = new Vector3[points.Count];
        for (int i = 0; i < points.Count; i++)
        {
            pointPositions[i] = points[i].transform.position;
            pointRotations[i] = points[i].transform.eulerAngles;
        }

        lineRenderer.positionCount = pointPositions.Length;
        lineRenderer.SetPositions(pointPositions);
    }

    public Vector3[] GivePointPositions()
    {
        return pointPositions;
    }
}
