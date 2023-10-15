using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private Slider musicSlider;
    private bool pressed;
    private GameObject audio;
    private AudioSource audioSource;
    
    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Sound");
        audioSource = audio.GetComponent<AudioSource>(); 
        
        musicSlider.value = audioSource.volume;
    }
    private void Update()
    {
        audioSource.volume = musicSlider.value;
    }

    public void MuteMusic()
    {
        if (!pressed)
        {
            audioSource.volume = 0;
            musicSlider.value = 0;
            pressed = true;
        }
        else if (pressed)
        {
            audioSource.volume = 100;
            musicSlider.value = 100;
            pressed = false;
        }
    }
    
}