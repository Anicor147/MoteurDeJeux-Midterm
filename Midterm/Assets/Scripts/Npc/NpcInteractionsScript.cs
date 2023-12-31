using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcInteractionsScript : MonoBehaviour
{
    private Vector3 distance;
    private GameObject player;
    private float npcRange =1f;
    private bool menuIsOpen;
    public GameObject canvas;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        distance = player.transform.position - transform.position;

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, distance, npcRange);
        Debug.DrawRay(transform.position, distance, Color.blue);
        if (hit2D.collider != null && hit2D.collider.CompareTag("Player"))
        {
            Debug.DrawRay(transform.position, distance, Color.green);
            OpenLevelingScreen();
        }
    }

    private void OpenLevelingScreen()
    {
        Transform childTransform = canvas.transform.Find("LevelingBorder");
        GameObject screenLeveling = childTransform.gameObject;
        
        if (Input.GetKeyDown(KeyCode.E)&&!menuIsOpen)
        {
            Time.timeScale = 0f;
            screenLeveling.SetActive(true);
            menuIsOpen = true; 
        }
        else if (Input.GetKeyDown(KeyCode.E) && menuIsOpen)
        { 
            Time.timeScale = 1f;
            screenLeveling.SetActive(false);
            menuIsOpen = false;  
        }
    }
    
}
