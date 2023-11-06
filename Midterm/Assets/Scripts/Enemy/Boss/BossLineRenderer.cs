using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class BossLineRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    [SerializeField] private int numberOfPoints;
    [SerializeField] private float height = 0.5f;
    [SerializeField] private float speed;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        CircleLine();
    }

    private void CircleLine()
    {
        _lineRenderer.positionCount = numberOfPoints;
        Vector3[] linePosition = new Vector3[_lineRenderer.positionCount];

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            var t = i / (float)(_lineRenderer.positionCount - 1);
            angle = t * Mathf.PI * 2f;
           
            float x = Mathf.Cos(Time.time * speed) * radius;
            float y = Mathf.Sin(Time.time * speed) * radius;
         
            Vector3 controlPoint = new Vector3(x, height, 0);
            Vector3 endPoint = new Vector3(x, y, 0);
            Vector3 bezierPoint = Bezier(transform.position, controlPoint, endPoint, t);
            linePosition[i] = bezierPoint;
        }

        _lineRenderer.SetPositions(linePosition);
    }

    private Vector3 Bezier(Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (1 - t) * (1 - t) * p1 + 2 * (1 - t) * t * p2 + t * t * p3;
    }
    
    
    
    
}
