using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb; 
    [SerializeField]private CharacterSOScript _playerStat;
    
    private float lifePoint;
    private float attackDamage;
    private float manaPoint;
    private float speed;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        lifePoint = _playerStat.lifePoint;
        attackDamage = _playerStat.attackDamage;
        manaPoint = _playerStat.manaPoint;
        speed = _playerStat.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector3(x, y, 0).normalized * (speed * Time.deltaTime);
    }
}
