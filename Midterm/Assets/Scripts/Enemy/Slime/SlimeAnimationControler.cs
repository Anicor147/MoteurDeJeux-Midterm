using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimationControler : MonoBehaviour
{
    [SerializeField] private Animator _slimeAnimator;
   
    public void SlimeIsAttacking()
    {
        _slimeAnimator.SetTrigger("SlimeAttack");
    }

    public void SlimeIsHurted()
    {
        _slimeAnimator.SetTrigger("SlimeHurted");  
    }

    public void SlimeIsDead(bool value)
    {
        _slimeAnimator.SetBool("SlimeDeath" , value);
    }
}
