using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class ChAnim : AnimManager
{
    [SerializeField] private ChBase chBase;
    public RuntimeAnimatorController animCtrl;
    public RuntimeAnimatorController mountAnimCtrl;


    private void Awake()
    {
        chBase = GetComponent<ChBase>();
        _animator = GetComponentInChildren<Animator>();
    }

    public override void TriggerAnim(string animName, float animSpeed = 1f, bool force = false, AnimEffect[] animEffects = null)
    {
        Debug.Log("TriggerAnim: " + animName + " - " + animSpeed);
        if ((animName == "std" && status == Status.Std) || 
            (animName == "run_std" && status == Status.Run_Std) || 
            (animName == "astd" && status == Status.Astd) || 
            (animName == "run_astd" && status == Status.Run_astd))
        {
            return;
        }
        if (animator == null)
        {
            return;
        }
        if (animName == "std")
        {
            status = Status.Std;
            animator.ResetTrigger("astd");
            animator.ResetTrigger("run_std");
            animator.ResetTrigger("dizzy");
            animator.ResetTrigger("gathering");
        }
        else if (animName == "run_std")
        {
            status = Status.Run_Std;
            animator.ResetTrigger("std");
            animator.ResetTrigger("gathering");
        }

        if (animName == "astd")
        {
            status = Status.Std;
            animator.ResetTrigger("std");
            animator.ResetTrigger("run_astd");
            animator.ResetTrigger("dizzy");
        }
        else if (animName == "run_astd")
        {
            status = Status.Run_Std;
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
        if(animEffects == null)
        {
            return;
        }
        for(int i = 0; i < animEffects.Count(); i++)
        {
            SpawnAnimEffect(animEffects[i]);
        }
    }

    public override void SpawnAnimEffect(AnimEffect animEffect)
    {
        GameObject effectObj = chBase.chEffect.GetEffect(animEffect);
        if(!effectObj)
        {
            return;
        }
        if (animEffect.followHero)
        {
            effectObj.transform.parent = this.transform;
        }
        //else
        //{
        //    effect.transform.parent = null;
        //}
        if (animEffect.scaleAnimSpeed)
        {
            effectObj.GetComponentsInChildren<ParticleSystem>().ToList().ForEach(p =>
            {
                p.startDelay /= animEffect.animSpeed;
            });
        }
        effectObj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        effectObj.transform.localPosition = new Vector3(animEffect.offset[0], animEffect.offset[1], animEffect.offset[2]);
        effectObj.transform.localScale = Vector3.one;
        effectObj.SetActive(true);
        //component.lifeTime = effect.lifeTime;
        GameManager.instance.WaitFor(animEffect.lifeTime, () =>
        {
            effectObj.SetActive(false);
        });
    }

    public override void SpawnAnimAudio(string audio)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("sound/" + audio);
        if (!audioClip)
        {
            return;
        }
        chBase.audioSource.PlayOneShot(audioClip);
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