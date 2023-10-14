
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private GameObject player;
    private PlayerController _playerController;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        
        
        
    }
    
    
    
}
