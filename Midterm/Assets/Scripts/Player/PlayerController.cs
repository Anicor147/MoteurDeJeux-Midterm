using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour , IBaseCharacter
{ 
    [SerializeField] private CharacterSOScript playerStat;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private GameObject iceWeaponObject;
    [SerializeField] private GameObject fireWeaponObject;
    [SerializeField] private GameObject lightingWeaponObject;
    private Dictionary<KeyCode, GameObject> weaponDictionary;
    [SerializeField] private WeaponController WeaponController;
    [SerializeField] private DataManager _dataManager;
    private bool isCharging, unlockIceWeapon,unlockLightningWeapon ;
    public bool isLightning;
    private int currency;
    private float maxHealth,maxMana,currentMana,currentHealth;
    public int _currentHealthUpgradeLevel = 1;
    public int _currentManaUpgradeLevel = 1;
    public bool _burnIsBought;
    public bool _iceIsBought;
    public bool _lightningIsBought;
    public bool BurnedUnlock { get; set; }
    public bool PlayerIsDead { get; set; }
    public static PlayerController instance;

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
        Debug.Log("PlayercontrollerManager Awake");
    }


    public float CurrentMana
    {
        get => currentMana;
        set => currentMana = value;
    } 
    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public float MaxMana
    {
        get => maxMana;
        set => maxMana = value;
    }
    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public bool UnlockIceWeapon
    {
        get => unlockIceWeapon;
        set => unlockIceWeapon = value;
    }
    public bool UnlockLightningWeapon
    {
        get => unlockLightningWeapon;
        set => unlockLightningWeapon = value;
    }

    public int Currency
    {
        get => currency;
        set => currency = value;
    }

    private void Start()
    {
        
        
        MaxHealth = playerStat.lifePoint;
        MaxMana = playerStat.manaPoint;
        CurrentMana = MaxMana;
        CurrentHealth = MaxHealth;

        AddToDictionary();
        DefaultEquipedWeapon();
        if (MainMenuScript.instance.LoadCheck)
        {
            LoadData();
        }
    }

    public void LoadData()
    {
        _dataManager.LoadDataFromJson();
    }

    
    public void SaveData()
    {
        if (MainMenuScript.instance.SaveCheck)
        {
            _dataManager.SaveDataToJson();
        }

        MainMenuScript.instance.SaveCheck = false;
    }
    

    private void Update()
    {
        PlayerIsCharging();
        WeaponsDictionnary();
        SaveData();
    }

   
    public void TakeDamage(float damageReceived , GameObject gameObject)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0) OnDeath();
    }

    public void PlayerIsCharging()
    {
        if (CurrentMana <= MaxMana)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _playerAnimationController.PlayerIsCharging(true);
                CurrentMana += (20 * Time.deltaTime);
            }
            else if (!Input.GetKey(KeyCode.Q))
            {
                _playerAnimationController.PlayerIsCharging(false);
            }
        }
        else
        {
            _playerAnimationController.PlayerIsCharging(false);
        }
    }
    
    public void DefaultEquipedWeapon()
    {
        fireWeaponObject.SetActive(true);
    }

    public void AddToDictionary()
    {
        weaponDictionary = new Dictionary<KeyCode, GameObject>();
        weaponDictionary.Add(KeyCode.Alpha1 , fireWeaponObject);
        weaponDictionary.Add(KeyCode.Alpha2 , iceWeaponObject);
        weaponDictionary.Add(KeyCode.Alpha3 , lightingWeaponObject);
    }

    public void WeaponsDictionnary()
    {
        foreach (var key in weaponDictionary)
        {
            if (Input.GetKeyDown(key.Key))
            {
                ActiveWeapon(key.Value);
            }
        }
    }

    private void ActiveWeapon(GameObject gameObject)
    {
        iceWeaponObject.SetActive(false);
        fireWeaponObject.SetActive(false);
        lightingWeaponObject.SetActive(false);
        isLightning = (gameObject == lightingWeaponObject);
        gameObject.SetActive(true);

        if (gameObject == lightingWeaponObject && !UnlockLightningWeapon)
        {
            lightingWeaponObject.SetActive(false);
        }
        else if (gameObject == iceWeaponObject && !UnlockIceWeapon)
        {
            iceWeaponObject.SetActive(false);
        }
        else
        {
          WeaponController.CanAttack = true;
        }
    }
    public void OnDeath()
    {
        if (!PlayerIsDead)
        {
            PlayerIsDead = true;
            _playerAnimationController.PlayerIsDead(true);
            Invoke("Delaydead" , 2f);    
        }
    }
    public void Delaydead()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Revive()
    {
        PlayerIsDead = false;
        _playerAnimationController.PlayerIsDead(false);
    }


}
