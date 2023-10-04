using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour, IFlipSprite
{
    private PlayerAnimationController _animationController;
    private Rigidbody2D _rb; 
    [SerializeField] 
    private CharacterSOScript playerStat;
    private float _vx , _vy;
    private float moveSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector3 mousePosition;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animationController = FindObjectOfType<PlayerAnimationController>();
    }
    
    void FixedUpdate()
    {
       GetInput();
       CharacterMovement();
       FlipSprite();
    }

    private void GetInput()
    {
        _vx = Input.GetAxisRaw("Horizontal");
        _vy = Input.GetAxisRaw("Vertical");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
    }

    private void CharacterMovement()
    {
        if (!Input.GetKey(KeyCode.Q))
        {
            _rb.velocity = new Vector3(_vx, _vy, 0).normalized * (playerStat.speed * Time.deltaTime);

            if (_rb.velocity.magnitude > 0)
            {
                _animationController.PlayerIsMoving(true);
            }
            else
            {
                _animationController.PlayerIsMoving(false);
            }
        }
        else
        {
            _rb.velocity = new Vector3(0, 0, 0);
        }
    }


    public void FlipSprite()
    {
        var characterPosition = transform.position;
        var mouseOffset = mousePosition - characterPosition;
        if (mouseOffset.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (mouseOffset.x > 0 )
        {
            _spriteRenderer.flipX = false;
        }
    }
    
}
