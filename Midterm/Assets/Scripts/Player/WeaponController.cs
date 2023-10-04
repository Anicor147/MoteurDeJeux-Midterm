using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector3 mousePosition;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        LineOfActionPosition();
        WeaponSpriteFlip();
    }

    void LineOfActionPosition()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void WeaponSpriteFlip()
    {
        if (mousePosition.x < transform.position.x)
        {
            _spriteRenderer.flipY = true;
        }
        else
        {
            _spriteRenderer.flipY = false;
        }
    }
}
