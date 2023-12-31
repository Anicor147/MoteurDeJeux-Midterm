using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
     private GameObject _player;
     private GameObject _spawnPoint;
    


    private void Start()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        PlayerController.instance.transform.position = _spawnPoint.transform.position;
    }

    private void Update()
    {
        CheckEnemy();
    }
    
    public void CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
            if (enemies.Length <= 0)
            {
                Invoke("CallForDelay" , 2f);
            }
    }


   public  void CallForDelay()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex <= SceneManager.sceneCountInBuildSettings - 1)
        {
            LoadLevel(nextSceneIndex);
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
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
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
