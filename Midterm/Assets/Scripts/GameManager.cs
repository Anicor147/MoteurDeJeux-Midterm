using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        test();
    }


    public void test()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadLevel1();
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
