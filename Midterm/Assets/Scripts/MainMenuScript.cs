using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    private GameObject audio;
    private AudioSource audioSource;
    [SerializeField] private Slider musicSlider;
    private bool pressed;
    
    public void LoadLevelShop()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OpenSetting()
    {
        setting.SetActive(true);
    }

    
}
