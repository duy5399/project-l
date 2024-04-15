using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainChatManager;

[Serializable]
public class ChatSocketIO
{
    #region On (lắng nghe sự kiện)
    public void ChatSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On("send-msg-fail", () => {
            On_SendMsgFail();
        });
        SocketIO.instance.socketManager.Socket.On<string>("send-msg-success", (chatInfo) => {
            On_SendMsgSuccess(chatInfo);
        });
        SocketIO.instance.socketManager.Socket.On<string>("receive-msg-success", (chatInfo) => {
            On_ReceiveMsgSuccess(chatInfo);
        });
    }

    private void On_SendMsgFail()
    {
        Debug.Log("On_SendMsgFail");
    }

    private void On_SendMsgSuccess(string chatInfo)
    {
        MiniChatManager.instance.DisplayMsg(chatInfo);
        MainChatManager.instance.DisplayMsg(chatInfo, false);
    }

    private void On_ReceiveMsgSuccess(string chatInfo)
    {
        MiniChatManager.instance.DisplayMsg(chatInfo);
        MainChatManager.instance.DisplayMsg(chatInfo, true);
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_SendMsg(MainChatManager.ChatChannels chatChannel, string msg, string nickname)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-send-msg", chatChannel, msg, nickname);
    }
    #endregion
}
