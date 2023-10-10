using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootHandler : MonoBehaviour
{
    private int money;
  
   [SerializeField] private PlayerController _playerController;
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
                HealthPotionLogic();
                Destroy(other.gameObject);
                break;
            case "ManaPotion":
                ManaPotionLogic();
                Destroy(other.gameObject);
                break;
            case "FullRecoveryPotion":
                FullRecoveryPotionLogic();
                Destroy(other.gameObject);
                break;
            case "MoneyCase":
                Debug.Log($"This is MoneyCase");
                MoneyCaseEffect();
                Destroy(other.gameObject);
                break;
        }
    }

    public void MoneyCaseEffect()
    {
        GameObject[] moneyArray = GameObject.FindGameObjectsWithTag("Item");
        foreach (var moneyObject in moneyArray)
        {
            if (moneyObject.name == "Money")
            {
                Rigidbody2D rb = moneyObject.GetComponent<Rigidbody2D>();
                Vector2 direction = (transform.position - moneyObject.transform.position).normalized;
                rb.velocity = direction * 10f;
            }
        }
    }

    public void ManaPotionLogic()
    {
        if (_playerController.MaxMana >= 100) _playerController.MaxMana = 100;
        else _playerController.MaxMana += 20;    
    }

    public void HealthPotionLogic()
    {
        if (_playerController.MaxHealth >= 100) _playerController.MaxHealth = 100;
        else _playerController.MaxHealth += 15;    
    }

    public void FullRecoveryPotionLogic()
    {
        _playerController.MaxHealth = 1000;
        _playerController.MaxMana = 1000;
        if (_playerController.MaxHealth >= 100 )_playerController.MaxHealth = 100;
        if (_playerController.MaxMana >= 100) _playerController.MaxMana = 100;
    }
}
