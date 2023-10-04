using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator weaponAnimator;
    private Rigidbody2D _rb; 
    
    
    public void PlayerIsMoving(bool boolValue)
    {
        playerAnimator.SetBool("isWalking", boolValue);
    }

    public void PlayerIsAttackingIcePicks()
    {
        playerAnimator.SetTrigger("isAttacking");
        weaponAnimator.SetTrigger("isAttacking");
    }


}
