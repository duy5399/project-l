using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBase : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public AudioSource audioSource;
    public ChCurState chCurState;
    public ChAnim chAnim;
    public ChMove chMove;
    public ChSkill chSkill;
    public ChEffect chEffect;
    public ChWeakness chWeakness;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
        chCurState = GetComponent<ChCurState>();
        chAnim = GetComponent<ChAnim>();
        chMove = GetComponent<ChMove>();
        chSkill = GetComponent<ChSkill>();
        chEffect = GetComponent<ChEffect>();
        chWeakness = GetComponentInChildren<ChWeakness>();
    }

    public float DistanceToObj(GameObject a, GameObject b)
    {
        float distance = Vector3.Distance(a.transform.position, b.transform.position);
        //Debug.Log(distance);
        return distance;
    }
}
public enum Category
{
    Player = 1,
    Pet = 2,
    Mob = 3,
    WorldBoss = 4,
    Npc = 5,
}