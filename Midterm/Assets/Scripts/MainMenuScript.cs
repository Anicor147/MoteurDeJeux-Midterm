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
    private bool inMainMenu = true;
    public bool LoadCheck { get; set; }
    public bool SaveCheck { get; set; }
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject backToMenuButton;
    [SerializeField] private GameObject SaveButton;
    [SerializeField] private GameObject credits;

    private bool pressed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void LoadLevelShop()
    {
        inMainMenu = false;
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
        if (inMainMenu)
        {
            setting.SetActive(true);
            backToMenuButton.SetActive(false);
            SaveButton.SetActive(false);
        }
        else if (!inMainMenu)
        {
            setting.SetActive(true);
            backToMenuButton.SetActive(true);
            SaveButton.SetActive(true);
            Time.timeScale = 0f;
        }

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

    public void LoadIsPressed()
    {
        LoadCheck = true;
        LoadLevelShop();
    }

    public void SaveDataButton()
    {
        SaveCheck= true;
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

    public void BackToMenu()
    {
        DestroyDontDestroyOnLoadObjects();
        SceneManager.LoadScene(0);
    }
    public void DestroyDontDestroyOnLoadObjects()
    {
        DontDestroyOnLoad[] objectsWithScript = FindObjectsOfType<DontDestroyOnLoad>();

        foreach (DontDestroyOnLoad obj in objectsWithScript)
        {
            Destroy(obj.gameObject);
        }
    }
}
