using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{

    [SerializeField] protected Animator _animator;
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

    public virtual void TriggerAnim(string animName, float animSpeed = 1f, bool force = false)
    {
        
    }

    public virtual void TriggerEffect(string effectName)
    {

    }
}
