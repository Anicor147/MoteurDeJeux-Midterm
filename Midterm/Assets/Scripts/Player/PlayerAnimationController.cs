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
    
    
    public void PlayerIsMoving(bool value)
    {
        playerAnimator.SetBool("isWalking", value);
    }

    public void PlayerIsAttackingIcePicks()
    {
        playerAnimator.SetTrigger("isAttacking");
        iceAnimator.SetTrigger("isAttacking");
    } 
    
    public void PlayerIsAttackingFireMelee()
    {
        playerAnimator.SetTrigger("isAttacking");
        fireAnimator.SetTrigger("isAttacking");
    }

    public void PlayerIsCharging(bool value)
    {
        playerAnimator.SetBool("isCharging", value);
    }
    
    public void PlayerIsDead()
    {
        playerAnimator.SetTrigger("isDead");
    }
}
