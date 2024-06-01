using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> mobs;

    private void Awake()
    {
        mobs = new List<GameObject>();
    }

    public void InitMonster(MobInfo monster)
    {
        GameObject monsterPrefab = Resources.Load<GameObject>("character/baseprefab/Monster");
        if (monsterPrefab == null)
        {
            Debug.Log("monsterPrefab");
        }
        Debug.Log(monster.monster_id + monster.data_position[0] + monster.data_position[1] + monster.data_position[2]);
        GameObject monsterObj = Instantiate(monsterPrefab, new Vector3(monster.data_position[0], monster.data_position[1], monster.data_position[2]), Quaternion.identity);
        monsterObj.tag = monster.category;
        GameObject modelPrefab = Resources.Load<GameObject>("character/mon_" + monster.monster_id + "/" + "M_" + monster.monster_id);
        if (modelPrefab == null)
        {
            return;
        }
        GameObject modelObj = Instantiate(modelPrefab);
        modelObj.transform.SetParent(monsterObj.transform);
        modelObj.transform.localPosition = Vector3.zero;
        monsterObj.GetComponent<MobCurState>().monsterInfo = monster;
        MobBase monsterBase = monsterObj.GetComponent<MobBase>();
        MobCurState monsterCurState = monsterObj.GetComponent<MobCurState>();
        MobAnim mobAnim = monsterObj.GetComponent<MobAnim>();
        monsterBase.mobInfo = monster;
        monsterCurState.stats = monster.data_stats;
        mobAnim.animator = modelObj.GetComponent<Animator>();
        mobs.Add(monsterObj);
    }

    public void MonsterMove(string _monsterInfo)
    {
        MobInfo monsterInfo = JsonConvert.DeserializeObject<MobInfo>(_monsterInfo);
        if (monsterInfo.category != "Mob" )
        {
            return;
        }
        GameObject monsterObj = mobs.FirstOrDefault(x => x.GetComponent<MobBase>().mobInfo.uid == monsterInfo.uid);
        if (monsterObj == null)
        {
            return;
        }
        //Debug.Log("MonsterMove: " + _monsterInfo);
        monsterObj.transform.position = new Vector3(monsterInfo.data_position[0], monsterInfo.data_position[1], monsterInfo.data_position[2]);
    }

    public void MonsterRotate(string _monsterInfo)
    {
        MobInfo monsterInfo = JsonConvert.DeserializeObject<MobInfo>(_monsterInfo);
        if (monsterInfo.category != "Mob")
        {
            return;
        }
        GameObject monsterObj = mobs.FirstOrDefault(x => x.GetComponent<MobBase>().mobInfo.uid == monsterInfo.uid);
        if (monsterObj == null)
        {
            return;
        }
        //Debug.Log("MonsterRotate: " + _monsterInfo);
        monsterObj.transform.rotation = new Quaternion(monsterInfo.data_rotation[0], monsterInfo.data_rotation[1], monsterInfo.data_rotation[2], monsterInfo.data_rotation[3]);
    }

    public void TriggerAnim(string _baseInfo, string animName, float animSpeed, bool force)
    {
        BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(_baseInfo);
        GameObject mobObj = mobs.FirstOrDefault(x => x.GetComponent<MobBase>().mobInfo.uid == baseInfo.uid);
        if (mobObj == null)
        {
            return;
        }
        mobObj.GetComponent<AnimManager>().TriggerAnim(animName, animSpeed, force);
    }

    public void TriggerEffect(string _baseInfo, string _animEffects)
    {
        BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(_baseInfo);
        GameObject mobObj = mobs.FirstOrDefault(x => x.GetComponent<MobBase>().mobInfo.uid == baseInfo.uid);
        if (mobObj == null)
        {
            return;
        }
        MobAnim mobAnim = mobObj.GetComponent<MobAnim>();
        AnimEffect[] animEffects = JsonConvert.DeserializeObject<AnimEffect[]>(_animEffects);
        for (int i = 0; i < animEffects.Length; i++)
        {
            mobAnim.SpawnAnimEffect(animEffects[i]);
        }
    }
}
