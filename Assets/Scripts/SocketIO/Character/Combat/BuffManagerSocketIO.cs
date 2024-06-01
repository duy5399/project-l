using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuffManagerSocketIO
{
    #region On (lắng nghe sự kiện)
    public void BuffManagerSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("add_buff", (buff) => {
            Debug.Log("add_buff");
            On_AddBuff(buff);
        });
        SocketIO.instance.socketManager.Socket.On<string, int, bool>("update_buff", (buff, stack, isRefresh) => {
            Debug.Log("update_buff");
            On_UpdateBuff(buff, stack, isRefresh);
        });
        SocketIO.instance.socketManager.Socket.On<string>("remove_buff", (buff) => {
            Debug.Log("remove_buff");
            On_RemoveBuff(buff);
        });
    }
    void On_AddBuff(string buff)
    {
        BuffManager.instance.AddBuff(buff);
    }
    void On_UpdateBuff(string buff, int stack, bool isRefresh)
    {
        BuffManager.instance.UpdateBuff(buff, stack, isRefresh);
    }
    void On_RemoveBuff(string buff)
    {
        BuffManager.instance.RemoveBuff(buff);
    }
    #endregion
}
