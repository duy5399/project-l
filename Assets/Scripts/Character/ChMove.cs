using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChMove : ObjMove
{
    [SerializeField] private ChBase chBase;
    [SerializeField] private ChCurState chCurState;
    public FixedJoystick joystick;
    public bool isMoving;

    protected override void Awake()
    {
        chBase = this.GetComponent<ChBase>();
        chCurState = this.GetComponent<ChCurState>();
        autoMoveToTarget = false;
        isMoving = false;
    }

    protected override void Start()
    {

    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    protected override void Move()
    {
        if (!joystick)
        {
            return;
        }
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            distanceWithTarget = 0;
            autoMoveToTarget = false;
            chBase.rb.velocity = new Vector3(joystick.Vertical * chBase.chCurState.move_spd, chBase.rb.velocity.y, -joystick.Horizontal * chBase.chCurState.move_spd);
            SocketIO.instance.moveControllerIO.Emit_CharacterMove(this.transform.position);
            this.transform.rotation = Quaternion.LookRotation(chBase.rb.velocity);
            SocketIO.instance.moveControllerIO.Emit_CharacterRotate(this.transform.rotation);
            isMoving = true;
        }
        else if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            chBase.rb.velocity = Vector3.zero;
            //base.chAnim.TriggerStd();
            if (isMoving)
            {
                if (chCurState.inCombat)
                {
                    SocketIO.instance.animControllerIO.Emit_CharacterTrigAnim("astd");
                }
                else
                {
                    SocketIO.instance.animControllerIO.Emit_CharacterTrigAnim("std");
                }
                isMoving = false;
            }
        }
    }
}
