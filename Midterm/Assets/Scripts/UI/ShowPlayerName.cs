using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_Text showPlayerName;
    
    void Start()
    {
        showPlayerName.text = MainMenuScript.instance.PlayerName;
    }
    
}
