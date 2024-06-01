using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChBase : ObjBase
{
    public CharacterInfo chInfo;
    public bool isLocalPlayer;

    protected override void Awake()
    {
        base.Awake();
        isLocalPlayer = false;
    }

    public float DistanceToObj(GameObject a, GameObject b)
    {
        float distance = Vector3.Distance(a.transform.position, b.transform.position);
        //Debug.Log(distance);
        return distance;
    }
}
