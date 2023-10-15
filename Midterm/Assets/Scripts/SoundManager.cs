using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private Slider musicSlider;
    private bool pressed;
    private GameObject audio;
    private AudioSource audioSource;

   [SerializeField] private AudioSource audioSourceFireWeapon , audioSourceIceWeapon , audioSourceLightningWeapon;
    
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSourceFireWeapon.PlayOneShot(audioClip);
        audioSourceIceWeapon.PlayOneShot(audioClip);
        audioSourceLightningWeapon.PlayOneShot(audioClip);
    }
    
    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Sound");

        if (audio != null)
        {
            audioSource = audio.GetComponent<AudioSource>();
           musicSlider.value = audioSource.volume;
        }
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
