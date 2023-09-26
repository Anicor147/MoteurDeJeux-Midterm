using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb; 
    [SerializeField]private CharacterSOScript playerStat;
   
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerJump();
    }

    void FixedUpdate()
    {
       CharacterMovement();
    }

    void CharacterMovement()
    {  
        var vx = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector3(vx * playerStat.speed * Time.deltaTime, _rb.velocity.y, 0) ;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("is jumping a the heigh of : " + playerStat.jumpHeight);
            _rb.velocity= new Vector2(_rb.velocity.x ,playerStat.jumpHeight ) ; 
        }
    }
}
