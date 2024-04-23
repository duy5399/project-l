using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChAnim : AnimManager
{
    public enum Status
    {
        std = 0,
        run_std = 1,
        astd = 2,
        run_astd = 3,
        orther = 4
    }

    [SerializeField] private ChBase chBase;
    public Status _status;
    public RuntimeAnimatorController animCtrl;
    public RuntimeAnimatorController mountAnimCtrl;


    private void Awake()
    {
        chBase = GetComponent<ChBase>();
        _animator = GetComponentInChildren<Animator>();
    }

    public override void TriggerAnim(string animName, float animSpeed = 1f, bool force = false)
    {
        Debug.Log("TriggerAnim: " + animName + " - " + animSpeed);
        if ((animName == "std" && _status == Status.std) || 
            (animName == "run_std" && _status == Status.run_std) || 
            (animName == "astd" && _status == Status.astd) || 
            (animName == "run_astd" && _status == Status.run_astd))
        {
            return;
        }
        if (animator == null)
        {
            return;
        }
        if (animName == "std")
        {
            _status = Status.std;
            animator.ResetTrigger("astd");
            animator.ResetTrigger("run_std");
            animator.ResetTrigger("dizzy");
            animator.ResetTrigger("gathering");
        }
        else if (animName == "run_std")
        {
            _status = Status.run_std;
            animator.ResetTrigger("std");
            animator.ResetTrigger("gathering");
        }

        if (animName == "astd")
        {
            _status = Status.std;
            animator.ResetTrigger("std");
            animator.ResetTrigger("run_astd");
            animator.ResetTrigger("dizzy");
        }
        else if (animName == "run_astd")
        {
            _status = Status.run_std;
            animator.ResetTrigger("astd");
        }

        else if (animName == "force_std")
        {
            animator.ResetTrigger("std");
            animator.ResetTrigger("run_std");
            animator.ResetTrigger("astd");
            animator.ResetTrigger("run_astd");
            animator.ResetTrigger("dizzy");
            animator.ResetTrigger("gathering");
            _status = Status.std;
            animator.speed = 1f;
            this.animSpeed = 1f;
            //InterruptNowAnim();
        }
        else
        {
            _status = Status.orther;
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
    }

    public virtual void TriggerStd(bool force = false)
    {
        TriggerAnim("std", 1f, force);
    }

    public virtual void TriggerAstd(bool force = false)
    {
        TriggerAnim("astd", 1f, force);
    }
    public void TriggerRunStd(bool force = false)
    {
        TriggerAnim("run_std", 1f, force);
    }

    public void TriggerRunAstd(bool force = false)
    {
        TriggerAnim("run_astd", 1f, force);
    }

    public void TriggerGathering(bool force = false)
    {
        TriggerAnim("gathering", 1f, force);
    }

    public void TriggerDizzy(bool force = false)
    {
        TriggerAnim("dizzy", 1f, force);
    }

    public void TriggerAtk1(bool force = false)
    {
        TriggerAnim("new_atk1", 1f, force);
    }

    public void TriggerAtk2(bool force = false)
    {
        TriggerAnim("new_atk2", 1f, force);
    }

    public void TriggerAtk3(bool force = false)
    {
        TriggerAnim("new_atk3", 1f, force);
    }

    public void TriggerSkill1(bool force = false)
    {
        TriggerAnim("skill1", 1f, force);
    }

    public void TriggerSkill2(bool force = false)
    {
        TriggerAnim("skill2", 1f, force);
    }

    public void TriggerSkill3(bool force = false)
    {
        TriggerAnim("skill3", 1f, force);
    }

    public void TriggerSkill4(bool force = false)
    {
        TriggerAnim("skill4", 1f, force);
    }

    public void TriggerSkill5(bool force = false)
    {
        TriggerAnim("skill5", 1f, force);
    }

    public void TriggerSkill6(bool force = false)
    {
        TriggerAnim("skill6", 1f, force);
    }

    public void TriggerHit(bool force = false)
    {
        TriggerAnim("hit", 1f, force);
    }

    public void TriggerDead(bool force = false)
    {
        TriggerAnim("dead", 1f, force);
    }

    public void TriggerLeader(bool force = false)
    {
        TriggerAnim("leader", 1f, force);
    }

    public void TriggerIdle0(bool force = false)
    {
        TriggerAnim("idle0", 1f, force);
    }
}