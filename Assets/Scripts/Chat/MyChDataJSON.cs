using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyChDataJSON: CharacterDataJSON
{
    public long base_exp;
    public long base_exp_to_next_level;
    public long job_exp;
    public long job_exp_to_next_level;
    public string skills;
    public string guild;
    public string data_equipment;
    public string data_inventory;
    public string data_pvp;
}