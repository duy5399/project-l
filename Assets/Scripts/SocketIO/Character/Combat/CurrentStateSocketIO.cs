using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CurrentStateSocketIO
{
    #region On (lắng nghe sự kiện)
    public void CurrentStateSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("trigger-hit-damage", (damage) => {
            Debug.Log("trigger-hit-damage: " + damage);
        });

        SocketIO.instance.socketManager.Socket.On<string, int, int>("play-hp-change", (obj, damage, colorStyle) => {
            Debug.Log("play-hp-change: " + damage + " - " + colorStyle);
            On_PlayHpChance(obj, damage, colorStyle);
        });
    }
    void On_PlayHpChance(string obj, int damage, int colorStyle)
    {
        GameObject gameObject = GameObject.Find(obj);
        Vector3 screenPosition = new Vector3();
        if (gameObject != null)
        {
            screenPosition = gameObject.transform.position;
        }
        else
        {
            screenPosition = Vector3.zero;
        }
        HpIndicatorManager.instance.PlayHPChange(screenPosition, damage.ToString(), (HpIndicatorManager.ColorStyle)colorStyle);
    }
    #endregion
}
