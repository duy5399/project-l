using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainChatManager;

[Serializable]
public class ChatSocketIO
{
    public void ChatSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("receive-msg-success", (success) => {
            On_LoginSuccess(success);
        });
    }

    public void Emit_SendMsg(ChatChannels chatChannel, string msg)
    {
        Debug.Log("Emit_SendMsg: " + chatChannel + msg);
        SocketIO.instance.socketManager.Socket.Emit("request-send-msg", chatChannel, msg);
    }

    private void On_LoginSuccess(string success)
    {
        LoginManager.instance.alertText.text = success;
        LoginManager.instance.alertText.color = Color.green;
    }
}
