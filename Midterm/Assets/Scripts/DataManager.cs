using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    private PlayerController _playerController;
    private PlayerUpgradeManager _playerUpgradeManager;
    private MainMenuScript _mainMenuScript;
    private PlayerData data = new PlayerData();

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveDataToJson();
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadDataFromJson();
        }
    }

    private void Start()
    {
        Debug.Log("DataManager Awake");
        _playerController = PlayerController.instance;
    }
    
    public void SaveDataToJson()
    {
        _playerController = PlayerController.instance;
        _mainMenuScript = MainMenuScript.instance;
        
        data._savePlayerName = _mainMenuScript.PlayerName;
        data._saveMaxHealth = _playerController.MaxHealth;
        data._saveMaxMana = _playerController.MaxMana;
        data._saveCurrency = _playerController.Currency;
        data._saveUnlockLightningWeapon = _playerController.UnlockLightningWeapon;
        data._saveUnlockIceWeapon = _playerController.UnlockIceWeapon;
        data._saveBurnUnlock = _playerController.BurnedUnlock;
        data._saveCurrentHealthUpgradeLevel = _playerController._currentHealthUpgradeLevel;
        data._saveCurrentManaUpgradeLevel = _playerController._currentManaUpgradeLevel;
        data._saveBurnIsBought = _playerController._burnIsBought;
        data._saveIceIsBought = _playerController._iceIsBought;
        data._saveLightningIsBought = _playerController._lightningIsBought;
        
        var dataToJson = JsonUtility.ToJson(data);
        var filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, dataToJson);
        Debug.Log("Save as been made");
    }

    public void LoadDataFromJson()
    {
        var filePath = Application.persistentDataPath + "/PlayerData.json";
        var dataFromoJson = System.IO.File.ReadAllText(filePath);
        data = JsonUtility.FromJson<PlayerData>(dataFromoJson);
        Debug.Log("data has been Loaded");
        
        _playerController = PlayerController.instance;
        _mainMenuScript = MainMenuScript.instance;
        
        _mainMenuScript.PlayerName = data._savePlayerName;
        _playerController.MaxHealth = data._saveMaxHealth;
        _playerController.MaxMana = data._saveMaxMana;
        _playerController.Currency = data._saveCurrency;
        _playerController.UnlockLightningWeapon = data._saveUnlockLightningWeapon;
        _playerController.UnlockIceWeapon = data._saveUnlockIceWeapon;
        _playerController.BurnedUnlock = data._saveBurnUnlock;
        _playerController._currentHealthUpgradeLevel = data._saveCurrentHealthUpgradeLevel;
        _playerController._currentManaUpgradeLevel = data._saveCurrentManaUpgradeLevel;
        _playerController._burnIsBought = data._saveBurnIsBought;
        _playerController._iceIsBought = data._saveIceIsBought;
        _playerController._lightningIsBought = data._saveLightningIsBought;
    }

}

[System.Serializable]
public class PlayerData
{
    public string _savePlayerName;
    public float _saveMaxHealth;
    public float _saveMaxMana;
    public int _saveCurrency;
    public int _saveCurrentHealthUpgradeLevel;
    public int _saveCurrentManaUpgradeLevel;
    public bool _saveUnlockIceWeapon;
    public bool _saveUnlockLightningWeapon;
    public bool _saveBurnUnlock;
    public bool _saveBurnIsBought;
    public bool _saveIceIsBought; 
    public bool _saveLightningIsBought;
}


