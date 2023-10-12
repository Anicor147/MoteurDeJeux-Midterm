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
                playerController.MaxHealth += upgrade.lifePointUpgrade;
                playerController.MaxMana += upgrade.manaPointUpgrade;
            }
        }
        
        Debug.Log($"Current Character Max Health is = {playerController.MaxHealth}");
        Debug.Log($"Current Character Max Mana is = {playerController.MaxMana}");
    }

    // Not official
    
    public void FirstUpgrade()
    {
        if (playerController.Currency >= 200)
        {
            playerController.Currency -= 200;    
            UpgradeStats(1);
        }
    }
    public void SecondUpgrade()
    {
        if (playerController.Currency >= 400)
        {
            playerController.Currency -= 400;    
            UpgradeStats(2);
        }   
    }
    public void ThirdUpgrade()
    {
        if (playerController.Currency >= 600)
        {
            playerController.Currency -= 600;    
            UpgradeStats(3);
        }
    }

    public void UnlockIce()
    {
        playerController.UnlockIceWeapon = true;
    }


    public void UnlockLightning()
    {
        playerController.UnlockLightningWeapon = true;
    }
}
