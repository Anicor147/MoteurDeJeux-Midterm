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
    private float maxHealth;
    public static bool isLightning ;
    private void Start()
    {
        maxHealth = playerStat.lifePoint;
        AddToDictionary();
        DefaultEquipedWeapon();
    }

    private void Update()
    {
        PlayerIsCharging();
        WeaponsDictionnary();
    }

    public void TakeDamage(float damageReceived)
    {
        maxHealth -= damageReceived;
        Debug.Log("current health: "+ maxHealth);
        if (maxHealth <= 0) OnDeath();
    }

    public void PlayerIsCharging()
    {
        if(Input.GetKey(KeyCode.Q))  _playerAnimationController.PlayerIsCharging(true);
        else if(!Input.GetKey(KeyCode.Q)) _playerAnimationController.PlayerIsCharging(false);
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


    }

    public void OnDeath()
    {
        _playerAnimationController.PlayerIsDead();
        //Destroy(gameObject);
    }
    
    
}
