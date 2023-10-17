
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private GameObject player;
    private PlayerController _playerController;
    private GameObject _spawnPoint;
    
    private void Awake()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn"); 
        player = GameObject.Find("Player");
        _playerController = player.GetComponent<PlayerController>();
        
        _playerController.CurrentHealth = _playerController.MaxHealth;
        _playerController.CurrentMana = _playerController.MaxMana;
        _playerController.Revive();

        _playerController.transform.position = _spawnPoint.transform.position;

    }

 

}
