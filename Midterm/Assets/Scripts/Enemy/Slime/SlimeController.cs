using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SlimeController : MonoBehaviour ,IBaseCharacter
{
    [SerializeField] private EnemySO _slimeStats;
    [SerializeField] private SlimeAnimationControler slimeAnimation;
    private float maxHealth;
    public bool isDead;
  
    private void Start()
    {
        maxHealth = _slimeStats.lifePoint;
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        Debug.Log($"Slime current health: {maxHealth}");
        slimeAnimation.SlimeIsHurted();
        if (maxHealth <= 0)
        {
            isDead = true;
            StartCoroutine(SlimeDeathDelay());
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(_slimeStats.attackDamage);
           
        }
    }
    public void OnDeath()
    {
      GetComponent<LootTable>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }

    public IEnumerator SlimeDeathDelay()
    {
        slimeAnimation.SlimeIsDead(true);

        yield return new WaitForSeconds(2);
        OnDeath();
    }
 
    
}
