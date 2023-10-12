using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour ,IFlipSprite
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private PlayerController _playerController;
    private Vector3 mousePosition;
    private float attackStartTime;
    public float attackCooldown = 0.5f;
    private float angle;
    private Vector3 direction;
    //public static bool canAttack = true;
    private bool canAttack;

    public bool CanAttack
    {
        get => canAttack;
        set => canAttack = value;
    }


    private void LateUpdate()
    {
        PlayerAttack();
        LineOfActionPosition();
        FlipSprite();
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
        
        if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Q) && _playerController.MaxMana > 0 && !PlayerController.isLightning )
        {
            _playerController.MaxMana -= 5;   
            Debug.Log($"Remaining mana { _playerController.MaxMana}");
             attackStartTime = Time.time;
             _playerAnimationController.PlayerIsAttackingIcePicks();
             _playerAnimationController.PlayerIsAttackingFireMelee();
             
        }
        else if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Q) && _playerController.MaxMana > 0 && PlayerController.isLightning )
        {
            Debug.Log($"Can attack from Weapon Controller {CanAttack}");
            if (CanAttack)
            {
                StartCoroutine(LightningWeaponWithDelay());  
            }
        }
    }
    public IEnumerator LightningWeaponWithDelay()
    { 
        CanAttack = false;
        Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle)); 
        _playerController.MaxMana -= 5; 
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
