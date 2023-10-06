using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SlimeController : MonoBehaviour ,IBaseCharacter
{
    [SerializeField] private EnemySO _enemyStats;
    [SerializeField] private SlimeAnimationControler slimeAnimation;
    private float maxHealth;
    public bool isDead;
    public bool isAttacking;
    private Rigidbody2D rb;
    private void Start()
    {
        maxHealth = _enemyStats.lifePoint;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        Debug.Log($"current health: {maxHealth}");
        slimeAnimation.SlimeIsHurted();
        if (maxHealth <= 0)
        {
            isDead = true;
            StartCoroutine(SlimeDeathDelay());
        }
    }

    public void SlimeAttack()
    {
        isAttacking = true;
        slimeAnimation.SlimeIsAttacking();
        isAttacking = false; 
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(_enemyStats.attackDamage);
           
        }
    }
    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public IEnumerator SlimeDeathDelay()
    {
        slimeAnimation.SlimeIsDead(true);

        yield return new WaitForSeconds(2);
        OnDeath();
    }
 
    
}
