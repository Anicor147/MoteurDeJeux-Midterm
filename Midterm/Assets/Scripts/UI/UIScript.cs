using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class UIScript : MonoBehaviour 
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private PlayerController _playerController;

    public void Update()
    {
        PlayerBars();
    }

    public void PlayerBars()
    {
        manaSlider.value = _playerController.MaxMana;
        healthSlider.value = _playerController.MaxHealth;
    }

    
}

