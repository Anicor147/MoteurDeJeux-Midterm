using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private PlayerController _playerController;
    private WeaponController _weaponController;
    private PlayerUpgradeManager _playerUpgradeManager;
    
    private float _saveMaxHealth, _saveMaxMana;
    private int _saveCurrency , _saveCurrentHealthUpgradeLevel, _saveCurrentManaUpgradeLevel;
    private bool _saveUnlockIceWeapon , _saveUnlockLightningWeapon ,_saveBurnIsBought , _saveIceIsBought , _saveLightningIsBought;


    private void Start()
    {
        _playerController = PlayerController.instance;
        _weaponController = WeaponController.instance;
        _playerUpgradeManager = PlayerUpgradeManager.instance;
    }


    private void SaveDataOnVariable()
    {
        _saveMaxHealth = _playerController.MaxHealth ;
        _saveMaxMana = _playerController.MaxMana;
        _saveCurrency = _playerController.Currency;
        /*_saveCurrentHealthUpgradeLevel = _playerUpgradeManager;
        _saveCurrentManaUpgradeLevel;
        _saveUnlockIceWeapon;
        _saveUnlockLightningWeapon;
        _saveBurnIsBought;
        _saveIceIsBought;
        _saveLightningIsBought;*/
    }



}



