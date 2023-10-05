using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatsController : MonoBehaviour
{
  [SerializeField] private WeaponsSO _weaponsSo;

  private void OnTriggerEnter2D(Collider2D other)
  {
      if (!other.CompareTag("Player"))
      {
          other.gameObject.GetComponent<EnemyController>().TakeDamage(_weaponsSo.WeaponDamage);
      }
  }
}
