using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStart : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.InitializeScene();    
    }
}
