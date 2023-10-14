using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootHandler : MonoBehaviour
{
    private int money;
    private bool getmoney;
  
   [SerializeField] private PlayerController _playerController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Money":
                _playerController.Currency += 10;
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
                getmoney = true;
                Destroy(other.gameObject);
                break;
        }
    }

    private void FixedUpdate()
    {
        MoneyCaseEffect();
    }
    public void MoneyCaseEffect()
    {
        if (!getmoney) return;
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
        Invoke("StopMoneyCaseEffect" , 2f);
    }

    private void StopMoneyCaseEffect()
    {
        getmoney = false;
    }

    public void ManaPotionLogic()
    {
        if (_playerController.CurrentMana >= _playerController.MaxMana) _playerController.CurrentMana = _playerController.MaxMana;
        else _playerController.CurrentMana += 20;    
    }

    public void HealthPotionLogic()
    {
<<<<<<< HEAD
        if (_playerController.CurrentHealth >= _playerController.MaxHealth) _playerController.CurrentHealth = _playerController.MaxHealth;
        else _playerController.CurrentHealth += 15;    
=======
        if (_playerController.MaxHealth >= _playerController.CurrentHealth) _playerController.CurrentHealth = _playerController.MaxHealth;
        else _playerController.MaxHealth += 15;    
>>>>>>> 76f9120cbf1338b3467894720fbb507d2bfe2b7a
    }

    public void FullRecoveryPotionLogic()
    {
        _playerController.CurrentHealth = _playerController.MaxHealth;
        _playerController.CurrentMana = _playerController.MaxMana;
    }
}
