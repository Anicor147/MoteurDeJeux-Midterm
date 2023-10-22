using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootHandler : MonoBehaviour
{
    private int money;
    private bool getmoney;
    [SerializeField] private AudioClip _clip;
  
   private PlayerController _playerController;

   private void Start()
   {
       _playerController = PlayerController.instance;
   }


   private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Money":
                _playerController.Currency += 10;
                Debug.Log($"How much money : {_playerController.Currency}");
                PlayPickUpSoundClip();
                Destroy(other.gameObject);
                break;
            case "HealthPotion":
                HealthPotionLogic();
                PlayPickUpSoundClip();
                Destroy(other.gameObject);
                break;
            case "ManaPotion":
                ManaPotionLogic();
                PlayPickUpSoundClip();
                Destroy(other.gameObject);
                break;
            case "FullRecoveryPotion":
                FullRecoveryPotionLogic();
                PlayPickUpSoundClip();
                Destroy(other.gameObject);
                break;
            case "MoneyCase":
                getmoney = true;
                PlayPickUpSoundClip();
                Destroy(other.gameObject);
                break;
        }
    }

    private void FixedUpdate()
    {
        MoneyCaseEffect();
    }
    
    public void PlayPickUpSoundClip()
    {
        SoundManager.instance.PlaySound(_clip);
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
        /*if (_playerController.CurrentHealth >= _playerController.MaxHealth) _playerController.CurrentHealth = _playerController.MaxHealth;
        else _playerController.CurrentHealth += 15;
        */
        _playerController.CurrentHealth += 15;
        Mathf.Clamp(_playerController.CurrentHealth, 0, _playerController.MaxHealth);
    }

    public void FullRecoveryPotionLogic()
    {
        _playerController.CurrentHealth = _playerController.MaxHealth;
        _playerController.CurrentMana = _playerController.MaxMana;
    }
}
