using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour ,IFlipSprite
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
     private PlayerController _playerController;
    [SerializeField] private AudioClip _clip;
    private Vector3 mousePosition;
    private float attackStartTime;
    public float attackCooldown = 0.5f;
    private float angle;
    private Vector3 direction;
    private bool canAttack;
    public bool CanAttack
    {
        get => canAttack;
        set => canAttack = value;
    }

    private void Start()
    {
        _playerController = PlayerController.instance;
    }

    private void LateUpdate()
    {
        PlayerAttack();
        LineOfActionPosition();
        FlipSprite();
    }

    public void PlayWeaponSoundClip()
    {
        SoundManager.instance.PlaySound(_clip);
    }

    void LineOfActionPosition()
    {
        if (Time.time - attackStartTime >= attackCooldown)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 

             direction = mousePosition - transform.position;
             angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    public void PlayerAttack()
    {
        if(_playerController.PlayerIsDead) return;
        if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Q) )
        {
            if (_playerController.CurrentMana > 0 && !_playerController.isLightning)
            {
                _playerController.CurrentMana -= 5;   
                attackStartTime = Time.time;
                
                _playerAnimationController.PlayerIsAttacking();
                 if(gameObject.tag == "FireAttack")
                    _playerAnimationController.PlayerIsAttackingFireMelee();
                if(gameObject.tag == "IceAttack")
                _playerAnimationController.PlayerIsAttackingIcePicks();
                
            }
            else if (_playerController.CurrentMana > 0 && _playerController.isLightning && CanAttack)
            {
                StartCoroutine(LightningWeaponWithDelay());  
            }
               
        }
    }
    public IEnumerator LightningWeaponWithDelay()
    { 
        CanAttack = false;
        Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle)); 
        _playerController.CurrentMana -= 5; 
        yield return new WaitForSeconds(1f);
        CanAttack = true;
    }
    public void FlipSprite()
    {
        if (mousePosition.x < transform.position.x)
        {
            _spriteRenderer.flipY = true;
        }
        else
        {
            _spriteRenderer.flipY = false;
        }
    }
}
