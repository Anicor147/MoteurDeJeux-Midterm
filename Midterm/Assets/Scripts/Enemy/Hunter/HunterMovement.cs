using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class HunterMovement : MonoBehaviour , IFlipSprite , IMoveEnemy
{
    [SerializeField] private EnemySO _hunterStats;
    [SerializeField] private HunterAnimationController hunterAnimation;
    [SerializeField] private GameObject hunterArrows;
    [SerializeField] private HunterController _hunterController;
    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 distance;
    private int layerMask;
    private float cooldown =1f;
    private float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.GetMask("Player");
        timer = Time.time - cooldown;
    }

    private void FixedUpdate()
    {
        RaycastHitPlayer();
        FlipSprite();
    }


    public void RaycastHitPlayer()
    {
        distance = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, _hunterStats.range , layerMask);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            MoveTowardPlayer(distance);
            if ( distance.magnitude <= 6)
            {
                rb.velocity = Vector2.zero;
                hunterAnimation.HunterIsRunning(false);
                AttackPlayer(distance);
                if (distance.magnitude <= 4)
                {
                    MoveTowardPlayer(-distance);
                }

                if (_hunterController.hunterIsDead)
                { 
                    rb.velocity = Vector2.zero;
                }
            }
        }
        else 
        {
            rb.velocity = Vector2.zero;
            hunterAnimation.HunterIsRunning(false);
        }
    }

    public void MoveTowardPlayer(Vector3 distance)
    {
        rb.velocity = distance.normalized * (_hunterStats.speed * Time.deltaTime);
        hunterAnimation.HunterIsRunning(true);
    }

    public void AttackPlayer(Vector3 distance)
    {
        if (Time.time - timer >= cooldown)
        {
            var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            hunterAnimation.HunterIsAttacking();
            Instantiate(hunterArrows, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
            timer = Time.time;
        }
    }

    public void MoveTowardPlayer()
    {
    }

    public void FlipSprite()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
