using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChargingClip : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    
    public void PlayChargingSoundClip()
    {
        SoundManager.instance.PlaySound(_clip);
    }
    
}
