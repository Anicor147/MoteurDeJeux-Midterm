using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
     private GameObject _player;
     private GameObject _spawnPoint;
     private PlayerController _playerController;


    private void Start()
    { 
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn"); 
        _player = GameObject.FindWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        
        _playerController.transform.position = _spawnPoint.transform.position;
    }

    private void Update()
    {
        LoadOnDead();
        CheckEnemy();
        
    }

    public void LoadOnDead()
    {
        var playerController = _player.GetComponent<PlayerController>();
        
        if(playerController.PlayerIsDead) LoadLevel(1);
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
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;

                if (nextSceneIndex <= SceneManager.sceneCountInBuildSettings - 1)
                {
                    LoadLevel(nextSceneIndex);
                }
                else
                {
                    Debug.Log("No more scenes to load.");
                    
                }
                
                
            }
        
    }

    public void LoadLevel(int sceneIndex)
    {

        switch (sceneIndex)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3 :
                SceneManager.LoadScene(3);
                break;
            case 4:
                SceneManager.LoadScene(4);
                break;
            case 5:
                SceneManager.LoadScene(5);
                break;
        }
    }

   
}
