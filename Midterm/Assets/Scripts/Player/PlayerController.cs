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
    [SerializeField]  private WeaponController WeaponController;
    public static bool isLightning;
    private bool unlockIceWeapon;
    private bool unlockLightningWeapon ;
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
        
        //DONT FORGER TO DELETE. THIS LINE IS FOR TEST !!!!!
        UnlockLightningWeapon = true;
        UnlockIceWeapon = true;
        //DONT FORGER TO DELETE. THIS LINE IS FOR TEST !!!!!
        
        
        
        Debug.Log($"ice {UnlockIceWeapon}  lightning {UnlockLightningWeapon}");
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
          Debug.Log($"can attack {WeaponController.CanAttack}");
        }
    }
    public void OnDeath()
    {
        _playerAnimationController.PlayerIsDead();
        //Destroy(gameObject);
    }
    
    
}
