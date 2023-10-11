using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerUpgradeManager : MonoBehaviour
{
    public UpgradeStatsSO statsUpgrade;
    public PlayerController playerController;


    public void UpgradeStats()
    {
        playerController.MaxHealth = statsUpgrade.lifePointUpgrade;
        playerController.MaxMana = statsUpgrade.ManaPointUpgrade;
    }






}
