using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAnimationController : MonoBehaviour
{ 
    [SerializeField] private Animator _hunterAnimator;
   
    public void HunterIsAttacking()
    {
        _hunterAnimator.SetTrigger("isAttacking");
    }

    public void HunterIsDead(bool value)
    {
        _hunterAnimator.SetBool("isDeath" , value);
    }
    
    public void HunterIsRunning(bool value)
    {
        _hunterAnimator.SetBool("isRunning" , value);
    }
}
