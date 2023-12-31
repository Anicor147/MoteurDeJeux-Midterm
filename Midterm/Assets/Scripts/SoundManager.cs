using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;
    private bool musicMutePressed;
    private bool soundMutePressed;
    private GameObject audioGameObject;
    private AudioSource audioSource;

    [SerializeField] private AudioSource audioSourceWeapon;
    
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSourceWeapon.PlayOneShot(audioClip);
    }
    

    private void Start()
    {
        audioGameObject = GameObject.FindGameObjectWithTag("Sound");
        
        if (audioGameObject != null)
        { 
            audioSource = audioGameObject.GetComponent<AudioSource>();
            musicSlider.value = audioSource.volume;
        }
        musicSlider.value = 0.1f;
        effectSlider.value = 0.1f;
    }

    public void InitializeScene()
    {
        Debug.Log($"should be initalize Againg");
        audioGameObject = GameObject.FindGameObjectWithTag("Sound");
        effectSlider.value = audioSourceWeapon.volume;
        Debug.Log(effectSlider.value);
        if (audioGameObject != null)
        { 
            audioSource = audioGameObject.GetComponent<AudioSource>();
            musicSlider.value = audioSource.volume;
            Debug.Log($"audio is not null");
        }
        musicSlider.value = 0.1f;
        effectSlider.value = 0.1f;
    }

    private void Update()
    {
        audioSource.volume = musicSlider.value;
        audioSourceWeapon.volume = effectSlider.value;
    }

    public void MuteMusic()
    {
        if (!musicMutePressed)
        {
            audioSource.volume = 0;
            musicSlider.value = 0;
            musicMutePressed = true;
        }
        else if (musicMutePressed)
        {
            audioSource.volume = 100;
            musicSlider.value = 100;
            musicMutePressed = false;
        }
    }
    
    public void MuteSoundEffect()
    {
        if (!soundMutePressed)
        {
            audioSourceWeapon.volume = 0;
            effectSlider.value = 0;
            soundMutePressed = true;
        }
        else if (soundMutePressed)
        {
            audioSourceWeapon.volume = 100;
            effectSlider.value = 100;
            soundMutePressed = false;
        }
    }
}
