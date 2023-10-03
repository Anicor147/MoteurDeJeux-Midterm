using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        LineOfActionPosition();
    }

    void LineOfActionPosition()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        // Calculate the direction from the object to the mouse position
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object to face the mouse position
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
}
