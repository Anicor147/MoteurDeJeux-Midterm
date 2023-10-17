using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance;
    [SerializeField] private TMP_InputField playerNameField;
    private string playerName;
    public string PlayerName { get; set; }
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject credits;

    private bool pressed;
    
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadLevelShop()
    {
        PlayerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pressed)
        {
            pressed = true;
            OpenSetting();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pressed)
        {
            pressed = false;
            CloseSetting();
        }
    }


    public void OpenSetting()
    {
        setting.SetActive(true);
        Time.timeScale = 0f;
    }
    
    
    public void CloseSetting()
    {
        setting.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
        Time.timeScale = 0f;
    }
    
    
    public void CloseCredits()
    {
        credits.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

}
