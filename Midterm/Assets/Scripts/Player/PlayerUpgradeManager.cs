using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerUpgradeManager : MonoBehaviour
{
    public UpgradeListSO listOfUpgrade;
    private GameObject player;
    private PlayerController playerController;
    private int _currentHealthUpgradeLevel = 1;
    private int _currentManaUpgradeLevel = 1;
    private bool _burnIsBought , _iceIsBought , _lightningIsBought;
    public bool BurnedUnlock { get; set; }
    [SerializeField] private TMP_Text _healthPriceText;
    [SerializeField] private TMP_Text _manaPriceText;
    [SerializeField] private TMP_Text _iceWeaponPriceText;
    [SerializeField] private TMP_Text _lightningWeaponPriceText;
    [SerializeField] private TMP_Text _burnEffectText;
    public static PlayerUpgradeManager instance;    

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
        playerController = PlayerController.instance;
        _healthPriceText.text = "100";
        _manaPriceText.text = "100";
        _iceWeaponPriceText.text = "200";
        _lightningWeaponPriceText.text = "400";
        _burnEffectText.text = "200";
    }

    public void UpgradeStats(int index)
    {
        foreach (var upgrade in listOfUpgrade.listOfUpgrade)
        {
            if (index == upgrade.index)
            {
                playerController.MaxHealth += upgrade.lifePointUpgrade;
                playerController.MaxMana += upgrade.manaPointUpgrade;
                playerController.CurrentMana = playerController.MaxMana;
                playerController.CurrentHealth = playerController.MaxHealth;
            }
        }
    }

    public void UpgradeHealthButtonPressed()
    {
        switch (_currentHealthUpgradeLevel)
        {
            case 1:
                FirstUpgradeHealth();
                _currentHealthUpgradeLevel++;
                break;
            case 2:
                SecondUpgradeHealth();
                _currentHealthUpgradeLevel++;
                break;
            case 3 :
                ThirdUpgradeHealth();
                break;
        }
    }
    
    public void UpgradeManaButtonPressed()
    {
        switch (_currentManaUpgradeLevel)
        {
            case 1:
                FirstUpgradeMana();
                _currentManaUpgradeLevel++;
                break;
            case 2:
                SecondUpgradeMana();
                _currentManaUpgradeLevel++;
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
            UpgradeStats(0);
            _healthPriceText.text = "300";
        }
    }

    public void SecondUpgradeHealth()
    {
        if (playerController.Currency >= 300)
        {
            playerController.Currency -= 300;    
            UpgradeStats(0);
            _healthPriceText.text = "600";
        }   
    }

    public void ThirdUpgradeHealth()
    {
        if (playerController.Currency >= 600)
        {
            playerController.Currency -= 600;    
            UpgradeStats(0);
        }
    }

    private void FirstUpgradeMana()
    {
        if (playerController.Currency >= 100)
        {
            playerController.Currency -= 100;    
            UpgradeStats(1);
            _manaPriceText.text = "300";
        }
    }

    private void SecondUpgradeMana()
    {
        if (playerController.Currency >= 300)
        {
            playerController.Currency -= 300;    
            UpgradeStats(1);
            _manaPriceText.text = "600";
        }
    }

    private void ThirdUpgradeMana()
    {
        if (playerController.Currency >= 600)
        {
            playerController.Currency -= 600;    
            UpgradeStats(1);
        }
    }

    public void UnlockIce()
    {
        if (playerController.Currency >=200 && !_iceIsBought)
        {
            playerController.UnlockIceWeapon = true;
            playerController.Currency -= 200;
            _iceWeaponPriceText.text = "Bought";
            _iceIsBought = true;
        }
    }
    
    public void UnlockLightning()
    {
        if (playerController.Currency >= 400 && !_lightningIsBought)
        {
            playerController.UnlockLightningWeapon = true;
            playerController.Currency -= 400;
            _lightningWeaponPriceText.text = "Bought";
            _lightningIsBought = true;
        }
    }

    public void UnlockBurnEffect()
    {
        if (playerController.Currency >= 200 && !_burnIsBought)
        {
            BurnedUnlock = true;    
            playerController.Currency -= 200;
            _burnEffectText.text = "Bought";
            _burnIsBought = true;
        }
    }

}
