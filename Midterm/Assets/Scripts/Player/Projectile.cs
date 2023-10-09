using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float projectileSpeed = 10f;
    [SerializeField] private EnemySO _hunterStats;
    private void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile",5f);
    }

    public void FixedUpdate()
    {
        ProjectileMovement();
    }

    public void ProjectileMovement()
    {
        _rigidbody2D.velocity = transform.right * (projectileSpeed * Time.deltaTime) ;
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("HunterArrow"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(_hunterStats.attackDamage);
        }
    }
}