using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerUpgradeManager : MonoBehaviour
{
    public UpgradeListSO listOfUpgrade;
    public PlayerController playerController;

    public void UpgradeStats(int index)
    {
        foreach (var upgrade in listOfUpgrade.listOfUpgrade)
        {
            if (index == upgrade.index)
            {
                playerController.MaxHealth = upgrade.lifePointUpgrade;
                playerController.MaxMana = upgrade.manaPointUpgrade;
            }
        }
        
        Debug.Log($"Current Character Max Health is = {playerController.MaxHealth}");
        Debug.Log($"Current Character Max Mana is = {playerController.MaxMana}");
    }
    
}
