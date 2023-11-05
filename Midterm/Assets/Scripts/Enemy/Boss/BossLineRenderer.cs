using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BossLineRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    
    private void CourbeLine()
    {
        
    }

    private Vector3 Bezier(Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (1 - t) * (1 - t) * p1 + 2 * (1 - t) * t * p2 + t * t * p3;
    }
    
    
    
    
}
