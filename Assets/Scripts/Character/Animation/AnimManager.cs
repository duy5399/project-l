using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public enum Status
    {
        Std = 0,
        Run_Std = 1,
        Astd = 2,
        Run_astd = 3,
        Orther = 4
    }

    [SerializeField] protected Animator _animator;
    public Status status;
    public float animSpeed = 1f;

    public Animator animator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    public void ChangeAnimator(RuntimeAnimatorController a)
    {
        if (a && animator)
        {
            animator.runtimeAnimatorController = a;
        }
    }

    public virtual void TriggerAnim(string animName, float animSpeed = 1f, bool force = false, AnimEffect[] animEffects = null)
    {
        
    }

    public virtual void TriggerEffect(string effectName)
    {

    }

    public virtual void SpawnAnimEffect(AnimEffect animEffect)
    {

    }

    public virtual void SpawnAnimAudio(string audio)
    {
        
    }
}
