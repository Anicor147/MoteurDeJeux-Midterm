using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject playerPosition;
    [SerializeField] private float zoomOut = -10f;
    public static CameraMovement instance;
    private void Awake()
    {
     
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = playerPosition.transform.position + new Vector3(0, 0, zoomOut);
    }
}
