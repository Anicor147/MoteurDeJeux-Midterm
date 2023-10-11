using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListUpgrade", menuName = "Character/ListUpgrade")]
public class UpgradeListSO : ScriptableObject
{
    public List<UpgradeStatsSO> listOfUpgrade;
}
