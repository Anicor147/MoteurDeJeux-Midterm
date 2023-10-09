using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatsController : MonoBehaviour
{
  [SerializeField] private WeaponsSO _weaponsSo;

  private void OnTriggerEnter2D(Collider2D other)
  {
      if (other.CompareTag("Slime"))
      {
          other.gameObject.GetComponent<SlimeController>().TakeDamage(_weaponsSo.WeaponDamage);
      }
      if (other.CompareTag("Hunter"))
      {
          other.gameObject.GetComponent<HunterController>().TakeDamage(_weaponsSo.WeaponDamage);
      }
  }
}