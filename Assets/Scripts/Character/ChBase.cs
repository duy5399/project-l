using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChBase : MonoBehaviour
{
    public bool isLocalPlayer;
    public Rigidbody rb;
    public BoxCollider boxCollider;

    public ChCurState chCurState;
    public ChAnim chAnim;
    public ChMove chMove;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        chCurState = GetComponent<ChCurState>();
        chAnim = GetComponent<ChAnim>();
        chMove = GetComponent<ChMove>();
    }
}
