using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , IBaseCharacter
{
    [SerializeField] private CharacterSOScript playerStat;
   [SerializeField] private PlayerAnimationController _playerAnimationController;
    private float maxHealth;
    private void Start()
    {
        maxHealth = playerStat.lifePoint;
    }

    private void Update()
    {
        PlayerIsCharging();
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
    
    public void OnDeath()
    {
        _playerAnimationController.PlayerIsDead();
        //Destroy(gameObject);
    }
    
    
}
