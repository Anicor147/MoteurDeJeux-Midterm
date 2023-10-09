using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootHandler : MonoBehaviour
{
    private int money;
    private PlayerController _playerController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Money":
                _playerController.Currency += 5;
                Debug.Log($"How much money : {_playerController.Currency}");
                Destroy(other.gameObject);
                break;
            case "HealthPotion":
                _playerController.MaxHealth += 15;
                Debug.Log($"This is HealthPotion");
                break;
            case "ManaPotion":
                Debug.Log($"This is ManaPotion");
                _playerController.MaxMana += 20;
                break;
            case "MoneyCase":
                Debug.Log($"This is MoneyCase");
                MoneyCaseEffect();
                break;
        }
    }

    public void MoneyCaseEffect()
    {
    }
}
