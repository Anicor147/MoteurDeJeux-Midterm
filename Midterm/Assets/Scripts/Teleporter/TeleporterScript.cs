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
    LoadNextScene();
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    isCollided = true;
  }


  public void LoadNextScene()
  {
    if (Input.GetKeyDown(KeyCode.E) && isCollided)
    {
      GameManager.LoadLevel1();
    }
  }
}
