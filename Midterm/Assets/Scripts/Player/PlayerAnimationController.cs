using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator iceAnimator;
    [SerializeField] private Animator fireAnimator;
    private Rigidbody2D _rb;

    private int _isWalking;
    private int _isCharging;
    private int _isAttacking;
    private int _isDead;
  

    private void Awake()
    {
        _isWalking = Animator.StringToHash("isWalking");
        _isCharging = Animator.StringToHash("isCharging");
        _isAttacking = Animator.StringToHash("isAttacking");
        _isDead = Animator.StringToHash("isDead");
        
    }

    public void PlayerIsMoving(bool value)
    {
        playerAnimator.SetBool(_isWalking , value);
    }

    public void PlayerIsAttackingIcePicks()
    {
        playerAnimator.SetTrigger(_isAttacking);
        iceAnimator.SetTrigger(_isAttacking);
    } 
    
    public void PlayerIsAttackingFireMelee()
    {
        playerAnimator.SetTrigger(_isAttacking);
        fireAnimator.SetTrigger(_isAttacking);
    }

    public void PlayerIsCharging(bool value)
    {
        playerAnimator.SetBool(_isCharging, value);
    }
    
    public void PlayerIsDead(bool value)
    {
        playerAnimator.SetBool(_isDead , value);
    }

   
}
