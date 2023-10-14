using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    private GameObject _player;


    private void Start()
    { 
        
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        LoadOnDead();
        CheckEnemy();
        
    }

    public void LoadOnDead()
    {
        var playerController = _player.GetComponent<PlayerController>();
        
        if(playerController.PlayerIsDead) Invoke("LoadLevelShop" ,2);
        playerController.PlayerIsDead = false;
    }

    public void CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

       
            if (enemies.Length > 0)
            {
               Debug.Log("still have enemy");
            }
            else
            {
                Invoke("LoadLevelShop" , 2f );
            }
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    } 
    public void LoadLevelShop()
    {
        SceneManager.LoadScene(1);
    }
}
