using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : MonoBehaviour
{
   private Projectile _projectile;
   public bool Isfreezed { get; set; }

   public void FireDamageOVerTimer(GameObject gameObject)
   {
      
      
   }


   public void FreezeOnTouch(GameObject gameObject)
   {
      Isfreezed = true;
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
      Isfreezed = false;
      yield break;
   }


   public void LightningPierceEffect()
   {
      _projectile.IsPiercing = true;
   }

}
