using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChMove : MonoBehaviour
{
    [SerializeField] private ChBase chBase;
    public FixedJoystick joystick;
    public bool autoMoveToTarget;
    public float distanceWithTarget;

    private void Awake()
    {
        chBase = GetComponent<ChBase>();
        autoMoveToTarget = false;
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
            distanceWithTarget = 0;
            autoMoveToTarget = false;
            chBase.rb.velocity = new Vector3(joystick.Vertical * chBase.chCurState.moveSpeed, chBase.rb.velocity.y, -joystick.Horizontal * chBase.chCurState.moveSpeed);
            SocketIO.instance.characterSocketIO.Emit_CharacterMove(this.transform.position);
            this.transform.rotation = Quaternion.LookRotation(chBase.rb.velocity);
            SocketIO.instance.characterSocketIO.Emit_CharacterRotate(chBase.rb.velocity);
            //Debug.Log(chBase.rb.velocity.x + ", " + chBase.rb.velocity.y + ", " + chBase.rb.velocity.z);
        }
        else if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            chBase.rb.velocity = Vector3.zero;
            //base.chAnim.TriggerStd();
        }
    }



    public void AutoMoveToTarget(GameObject target, Action func = null)
    {
        StartCoroutine(_AutoMoveToTarget(target, func));
    }

    IEnumerator _AutoMoveToTarget(GameObject target, Action func)
    {
        while(chBase.DistanceToObj(this.gameObject, target) > distanceWithTarget)
        {
            if(!autoMoveToTarget || distanceWithTarget == 0)
            {
                break;
            }
            Vector3 vector3 = target.transform.position - this.transform.position;
            vector3 = vector3.normalized;
            chBase.rb.velocity = new Vector3(vector3.x * chBase.chCurState.moveSpeed, chBase.rb.velocity.y, vector3.z * chBase.chCurState.moveSpeed);
            SocketIO.instance.characterSocketIO.Emit_CharacterMove(this.transform.position);
            this.transform.rotation = Quaternion.LookRotation(chBase.rb.velocity);
            SocketIO.instance.characterSocketIO.Emit_CharacterRotate(chBase.rb.velocity);
            yield return new WaitForEndOfFrame();
        }
        if(!autoMoveToTarget || distanceWithTarget == 0)
        {
            yield break;
        }
        distanceWithTarget = 0;
        autoMoveToTarget = false;
        func();
    }
}
