using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SlimeController : MonoBehaviour ,IBaseCharacter
{
    [SerializeField] private EnemySO _slimeStats;
    [SerializeField] private SlimeAnimationControler slimeAnimation;
    private WeaponStatus weaponEffect;
    private float maxHealth;
    public float MaxHealth { get; set; }
    public bool isDead;
  
    private void Start()
    {
        MaxHealth = _slimeStats.lifePoint;
        weaponEffect = GetComponent<WeaponStatus>();
    }

    public void TakeDamage(float damage , GameObject gameObject)
    {
        MaxHealth -= damage;
        slimeAnimation.SlimeIsHurted();
        if (MaxHealth <= 0)
        {
            isDead = true;
            StartCoroutine(SlimeDeathDelay());
        }
        if (gameObject.tag == "IceAttack")
        {
           weaponEffect.FreezeOnTouch(this.gameObject);
        }
        else if (gameObject.tag == "FireAttack")
        {
            if (!weaponEffect.IsBurned)
            {
                weaponEffect.FireDamageOverTime(this.gameObject);
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(_slimeStats.attackDamage, null);
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
