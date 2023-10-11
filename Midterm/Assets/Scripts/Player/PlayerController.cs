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
    private WeaponController coroutineWeaponController;
    public static bool isLightning;
    private int currency;
    private float maxHealth;
    private float maxMana;


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

    private void Start()
    {
        MaxHealth = playerStat.lifePoint;
        MaxMana = playerStat.manaPoint;
        
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

    public void TakeDamage(float damageReceived)
    {
        maxHealth -= damageReceived;
        if (MaxHealth <= 0) OnDeath();
    }

    public void PlayerIsCharging()
    {
        if (MaxMana <= playerStat.manaPoint)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _playerAnimationController.PlayerIsCharging(true);
                MaxMana += (20 * Time.deltaTime);
                Debug.Log(MaxMana);
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
        
        gameObject.SetActive(true);
        
        if (gameObject == lightingWeaponObject) isLightning = true;
        else isLightning = false;
        
        if (gameObject != lightingWeaponObject) 
        {
            Debug.Log($"not light");
            WeaponController.canAttack = true;
        }
    }
    public void OnDeath()
    {
        _playerAnimationController.PlayerIsDead();
        //Destroy(gameObject);
    }
    
    
}
