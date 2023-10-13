using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthAdapter : MonoBehaviour
{
    static int counter;
    int myCounter;
    private void Awake()
    {
        myCounter = counter++;
    }

    private void Update()
    {
        var pos = transform.position;

        pos.z = transform.position.y * 0.01f + myCounter * 0.0001f;

        transform.position = pos;
    }
}
