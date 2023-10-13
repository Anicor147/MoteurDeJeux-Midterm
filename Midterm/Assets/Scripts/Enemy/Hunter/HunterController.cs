using System;
using System.Collections;
using System.Collections.Generic;
using SO;
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
   
   public void TakeDamage(float damage , GameObject gameObject)
   {
      maxHealth -= damage;
      Debug.Log($"Current Hunter health {maxHealth}");
      if (maxHealth <= 0)
      {
         hunterIsDead = true;
         _hunterAnimationController.HunterIsDead(true);
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
      yield return new WaitForSeconds(3);
      OnDeath();
   }

   
}
