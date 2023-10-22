
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
        _playerController = PlayerController.instance;
    }

    private void Start()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        _playerController.transform.position = _spawnPoint.transform.position;
        
        _playerController.CurrentHealth = _playerController.MaxHealth;
        _playerController.CurrentMana = _playerController.MaxMana;
        _playerController.Revive();

    }    
}
