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
    [SerializeField] private TMP_Text moneyCounter;

    public void Update()
    {
        PlayerBars();
        PlayerCurrency();
    }

    public void PlayerBars()
    {
        manaSlider.value = _playerController.MaxMana;
        healthSlider.value = _playerController.MaxHealth;
    }

    public void PlayerCurrency()
    {
        moneyCounter.text = _playerController.Currency.ToString();
    }


}

