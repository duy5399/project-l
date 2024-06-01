using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class AnimControllerIO
{
    #region On (lắng nghe sự kiện)
    public void AnimControllerIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string, string, float, bool>("trigger_anim_success", (info, animName, animSpeed, force) => {
            Debug.Log("character-trig-anim-success: " + info);
            BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(info);
            if(baseInfo.category == "Player")
            {
                GameManager.instance.characterManager.TriggerAnim(info, animName, animSpeed, force);
            }
            else
            {
                GameManager.instance.monsterManager.TriggerAnim(info, animName, animSpeed, force);
            }
        });

        SocketIO.instance.socketManager.Socket.On<string, string>("trigger_anim_effect_success", (info, animEffects) => {
            Debug.Log("character-trig-anim-success: " + animEffects);
            BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(info);
            if (baseInfo.category == "Player")
            {
                GameManager.instance.characterManager.TriggerEffect(info, animEffects);
            }
            else
            {
                GameManager.instance.monsterManager.TriggerEffect(info, animEffects);
            }
        });
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_CharacterTrigAnim(string animName, float animSpeed = 1f, bool force = false)
    {
        SocketIO.instance.socketManager.Socket.Emit("trigger-anim", animName, animSpeed, force);
    }
    public void Emit_MobTriggerAnim(string objectName, string animName, float animSpeed = 1f, bool force = false)
    {
        SocketIO.instance.socketManager.Socket.Emit("trigger-anim", objectName, animName, animSpeed, force);
    }
    #endregion
}
