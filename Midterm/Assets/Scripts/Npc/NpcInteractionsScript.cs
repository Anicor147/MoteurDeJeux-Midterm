using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteractionsScript : MonoBehaviour
{
    private Vector3 distance;
    private GameObject player;
    private float npcRange =1f;
    private bool menuIsOpen;
    [SerializeField] public GameObject levelingScreen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        distance = player.transform.position - transform.position;

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, distance, npcRange);
        if (hit2D.collider != null && hit2D.collider.CompareTag("Player"))
        {
            Debug.Log($"player hit");
            OpenLevelingScreen();
        }
    }

    private void OpenLevelingScreen()
    {
        if (Input.GetKeyDown(KeyCode.E)&&!menuIsOpen)
        {
            levelingScreen.gameObject.SetActive(true);
            menuIsOpen = true;
        }else if (Input.GetKeyDown(KeyCode.E) && menuIsOpen)
        {
            levelingScreen.gameObject.SetActive(false);
            menuIsOpen = false;
        }
    }
    
}
