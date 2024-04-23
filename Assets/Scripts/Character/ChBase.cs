using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChBase : MonoBehaviour
{
    public enum Category
    {
        None = 0,
        Player = 1,
        Npc = 2,
        Mob = 3,
        Boss = 4
    }
    public bool isLocalPlayer;
    public Category category;

    public Rigidbody rb;
    public BoxCollider boxCollider;
    public ChCurState chCurState;
    public ChAnim chAnim;
    public ChMove chMove;
    public ChSkill chSkill;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        chCurState = GetComponent<ChCurState>();
        chAnim = GetComponent<ChAnim>();
        chMove = GetComponent<ChMove>();
        chSkill = GetComponent<ChSkill>();

        isLocalPlayer = false;
        category = Category.None;
    }

    public float DistanceToObj(GameObject a, GameObject b)
    {
        float distance = Vector3.Distance(a.transform.position, b.transform.position);
        //Debug.Log(distance);
        return distance;
    }
}
