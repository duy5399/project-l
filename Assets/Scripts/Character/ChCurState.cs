using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChCurState : ObjState
{
    public override float hp
    {
        get { return base.hp; }
        set
        {
            base.hp = value;
            HPbar.instance.hpTxt.text = hp.ToString() + "/" + max_hp.ToString();
            if (max_hp == 0)
            {
                HPbar.instance.hpSld.value = 0;
            }
            else
            {
                HPbar.instance.hpSld.value = ((float)hp / (float)max_hp);
            }
        }
    }
    public override float max_hp
    {
        get { return base.max_hp; }
        set
        {
            base.max_hp = value;
            HPbar.instance.hpTxt.text = hp.ToString() + "/" + max_hp.ToString();
            HPbar.instance.hpSld.value = ((float)hp / (float)max_hp);
        }
    }
    public override float sp
    {
        get { return base.sp; }
        set
        {
            base.sp = value;
            HPbar.instance.spTxt.text = sp.ToString() + "/" + max_sp.ToString();
            if (max_sp == 0)
            {
                HPbar.instance.spSld.value = 0;
            }
            else
            {
                HPbar.instance.spSld.value = ((float)sp / (float)max_sp);
            }
        }
    }
    public override float max_sp
    {
        get { return base.max_sp; }
        set
        {
            base.max_sp = value;
            HPbar.instance.spTxt.text = sp.ToString() + "/" + max_sp.ToString();
            HPbar.instance.spSld.value = ((float)sp / (float)max_sp);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        //InitStats();
    }

    void InitStats()
    {
        SocketIO.instance.characterSocketIO.Emit_InitStats();
    }

    public void Init(DataStats data_stats)
    {
        p_atk = data_stats.p_atk;
        m_atk = data_stats.m_atk;
        hp = data_stats.hp;
        max_hp = data_stats.max_hp;
        sp = data_stats.sp;
        max_sp = data_stats.max_sp;
        p_def = data_stats.p_def;
        m_def = data_stats.m_def;
        p_pen = data_stats.p_pen;
        m_pen = data_stats.m_pen;
        aspd = data_stats.aspd;
        haste = data_stats.haste;
        hit = data_stats.hit;
        flee = data_stats.flee;
        crit = data_stats.crit;
        anti_crit = data_stats.anti_crit;
        crit_dmg = data_stats.crit_dmg;
        anti_crit_dmg = data_stats.anti_crit_dmg;
        shield = data_stats.shield;
        move_spd = data_stats.move_spd;
        hp_regen_spd = data_stats.hp_regen_spd;
        sp_regen_spd = data_stats.sp_regen_spd;
        p_lifesteal = data_stats.p_lifesteal;
        m_lifesteal = data_stats.m_lifesteal;
        p_reflect = data_stats.p_reflect;
        m_reflect = data_stats.m_reflect;
        dead = data_stats.dead;
        inCombat = data_stats.inCombat;
    }
}
