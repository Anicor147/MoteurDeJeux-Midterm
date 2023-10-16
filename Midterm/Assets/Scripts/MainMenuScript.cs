using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance;
    [SerializeField] private GameObject setting;

    private bool pressed;
    
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadLevelShop()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pressed)
        {
            pressed = true;
            setting.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pressed)
        {
            pressed = false;
            setting.SetActive(false);
        }
    }


    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    
    
    public void CloseSetting()
    {
        setting.SetActive(false);
    }
    

    
}
