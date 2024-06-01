using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobAnim : AnimManager
{
    [SerializeField] private MobBase mobBase;
    private void Awake()
    {
        mobBase = this.GetComponent<MobBase>();
        _animator = this.GetComponentInChildren<Animator>();
    }

    public override void TriggerAnim(string animName, float animSpeed = 1f, bool force = false, AnimEffect[] animEffects = null)
    {
        Debug.Log("TriggerAnim: " + animName + " - " + animSpeed);
        if ((animName == "monster_std" && status == Status.Std) || (animName == "monster_run" && status == Status.Run_Std))
        {
            return;
        }
        if (animator == null)
        {
            return;
        }
        if (animName == "monster_std")
        {
            status = Status.Std;
            animator.ResetTrigger("monster_run");
        }
        else if (animName == "monster_run")
        {
            status = Status.Run_Std;
            animator.ResetTrigger("monster_std");
        }
        else if (animName == "force_std")
        {
            animator.ResetTrigger("monster_std");
            animator.ResetTrigger("monster_run");
            status = Status.Std;
            animator.speed = 1f;
            this.animSpeed = 1f;
            //InterruptNowAnim();
        }
        else
        {
            status = Status.Orther;
            //InterruptNowAnim();
        }
        animator.speed = animSpeed;
        this.animSpeed = animSpeed;
        if (force)
        {
            Debug.Log("TriggerAnim: " + animName + " - " + animator.speed);
            animator.Play(animName);
        }
        else
        {
            animator.SetTrigger(animName);
        }
        if (animEffects == null)
        {
            return;
        }
        for (int i = 0; i < animEffects.Count(); i++)
        {
            SpawnAnimEffect(animEffects[i]);
        }
    }

    public virtual void TriggerRevive(bool force = false)
    {
        TriggerAnim("revive", 1f, force);
    }

    public virtual void TriggerStd(bool force = false)
    {
        TriggerAnim("monster_std", 1f, force);
    }

    public void TriggerRunStd(bool force = false)
    {
        TriggerAnim("monster_run", 1f, force);
    }

    public void TriggerAtk1(bool force = false)
    {
        TriggerAnim("atk", 1f, force);
    }

    public void TriggerDead(bool force = false)
    {
        TriggerAnim("dead", 1f, force);
    }

    public void TriggerDizzy(bool force = false)
    {
        TriggerAnim("dizzy", 1f, force);
    }
}
