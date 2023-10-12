using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatsController : MonoBehaviour
{
  [SerializeField] private WeaponsSO _weaponsSo;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.layer ==9) 
      other.gameObject.GetComponent<IBaseCharacter>().TakeDamage(_weaponsSo.WeaponDamage);
  }
}
