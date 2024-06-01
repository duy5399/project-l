using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseInfo
{
    public string uid;
    public int level;
    //this.data_skills = null;
    public string profileImg;
    public string data_location;
    public float[] data_position;
    public float[] data_rotation;
    //this.currentState = null;
    public string category;
}

[Serializable]
public class CharacterInfo : BaseInfo
{
    public string nickname;
    public string job;
    public bool gender;
    public DataStats data_stats;
    public string mount;

}

[Serializable]
public class MobInfo : BaseInfo
{
    public string monster_id;
    public string monster_name;
    public DataStats data_stats;
    public string drop_list;

}

[Serializable]
public class DataStats
{
    public float p_atk;
    public float m_atk;
    public float hp;
    public float max_hp;
    public float sp;
    public float max_sp;
    public float p_def;
    public float m_def;
    public float p_pen;
    public float m_pen;
    public float aspd;
    public float haste;
    public float hit;
    public float flee;
    public float crit;
    public float anti_crit;
    public float crit_dmg;
    public float anti_crit_dmg;
    public float shield;
    public float move_spd;
    public float hp_regen_spd;
    public float sp_regen_spd;
    public float p_lifesteal;
    public float m_lifesteal;
    public float p_reflect;
    public float m_reflect;
    public bool dead;
    public bool inCombat;
}