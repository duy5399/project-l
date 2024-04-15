using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterDataJSON
{
    public string nickname;
    public string job;
    public bool gender;
    public int level;
    public BasicStats basicStats;
    public string mount;
    public string profileImg;
    public float[] data_position;
    public float[] data_rotation;
}

public class BasicStats
{
    public float p_atk;
    public float m_atk;
    public float max_hp;
    public float max_sp;
    public float def;
    public float m_def;
    public float a_pen;
    public float m_pen;
    public float aspd;
    public float haste;
    public float hit;
    public float dodge;
    public float crit;
    public float anti_crit;
}