using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using Unity.Mathematics;
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
        Debug.Log($"Slime current health: {MaxHealth}");
        slimeAnimation.SlimeIsHurted();
        if (MaxHealth <= 0)
        {
            isDead = true;
            StartCoroutine(SlimeDeathDelay());
        }
        Debug.Log($"the tag of the gameobject is {gameObject.tag}");
        if (gameObject.tag == "IceAttack")
        {
            Debug.Log($"should freeze");
           weaponEffect.FreezeOnTouch(this.gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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
