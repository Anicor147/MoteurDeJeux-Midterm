using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , IBaseCharacter
{ 
    [SerializeField] private CharacterSOScript playerStat;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private GameObject iceWeaponObject;
    [SerializeField] private GameObject fireWeaponObject;
    [SerializeField] private GameObject lightingWeaponObject;
    private Dictionary<KeyCode, GameObject> weaponDictionary;
    [SerializeField] private WeaponController WeaponController;
    private bool isCharging;
    public static bool isLightning;
    private bool unlockIceWeapon;
    private bool unlockLightningWeapon ;
    private int currency;
    private float maxHealth;
    private float maxMana;
    private float currentMana;
    private float currentHealth;
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

    private void Start()
    {
        MaxHealth = playerStat.lifePoint;
        MaxMana = playerStat.manaPoint;
        CurrentMana = MaxMana;
        CurrentHealth = MaxHealth;
        
        //DONT FORGER TO DELETE. THIS LINE IS FOR TEST !!!!!
        UnlockLightningWeapon = true;
        UnlockIceWeapon = true;
        //DONT FORGER TO DELETE. THIS LINE IS FOR TEST !!!!!
        
        AddToDictionary();
        DefaultEquipedWeapon();
    }

    
    public int Currency
    {
        get => currency;
        set => currency = value;
    }

    private void Update()
    {
        PlayerIsCharging();
        WeaponsDictionnary();
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
                Debug.Log(CurrentMana);
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
        PlayerIsDead = true;
        _playerAnimationController.PlayerIsDead(true);
    }

    public void Revive()
    {
        PlayerIsDead = false;
        _playerAnimationController.PlayerIsDead(false);
    }


}
