using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChatSocketIO
{
    #region On (lắng nghe sự kiện)
    public void ChatSocketIOStart()
    {
        //Gửi tin nhắn thành công
        SocketIO.instance.socketManager.Socket.On<string>("send-msg-success", (chatInfo) => {
            MiniChatManager.instance.DisplayMsg(chatInfo);
            MainChatManager.instance.DisplayMsg(chatInfo, false);
        });
        
        //Gửi tin nhắn thất bại
        SocketIO.instance.socketManager.Socket.On("send-msg-fail", () => {
            Debug.Log("On_SendMsgFail");
        });

        //Nhận tin nhắn thành công
        SocketIO.instance.socketManager.Socket.On<string>("receive-msg-success", (chatInfo) => {
            MiniChatManager.instance.DisplayMsg(chatInfo);
            MainChatManager.instance.DisplayMsg(chatInfo, true);
        });
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_SendMsg(MainChatManager.ChatChannels chatChannel, string msg, string uid)
    {
        SocketIO.instance.socketManager.Socket.Emit("send-msg", chatChannel, msg, uid);
    }
    #endregion
}
