using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SlimeMovement : MonoBehaviour , IFlipSprite
{
    [SerializeField] private EnemySO _enemyStats;
    private GameObject player;
    private Vector3 distance;
    private Rigidbody2D _rb;
    [SerializeField] private SlimeController slimeControllerChecks;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FlipSprite();
        MoveTowardPlayer();
    }

    private void MoveTowardPlayer()
    {
        var towardPlayer = player.transform.position - transform.position;
        _rb.velocity = towardPlayer.normalized * (_enemyStats.speed * Time.deltaTime);
        if (slimeControllerChecks.isDead || slimeControllerChecks.isAttacking )
        {
                _rb.velocity = Vector2.zero;
        }
    }

    public void FlipSprite()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
