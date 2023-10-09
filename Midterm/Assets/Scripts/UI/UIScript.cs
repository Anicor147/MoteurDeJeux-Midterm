using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private PlayerController _playerController;

    
    public void Update()
    {
        HealthBar();
    }

    public void HealthBar()
    {
        healthSlider.value = _playerController.MaxHealth;
        manaSlider.value = _playerController.MaxMana;
    }


}

