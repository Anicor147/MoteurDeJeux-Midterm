using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
  [SerializeField]  public GameManager GameManager;


  private void OnTriggerEnter2D(Collider2D other)
  {
    Invoke("LoadNextScene" , 2f);
  }


  public void LoadNextScene()
  {
    GameManager.LoadLevel1();
  }
}
