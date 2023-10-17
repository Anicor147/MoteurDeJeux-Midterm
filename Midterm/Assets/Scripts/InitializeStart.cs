using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStart : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"should be initalize Againg");
        SoundManager.instance.InitializeScene();    
    }
}
