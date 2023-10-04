using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float projectileSpeed = 10f;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile",5f);
    }

    public void Update()
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
}
