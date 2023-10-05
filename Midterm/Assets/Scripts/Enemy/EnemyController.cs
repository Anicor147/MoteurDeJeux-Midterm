using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour , IBaseCharacter
{
    [SerializeField] private EnemySO _enemyStats;
    private float maxHealth;
    private void Start()
    {
        maxHealth = _enemyStats.lifePoint;
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        Debug.Log($"current health = {maxHealth}" );
        if(maxHealth <= 0 ) OnDeath();
    }

    public void OnDeath()
    {
        Debug.Log($"the ennemy is dead");
    }
}
