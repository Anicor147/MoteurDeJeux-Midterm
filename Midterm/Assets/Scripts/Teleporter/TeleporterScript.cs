using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
  [SerializeField]  public GameManager GameManager;
  private bool isCollided;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && isCollided)
    {
      Debug.Log($"E is pressed");
      GameManager.LoadLevel1();
    }
    else
    {
      isCollided = false;
    }
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    isCollided = true;
  }


  
}
