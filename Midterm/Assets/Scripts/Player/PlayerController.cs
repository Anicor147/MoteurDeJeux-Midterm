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
        PlayerAttack();
    }

    public void TakeDamage(float damageReceived)
    {
        maxHealth -= damageReceived;
        Debug.Log("current health: "+ maxHealth);
        if (maxHealth <= 0) OnDeath();
    }

    public void PlayerAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("button is pressed");
            _playerAnimationController.PlayerIsAttacking();
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
    
    
}
