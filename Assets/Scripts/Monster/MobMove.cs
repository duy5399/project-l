using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MobMove : MonoBehaviour
{
    [SerializeField] private MobCurState mobCurState;
    [SerializeField] private ChAnim mobAnim;
    [SerializeField] private float timeMove;
    [SerializeField] private float rangeRandomMove;
    [SerializeField] private Vector3 randomPosition;
    [SerializeField] private bool getRandomPosition;

    private void Awake()
    {
        mobCurState = this.GetComponent<MobCurState>();
        timeMove = 3f;
        rangeRandomMove = 0.5f;
        getRandomPosition = false;
    }
    private void Start()
    {
        //GameObject x = GameObject.FindGameObjectWithTag("Player");
        //Vector3 vector = x.transform.position - this.transform.position;
        //this.transform.rotation = LookRotation(vector, Vector3.up);
        //this.transform.rotation = Quaternion.LookRotation(vector, Vector3.up);

    }
    // Update is called once per frame
    void Update()
    {
        //GameObject x = GameObject.FindGameObjectWithTag("Player");
        //Vector3 vector = x.transform.position - this.transform.position;
        //this.transform.rotation = LookRotation(vector, Vector3.up);
        //this.transform.LookAt(x.transform);
        //if(!mobCurState || mobCurState.monsterInfo.data_stats.dead || mobCurState.monsterInfo.data_stats.inCombat)
        //{
        //    return;
        //}
        //if (timeMove >= 0)
        //{
        //    timeMove -= Time.deltaTime;
        //    return;
        //}
        //if (!getRandomPosition)
        //{
        //    float randomX = UnityEngine.Random.Range(-rangeRandomMove, rangeRandomMove);
        //    float randomY = UnityEngine.Random.Range(-rangeRandomMove, rangeRandomMove);
        //    randomPosition = new Vector3(mobCurState.monsterInfo.spawningPosition[0] + randomX, mobCurState.monsterInfo.spawningPosition[1], mobCurState.monsterInfo.spawningPosition[2] + randomY);
        //    getRandomPosition = true;
        //    //SocketIO.instance.animControllerIO.Emit_MobTriggerAnim("monster_run");
        //}
        //this.transform.position = Vector3.MoveTowards(transform.position, randomPosition, Time.deltaTime * mobCurState.monsterInfo.monster_att.move_spd);
        //this.transform.LookAt(randomPosition);

        //if (this.transform.position == randomPosition)
        //{
        //    //SocketIO.instance.animControllerIO.Emit_MobTriggerAnim("monster_std");
        //    getRandomPosition = false;
        //    timeMove = UnityEngine.Random.Range(4f, 6f);
        //}
    }

    public static Quaternion LookRotation(Vector3 forward, Vector3 upwards)
    {
        //calc new ortagonal directions
        Vector3 newForward = forward.normalized;
        Vector3 newRight = Vector3.Cross(upwards, newForward).normalized;
        Vector3 newUp = Vector3.Cross(newForward, newRight).normalized;

        //fill matrix
        Matrix4x4 mat = Matrix4x4.identity;
        mat.SetColumn(0, newRight);
        mat.SetColumn(1, newUp);
        mat.SetColumn(2, newForward);

        //calc quaternion
        Quaternion quat = Quaternion.identity;
        quat.w = Mathf.Sqrt(1.0f + mat.m00 + mat.m11 + mat.m22) / 2.0f;
        float q4 = quat.w * 4;
        quat.x = (mat.m21 - mat.m12) / q4;
        quat.y = (mat.m02 - mat.m20) / q4;
        quat.z = (mat.m10 - mat.m01) / q4;
        
        return quat;

        Vector3 eulerAngle = new Vector3(30f, 45f, 60f); // 欧拉角度
        float x = eulerAngle.x * Mathf.Deg2Rad; // 将角度转换为弧度
        float y = eulerAngle.y * Mathf.Deg2Rad;
        float z = eulerAngle.z * Mathf.Deg2Rad;
        float sinX = Mathf.Sin(x);
        float cosX = Mathf.Cos(x);
        float sinY = Mathf.Sin(y);
        float cosY = Mathf.Cos(y);
        float sinZ = Mathf.Sin(z);
        float cosZ = Mathf.Cos(z);

        Quaternion quaternion = new Quaternion();
        quaternion.w = cosX * cosY * cosZ + sinX * sinY * sinZ;
        quaternion.x = sinX * cosY * cosZ - cosX * sinY * sinZ;
        quaternion.y = cosX * sinY * cosZ + sinX * cosY * sinZ;
        quaternion.z = cosX * cosY * sinZ - sinX * sinY * cosZ;
    }

    public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
    {
        //calc rot angle
        float angleHalfRad = Vector3.Angle(fromDirection, toDirection) / 2 * Mathf.Deg2Rad;

        //calc rot axis
        Vector3 axis = Vector3.Cross(fromDirection, toDirection).normalized;
        axis *= Mathf.Sin(angleHalfRad);

        //calc quaternion
        Quaternion quat = new Quaternion(axis.x, axis.y, axis.z, Mathf.Cos(angleHalfRad));
        return quat;
    }

}
