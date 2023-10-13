using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;

public class HunterController : MonoBehaviour , IBaseCharacter
{
   [SerializeField] private EnemySO _hunterStats;
   [SerializeField] private HunterAnimationController _hunterAnimationController;
   private WeaponStatus _weaponStatus;
   public float MaxHealth { get; set; }
   public bool hunterIsDead;

   private void Start()
   {
      MaxHealth = _hunterStats.lifePoint;
      _weaponStatus = GetComponent<WeaponStatus>();
   }
   
   public void TakeDamage(float damage , GameObject gameObjectH)
   {
      MaxHealth -= damage;
      Debug.Log($"Current Hunter health {MaxHealth}");
      if (MaxHealth <= 0)
      {
         hunterIsDead = true;
         _hunterAnimationController.HunterIsDead(true);
        StartCoroutine(HunterDeathDelay());
      }
      if (gameObjectH.CompareTag("IceAttack"))
      {
         Debug.Log($"Before");
         _weaponStatus.FreezeOnTouch(gameObject);
         Debug.Log($"After");
      }
      else if (gameObjectH.CompareTag("FireAttack"))
      {
         if (!_weaponStatus.IsBurned)
         {
            _weaponStatus.FireDamageOverTime(gameObject);
         }
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
