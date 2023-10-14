using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{
  private bool isCollided;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && isCollided)
    {
      Debug.Log($"E is pressed");
      LoadLevel1();
    }

  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player")) // Replace "YourTag" with the appropriate tag
    {
      isCollided = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player")) // Replace "YourTag" with the appropriate tag
    {
      isCollided = false;
    }
  }

  public void LoadLevel1()
  {
    SceneManager.LoadScene(2);
  }
  
  
}
