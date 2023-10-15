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
    [SerializeField] private GameObject fireWeapon;
    [SerializeField] private GameObject iceWeapon;
    [SerializeField] private GameObject lightningWeapon; 
    [SerializeField] private GameObject lightningBorder; 
    [SerializeField] private GameObject iceBorder; 
    [SerializeField] private GameObject fireBorder;
    [SerializeField] private TMP_Text manaValue;
    [SerializeField] private TMP_Text healthValue;
    private Dictionary<GameObject, GameObject> weaponBorders = new Dictionary<GameObject, GameObject>();

    public static UIScript instance;
    private void Awake()
    {
        Debug.Log("CanvasManager Awake");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        PlayerBars();
        PlayerCurrency();
        CheckWeaponActive();
    }

    public void Start()
    {
        AddToWeaponBorders();
    }

    public void AddToWeaponBorders()
    {
        weaponBorders = new Dictionary<GameObject, GameObject>();
        weaponBorders.Add(fireWeapon , fireBorder);
        weaponBorders.Add(iceWeapon , iceBorder);
        weaponBorders.Add(lightningWeapon , lightningBorder);
    }

    public void PlayerBars()
    {
        manaSlider.maxValue = _playerController.MaxMana;
        manaSlider.value = _playerController.CurrentMana;
        manaValue.text = _playerController.CurrentMana.ToString();
        healthSlider.value = _playerController.CurrentHealth;
        healthValue.text = _playerController.CurrentHealth.ToString();
    }

    public void PlayerCurrency()
    {
        moneyCounter.text = _playerController.Currency.ToString();
    }

    public void CheckWeaponActive()
    {
        foreach (var border in weaponBorders)
        {
            if (border.Key != null && border.Value != null)
            {
                border.Value.SetActive(border.Key.activeSelf);
            }
        }
    }

}

