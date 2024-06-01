using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapInfo
{
    public string map_id;
    public string map_name;
    public string scene_name;
    public float[] revival_point;
    public int max_player;
    public MapCondition map_condition;
    public bool pvp_enabled;
    //public string npcs;
    public Waypoints[] waypoints;
    public MobInfo[] monsters;
}

[Serializable]
public class MapCondition
{

}

[Serializable]
public class Waypoints
{
    public string map_id;
    public float[] position;
}