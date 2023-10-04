using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    private Vector3 mousePosition;
    private float attackStartTime;
    public float attackCooldown = 0.5f;

    private bool isAttacking = false;

    private void LateUpdate()
    {
        PlayerAttack();
        LineOfActionPosition();
        WeaponSpriteFlip();
    }

    void LineOfActionPosition()
    {
        if (Time.time - attackStartTime >= attackCooldown)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 

            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void WeaponSpriteFlip()
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
    
    public void PlayerAttack()
    {
        if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Q))
        {
             attackStartTime = Time.time;
             _playerAnimationController.PlayerIsAttackingIcePicks();
             _playerAnimationController.PlayerIsAttackingFireMelee();
        }
    }
    
}
