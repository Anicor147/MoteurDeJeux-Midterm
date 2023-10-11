using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Character/Upgrade Data")]
public class UpgradeStatsSO : ScriptableObject
{
  public float lifePointUpgrade;
  public float ManaPointUpgrade;
  public float weaponDamageUpgrade;
}
