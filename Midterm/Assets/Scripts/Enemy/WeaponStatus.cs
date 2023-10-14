using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WeaponStatus : MonoBehaviour
{
   private Projectile _projectile;
   public bool IsFreezed { get; set; }
   public bool IsBurned { get; set; }

   public void FireDamageOverTime(GameObject gameObject)
   {
      IsBurned = true;
     StartCoroutine(FireBurnDelay(gameObject));
   }
   
   public IEnumerator FireBurnDelay(GameObject gameObject)
   {
      var slimeController = gameObject.GetComponent<SlimeController>();
      var color = gameObject.GetComponent<SpriteRenderer>();

      for (int counter = 0; counter < 3; counter++)
      {
         color.color = Color.red;
         slimeController.MaxHealth -= 5;
         yield return new WaitForSeconds(0.5f);
         color.color = Color.white;   
         yield return new WaitForSeconds(0.5f);
      }
      IsBurned = false;
   }

   public void FreezeOnTouch(GameObject gameObject)
   {
      IsFreezed = true;
      var rb = gameObject.GetComponent<Rigidbody2D>();
      var color = gameObject.GetComponent<SpriteRenderer>();
      color.color = Color.blue;
      rb.velocity = Vector2.zero;
      
      Debug.Log($"velocity should be zero");
      StartCoroutine(UnFreezedDelay(gameObject));
   }

   public IEnumerator UnFreezedDelay(GameObject gameObject)
   {
      yield return new WaitForSeconds(2);
      var color = gameObject.GetComponent<SpriteRenderer>();
      color.color = Color.white;
      IsFreezed = false;
   }
   
   
   
   public void LightningPierceEffect()
   {
     // _projectile.IsPiercing = true;
   }

}
