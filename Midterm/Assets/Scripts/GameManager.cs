using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Need Singleton


    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        
    }
}
