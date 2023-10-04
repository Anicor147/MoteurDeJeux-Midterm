using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator weaponAnimator;
    private Rigidbody2D _rb; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerIsMovfing();
    }

    public void PlayerIsMoving(bool boolValue)
    {
        playerAnimator.SetBool("isWalking", boolValue);
    }   
    
    public void PlayerIsMovfing()
    {
        if (_rb.velocity.magnitude > 0)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
