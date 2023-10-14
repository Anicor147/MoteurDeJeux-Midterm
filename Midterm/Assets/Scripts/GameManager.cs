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
        PlayerController playerController = _player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        test();
    }


    public void test()
    {
        PlayerController playerController = _player.GetComponent<PlayerController>();
       if(playerController.PlayerIsDead) Invoke("LoadLevelShop" ,2);
       playerController.PlayerIsDead = false;
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
