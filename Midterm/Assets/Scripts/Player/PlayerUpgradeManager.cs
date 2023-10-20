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
    private PlayerController _playerController;
    /*public int _currentHealthUpgradeLevel = 1;
    public int _currentManaUpgradeLevel = 1;
    public bool _burnIsBought;
    public bool _iceIsBought;
    public bool _lightningIsBought;*/
    //public bool BurnedUnlock { get; set; }
    [SerializeField] private TMP_Text _healthPriceText;
    [SerializeField] private TMP_Text _manaPriceText;
    [SerializeField] private TMP_Text _iceWeaponPriceText;
    [SerializeField] private TMP_Text _lightningWeaponPriceText;
    [SerializeField] private TMP_Text _burnEffectText;
    public static PlayerUpgradeManager instance;    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("PlayerUpgradeManager Awake");
    }

    private void Start()
    {
        _playerController = PlayerController.instance;
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
                _playerController.MaxHealth += upgrade.lifePointUpgrade;
                _playerController.MaxMana += upgrade.manaPointUpgrade;
                _playerController.CurrentMana = _playerController.MaxMana;
                _playerController.CurrentHealth = _playerController.MaxHealth;
            }
        }
    }

    public void UpgradeHealthButtonPressed()
    {
        switch (_playerController._currentHealthUpgradeLevel)
        {
            case 1:
                FirstUpgradeHealth();
                _playerController._currentHealthUpgradeLevel++;
                break;
            case 2:
                SecondUpgradeHealth();
                _playerController._currentHealthUpgradeLevel++;
                break;
            case 3 :
                ThirdUpgradeHealth();
                break;
        }
    }
    
    public void UpgradeManaButtonPressed()
    {
        switch (_playerController._currentManaUpgradeLevel)
        {
            case 1:
                FirstUpgradeMana();
                _playerController._currentManaUpgradeLevel++;
                break;
            case 2:
                SecondUpgradeMana();
                _playerController._currentManaUpgradeLevel++;
                break;
            case 3 :
                ThirdUpgradeMana();
                break;
        }
    }

    public void FirstUpgradeHealth()
    {
        if (_playerController.Currency >= 100)
        {
            _playerController.Currency -= 100;    
            UpgradeStats(0);
            _healthPriceText.text = "300";
        }
    }

    public void SecondUpgradeHealth()
    {
        if (_playerController.Currency >= 300)
        {
            _playerController.Currency -= 300;    
            UpgradeStats(0);
            _healthPriceText.text = "600";
        }   
    }

    public void ThirdUpgradeHealth()
    {
        if (_playerController.Currency >= 600)
        {
            _playerController.Currency -= 600;    
            UpgradeStats(0);
        }
    }

    private void FirstUpgradeMana()
    {
        if (_playerController.Currency >= 100)
        {
            _playerController.Currency -= 100;    
            UpgradeStats(1);
            _manaPriceText.text = "300";
        }
    }

    private void SecondUpgradeMana()
    {
        if (_playerController.Currency >= 300)
        {
            _playerController.Currency -= 300;    
            UpgradeStats(1);
            _manaPriceText.text = "600";
        }
    }

    private void ThirdUpgradeMana()
    {
        if (_playerController.Currency >= 600)
        {
            _playerController.Currency -= 600;    
            UpgradeStats(1);
        }
    }

    public void UnlockIce()
    {
        if (_playerController.Currency >=200 && !_playerController._iceIsBought)
        {
            _playerController.UnlockIceWeapon = true;
            _playerController.Currency -= 200;
            _iceWeaponPriceText.text = "Bought";
            _playerController._iceIsBought = true;
        }
    }
    
    public void UnlockLightning()
    {
        if (_playerController.Currency >= 400 && !_playerController._lightningIsBought)
        {
            _playerController.UnlockLightningWeapon = true;
            _playerController.Currency -= 400;
            _lightningWeaponPriceText.text = "Bought";
            _playerController._lightningIsBought = true;
        }
    }

    public void UnlockBurnEffect()
    {
        if (_playerController.Currency >= 200 && !_playerController._burnIsBought)
        {
            _playerController.BurnedUnlock = true;    
            _playerController.Currency -= 200;
            _burnEffectText.text = "Bought";
            _playerController._burnIsBought = true;
        }
        else if (_playerController._burnIsBought)
        {
            _burnEffectText.text = "Bought";
        }
    }

}
