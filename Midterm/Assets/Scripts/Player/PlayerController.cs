using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , IBaseCharacter
{
    [SerializeField] private CharacterSOScript playerStat;
    private float maxHealth;
    private void Start()
    {
        maxHealth = playerStat.lifePoint;
    }

    private void Update()
    {
    }

    public void TakeDamage(float damageReceived)
    {
        maxHealth -= damageReceived;
        Debug.Log("current health: "+ maxHealth);
        if (maxHealth <= 0) OnDeath();
    }


    public void OnDeath()
    {
        Destroy(gameObject);
    }
    
    
}
