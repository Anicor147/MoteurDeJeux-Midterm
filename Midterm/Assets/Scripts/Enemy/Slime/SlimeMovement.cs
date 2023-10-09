using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SlimeMovement : MonoBehaviour , IFlipSprite , IMoveEnemy
{
    [SerializeField] private EnemySO _slimeStats;
    [SerializeField] private SlimeAnimationControler slimeAnimation;
    [SerializeField] private SlimeController _slimeChecController;
    private GameObject player;
    private Vector3 distance;
    private Rigidbody2D _rb;
    private int layerMaskPlayer;
    private int layerMaskEnemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        layerMaskPlayer = LayerMask.GetMask("Player");
        layerMaskEnemy = LayerMask.GetMask("Enemy");
    }

    private void FixedUpdate()
    {
        FlipSprite();
        RaycastHitPlayer();
    }

    public void RaycastHitPlayer()
    {
        var distance = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance , _slimeStats.range, layerMaskPlayer );
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            MoveTowardPlayer(distance);
            if (distance.magnitude <=0.5)
            {
                _rb.velocity = Vector2.zero;
                slimeAnimation.SlimeIsAttacking();
            }
            if (_slimeChecController.isDead)
            {
                _rb.velocity = Vector2.zero;
            }
        }
        else 
        {
            _rb.velocity = Vector2.zero;
        }
    }

    public void MoveTowardPlayer(Vector3 distance)
    {
        _rb.velocity = distance.normalized * (_slimeStats.speed * Time.deltaTime);
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
