using DG.Tweening;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

[Serializable]
public class CurrentStateSocketIO
{
    #region On (lắng nghe sự kiện)
    public void CurrentStateSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("trigger-hit-damage", (damage) => {
            Debug.Log("trigger-hit-damage: " + damage);
        });

        SocketIO.instance.socketManager.Socket.On<string, int, int>("play-hp-change", (info, damage, colorStyle) => {
            Debug.Log("play-hp-change: " + damage + " - " + colorStyle);
            BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(info);
            Vector3 screenPosition = new Vector3(0, 0, 0);
            if (baseInfo.category == "Player")
            {
                List<GameObject> temp = new List<GameObject>(GameManager.instance.characterManager.otherCharacter);
                temp.Add(GameManager.instance.characterManager.myCharacter);
                GameObject obj = temp.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == baseInfo.uid);
                if (obj != null)
                {
                    screenPosition = obj.transform.position;
                }
            }
            else if(baseInfo.category == "Mob")
            {
                GameObject obj = GameManager.instance.monsterManager.mobs.FirstOrDefault(x => x.GetComponent<MobBase>().mobInfo.uid == baseInfo.uid);
                if (obj != null)
                {
                    screenPosition = obj.transform.position;
                }
            }
            HpIndicatorManager.instance.PlayHPChange(screenPosition, damage.ToString(), (HpIndicatorManager.ColorStyle)colorStyle);
        });

        SocketIO.instance.socketManager.Socket.On<int>("set_hp", (hp) => {
            Debug.Log("set_hp: " + hp);
            ChCurState chCurState = GameManager.instance.characterManager.myCharacter.GetComponent<ChCurState>();
            if (!chCurState)
            {
                return;
            }
            chCurState.hp = hp;
        });

        SocketIO.instance.socketManager.Socket.On<int>("set_maxHp", (maxHp) => {
            Debug.Log("set_maxHp: " + maxHp);
            ChCurState chCurState = GameManager.instance.characterManager.myCharacter.GetComponent<ChCurState>();
            if (!chCurState)
            {
                return;
            }
            chCurState.max_hp = maxHp;
        });

        SocketIO.instance.socketManager.Socket.On<int>("set_sp", (sp) => {
            Debug.Log("set_sp: " + sp);
            ChCurState chCurState = GameManager.instance.characterManager.myCharacter.GetComponent<ChCurState>();
            if (!chCurState)
            {
                return;
            }
            chCurState.sp = sp;
        });

        SocketIO.instance.socketManager.Socket.On<int>("set_maxSp", (maxSp) => {
            Debug.Log("set_maxSp: " + maxSp);
            ChCurState chCurState = GameManager.instance.characterManager.myCharacter.GetComponent<ChCurState>();
            if (!chCurState)
            {
                return;
            }
            chCurState.max_sp = maxSp;
        });
    }
    void On_PlayHpChance(string obj, int damage, int colorStyle)
    {

    }
    #endregion
}
