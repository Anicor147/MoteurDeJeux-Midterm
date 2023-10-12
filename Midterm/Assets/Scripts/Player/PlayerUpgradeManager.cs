using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerUpgradeManager : MonoBehaviour
{
    public UpgradeListSO listOfUpgrade;
    public PlayerController playerController;
    private int _currentUpgradeLevel = 1;
    [SerializeField] private TMP_Text _healthPriceText;
    [SerializeField] private TMP_Text _manaPriceText;
    [SerializeField] private TMP_Text _iceWeaponPriceText;
    [SerializeField] private TMP_Text _lightningWeaponPriceText;
    

    private void Start()
    {
        _healthPriceText.text = "100";
        _manaPriceText.text = "100";
        _iceWeaponPriceText.text = "200";
        _lightningWeaponPriceText.text = "400";
    }

    public void UpgradeStats(int index)
    {
        foreach (var upgrade in listOfUpgrade.listOfUpgrade)
        {
            if (index == upgrade.index)
            {
                playerController.MaxHealth += upgrade.lifePointUpgrade;
                playerController.MaxMana += upgrade.manaPointUpgrade;
            }
        }
        Debug.Log($"Current Character Max Health is = {playerController.MaxHealth}");
        Debug.Log($"Current Character Max Mana is = {playerController.MaxMana}");
    }

    // Not official
    public void UpgradeHealthButtonPressed()
    {
        switch (_currentUpgradeLevel)
        {
            case 1:
                FirstUpgradeHealth();
                _healthPriceText.text = "300";
                break;
            case 2:
                SecondUpgradeHealth();
                _healthPriceText.text = "600";
                break;
            case 3 :
                ThirdUpgradeHealth();
                break;
        }
    }
    
    public void UpgradeManaButtonPressed()
    {
        switch (_currentUpgradeLevel)
        {
            case 1:
                FirstUpgradeMana();
                _manaPriceText.text = "300";
                break;
            case 2:
                SecondUpgradeMana();
                _manaPriceText.text = "600";
                break;
            case 3 :
                ThirdUpgradeMana();
                break;
        }
    }

    public void FirstUpgradeHealth()
    {
        if (playerController.Currency >= 100)
        {
            playerController.Currency -= 100;    
            UpgradeStats(1);
        }
    }

    public void SecondUpgradeHealth()
    {
        if (playerController.Currency >= 300)
        {
            playerController.Currency -= 300;    
            UpgradeStats(2);
        }   
    }

    public void ThirdUpgradeHealth()
    {
        if (playerController.Currency >= 600)
        {
            playerController.Currency -= 600;    
            UpgradeStats(3);
        }
    }

    private void FirstUpgradeMana()
    {
        if (playerController.Currency >= 100)
        {
            playerController.Currency -= 100;    
            UpgradeStats(4);
        }
    }

    private void SecondUpgradeMana()
    {
        if (playerController.Currency >= 300)
        {
            playerController.Currency -= 300;    
            UpgradeStats(5);
        }
    }

    private void ThirdUpgradeMana()
    {
        if (playerController.Currency >= 600)
        {
            playerController.Currency -= 600;    
            UpgradeStats(6);
        }
    }

    public void UnlockIce()
    {
        if (playerController.Currency >=200)
        {
            playerController.UnlockIceWeapon = true;
            playerController.Currency -= 200;
        }
    }
    
    public void UnlockLightning()
    {
        if (playerController.Currency >= 400)
        {
            playerController.UnlockLightningWeapon = true;
            playerController.Currency -= 400;
        }
    }
}
