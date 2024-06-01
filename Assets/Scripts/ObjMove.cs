using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    public bool autoMoveToTarget;
    public float distanceWithTarget;

    protected virtual void Awake()
    {
        autoMoveToTarget = false;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
       
    }

    protected virtual void Move()
    {
        
    }



    //public void AutoMoveToTarget(GameObject target, Action func = null)
    //{
    //    StartCoroutine(_AutoMoveToTarget(target, func));
    //}

    //IEnumerator _AutoMoveToTarget(GameObject target, Action func)
    //{
    //    while (chBase.DistanceToObj(this.gameObject, target) > distanceWithTarget)
    //    {
    //        if (!autoMoveToTarget || distanceWithTarget == 0)
    //        {
    //            break;
    //        }
    //        Vector3 vector3 = target.transform.position - this.transform.position;
    //        vector3 = vector3.normalized;
    //        chBase.rb.velocity = new Vector3(vector3.x * chBase.chCurState.move_spd, chBase.rb.velocity.y, vector3.z * chBase.chCurState.move_spd);
    //        SocketIO.instance.moveControllerIO.Emit_CharacterMove(this.transform.position);
    //        this.transform.rotation = Quaternion.LookRotation(chBase.rb.velocity);
    //        //SocketIO.instance.characterSocketIO.Emit_CharacterRotate(chBase.rb.velocity);
    //        yield return new WaitForEndOfFrame();
    //    }
    //    if (!autoMoveToTarget || distanceWithTarget == 0)
    //    {
    //        yield break;
    //    }
    //    distanceWithTarget = 0;
    //    autoMoveToTarget = false;
    //    func();
    //}
}
