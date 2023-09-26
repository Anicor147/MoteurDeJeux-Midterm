using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private CharacterSOScript playerStat;
    private float maxHealth;
    void Start()
    {
        maxHealth = playerStat.lifePoint;
    }

    // public void TakeDamage(float damageReceived)
    // {
    //     maxHealth -= damageReceived;
    //     Debug.Log("current health: "+ maxHealth);
    //     if (maxHealth <= 0) playerDeath();
    // }

    
    
    private void playerDeath()
    {
        Destroy(gameObject);
    }
}
