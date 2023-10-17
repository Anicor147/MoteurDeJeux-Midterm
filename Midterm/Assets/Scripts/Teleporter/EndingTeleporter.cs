using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTeleporter : MonoBehaviour
{
    private bool isCollided;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided)
        {
            Debug.Log($"E is pressed");
            MainMenuScene();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isCollided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isCollided = false;
        }
    }
    public void DestroyDontDestroyOnLoadObjects()
    {
        DontDestroyOnLoad[] objectsWithScript = FindObjectsOfType<DontDestroyOnLoad>();

        foreach (DontDestroyOnLoad obj in objectsWithScript)
        {
            Destroy(obj.gameObject);
        }
    }
    public void MainMenuScene()
    {
        DestroyDontDestroyOnLoadObjects();
        SceneManager.LoadScene(0);
    }
}
