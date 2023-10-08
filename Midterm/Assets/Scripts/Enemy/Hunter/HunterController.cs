using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour , IBaseCharacter
{
   [SerializeField] private EnemySO _hunterStats;
   [SerializeField] private HunterAnimationController _hunterAnimationController;
   private float maxHealth;
   public bool hunterIsDead;

   private void Start()
   {
      maxHealth = _hunterStats.lifePoint;
   }
   
   public void TakeDamage(float damage)
   {
      maxHealth -= damage;
      if (maxHealth <= 0)
      {
         hunterIsDead = true;
        StartCoroutine(HunterDeathDelay());
      }
   }

   public void OnDeath()
   {
      GetComponent<LootTable>().InstantiateLoot(transform.position);
      Destroy(gameObject);
   }
   public IEnumerator HunterDeathDelay()
   {
      _hunterAnimationController.HunterIsDead(true);
      yield return new WaitForSeconds(3);
      OnDeath();
   }

   
}
