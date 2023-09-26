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
     //   PlayerJump();
    }

    void FixedUpdate()
    {
       CharacterMovement();
    }

    void CharacterMovement()
    {  
        var vx = Input.GetAxisRaw("Horizontal");
        var vy = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector3(vx, vy, 0).normalized * (playerStat.speed * Time.deltaTime);
    }

   
}
