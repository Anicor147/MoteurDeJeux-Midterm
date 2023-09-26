using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject playerPosition;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = playerPosition.transform.position + new Vector3(0, 0, -10);
    }
}
