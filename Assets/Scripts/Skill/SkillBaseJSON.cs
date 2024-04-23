using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[Serializable]
public class SkillBaseJSON
{
    public string skill_id;
    public string skill_name;
    public SkillUseType skill_use_type;
    public bool is_normal_attack;
    public string description;
    public int max_level;
    public SkillTargetType skill_target_type;
    public SkillPos skill_pos;
    public SkillLogic skill_logic;
    public float distance;
    public bool can_be_silenced;
    public bool can_interrupt;
    public bool can_move_when_casting;
    public string skill_animName;
    public float cast_head_time;
    public float casting_time;
    public float cast_back_time;
    public bool scale_animSpeed;
    public float channel_time;
    public SkillInfo[] skill_info;
    public int level_require;
    public string skill_require;
    public string[] class_require;
    public int display_id;

    public string Description(int level)
    {
        string _description = description;
        if (_description.Contains("{raw_damage}"))
        {
            _description = _description.Replace("{raw_damage}", (skill_info[level].damage.raw_damage * 100) + "%");
        }
        if (_description.Contains("{p_atk_multiplier}"))
        {
            _description = _description.Replace("{p_atk_multiplier}", skill_info[level].damage.p_atk_multiplier.ToString());
        }
        if (_description.Contains("{cd}"))
        {
            _description = _description.Replace("{cd}", skill_info[level].cd.ToString());
        }
        return _description;
    }
}

public enum SkillUseType
{
    Passive = 0,
    Active = 1
}

public enum SkillTargetType
{
    None = 0,
    Self = 1,
    Ally = 2,
    Enemy = 3
}

public enum SkillTarget
{
    None = 0,
    Self = 1,
    Target = 2,
    Party = 3
}

[Serializable]
public class SkillInfo
{
    public int skill_lv;
    public Damage damage;
    public Buff buff;
    public Debuff debuff;
    public int maxTarget;
    public float cd;
    public float sp_cost;

    //public string buff": [
    //  {
    //    "buff_id": "Spear_Stab_Decrease_Armor",
    //    "status_effect": "DecreaseArmor",
    //    "append_type": "Add",
    //    "amount": 0.1,
    //    "lifetime": 3
    //  }
    //]
}
[Serializable]
public class Damage
{
    public DamageType damage_type;
    public float raw_damage;
    public float p_atk_multiplier;
    public float m_atk_multiplier;
    public bool can_crit;
    public bool can_lifesteal;
    //TO DO: có thể thêm chỉ số %hp, %def,...
}

public enum DamageType
{
    P_ATK = 0,
    M_ATK = 1
}

public enum SkillPos
{
    None = 0,
    Target = 1,     //mục tiêu
    TargetPos = 2,  //vị trí mục tiêu
    //SelfPos = 3,    //vị trí ngay bản thân
    //AroundSelf = 4  //vị trí là xung quanh bản thân

    //Sigle = 0,
    //AroundSelf = 1,
    //AroundTarget = 2,
    //FanShape = 3,
    //Line = 4
}

public enum SkillShapeType
{
    Sigle = 1,
    Rectangle = 2,
    CircularSector = 3,
    Circle = 4
};

[Serializable]
public class SkillLogic
{
    public Logic logic;
    public SkillShapeType skill_shape_type;
    public float[] shape_param;
    public int count;
    public int interval;
    public int max_hit_num;
}

public enum Logic
{
    //LockedTarget = 0,
    //SelfRange = 1,
    //PointRange = 2
    Single =0,
    Range = 1
}

public enum TriggerHitOn
{
    None = 0,
    EveryCollision = 1,
    FirstCollision = 2,
    EveryTick = 3
}
[Serializable]
public class Buff
{
    public string buff_id;
    public AnimEffects[] animEffects;
    public SearchAmong searchAmong;

    //[JsonConverter(typeof(StringEnumConverter))]
    //public BuffOn buffOn;
    public float buffRange;
    public int maxHitNum;
    public bool haveLifeTime;
    public float[] lifeTime;
    public bool destroyOnLifeEnding;
    //[JsonConverter(typeof(StringEnumConverter))]
    //public AddType addType;
    public int maxStackUp;
    public bool lifeTimeCanChange;
}
[Serializable]
public class AnimEffects
{
    public string effectName;
    public float delay;
    public Vector3 offset;
    public float lifeTime;
    public bool followHero = true;
    public bool endWithAnim = true;
}

public enum SearchAmong
{
    None = 0,
    Allies = 1,
    Enemies = 2
}
[Serializable]
public class Debuff : Buff
{

}
