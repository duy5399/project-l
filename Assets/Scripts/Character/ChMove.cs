using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChMove : ChBase
{
    public FixedJoystick joystick;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!joystick)
        {
            return;
        }
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            rb.velocity = new Vector3(joystick.Vertical * chCurState.moveSpeed, rb.velocity.y, -joystick.Horizontal * chCurState.moveSpeed);
            SocketIO.instance.characterSocketIO.Emit_CharacterMove(base.transform.position);
            base.transform.rotation = Quaternion.LookRotation(rb.velocity);
            SocketIO.instance.characterSocketIO.Emit_CharacterRotate(rb.velocity);
            base.chAnim.TriggerRunStd();
        }
        else if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            rb.velocity = Vector3.zero;
            base.chAnim.TriggerStd();
        }
    }
}
