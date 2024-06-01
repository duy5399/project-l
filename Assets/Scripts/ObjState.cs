using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjState : MonoBehaviour
{
    public DataStats stats;

    public float p_atk
    {
        get { return stats.p_atk; }
        set { stats.p_atk = value; }
    }
    public float m_atk
    {
        get { return stats.m_atk; }
        set { stats.m_atk = value; }
    }
    public virtual float hp
    {
        get { return stats.hp; }
        set { stats.hp = value; }
    }
    public virtual float max_hp
    {
        get { return stats.max_hp; }
        set { stats.max_hp = value; }
    }
    public virtual float sp
    {
        get { return stats.sp; }
        set { stats.sp = value; }
    }
    public virtual float max_sp
    {
        get { return stats.max_sp; }
        set { stats.max_sp = value; }
    }
    public float p_def
    {
        get { return stats.p_def; }
        set { stats.p_def = value; }
    }
    public float m_def
    {
        get { return stats.m_def; }
        set { stats.m_def = value; }
    }
    public float p_pen
    {
        get { return stats.p_pen; }
        set { stats.p_pen = value; }
    }
    public float m_pen
    {
        get { return stats.m_pen; }
        set { stats.m_pen = value; }
    }
    public float aspd
    {
        get { return stats.aspd; }
        set { stats.aspd = value; }
    }
    public float haste
    {
        get { return stats.haste; }
        set { stats.haste = value; }
    }
    public float hit
    {
        get { return stats.hit; }
        set { stats.hit = value; }
    }
    public float flee
    {
        get { return stats.flee; }
        set { stats.flee = value; }
    }
    public float crit
    {
        get { return stats.crit; }
        set { stats.crit = value; }
    }
    public float anti_crit
    {
        get { return stats.anti_crit; }
        set { stats.anti_crit = value; }
    }
    public float crit_dmg
    {
        get { return stats.crit_dmg; }
        set { stats.crit_dmg = value; }
    }
    public float anti_crit_dmg
    {
        get { return stats.anti_crit_dmg; }
        set { stats.anti_crit_dmg = value; }
    }
    public float shield
    {
        get { return stats.shield; }
        set { stats.shield = value; }
    }
    public float move_spd
    {
        get { return stats.move_spd; }
        set { stats.move_spd = value; }
    }
    public float hp_regen_spd
    {
        get { return stats.hp_regen_spd; }
        set { stats.hp_regen_spd = value; }
    }
    public float sp_regen_spd
    {
        get { return stats.sp_regen_spd; }
        set { stats.sp_regen_spd = value; }
    }
    public float p_lifesteal
    {
        get { return stats.p_lifesteal; }
        set { stats.p_lifesteal = value; }
    }
    public float m_lifesteal
    {
        get { return stats.m_lifesteal; }
        set { stats.m_lifesteal = value; }
    }
    public float p_reflect
    {
        get { return stats.p_reflect; }
        set { stats.p_reflect = value; }
    }
    public float m_reflect
    {
        get { return stats.m_reflect; }
        set { stats.m_reflect = value; }
    }

    public bool dead
    {
        get { return stats.dead; }
        set { stats.dead = value; }
    }
    public bool inCombat
    {
        get { return stats.inCombat; }
        set { stats.inCombat = value; }
    }

    public bool isTeleporting;

    [SerializeField] protected float _silenceTimeLeft = 0f;
    [SerializeField] protected float _attackDisableTimeLeft = 0f;
    [SerializeField] protected float _moveDisableTimeLeft = 0f;
    [SerializeField] protected float _slowMoveTimeLeft = 0f;


    protected virtual void Awake()
    {
        isTeleporting = false;
    }

    protected virtual void Start()
    {
        //InitStats();
    }

    void InitStats()
    {
        SocketIO.instance.characterSocketIO.Emit_InitStats();
    }
}

public enum State
{
    OutCombat = 1,
    InCombat = 2,
    Gathering = 3,
    Channeling = 4,
}