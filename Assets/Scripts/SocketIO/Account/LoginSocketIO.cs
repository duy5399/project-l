using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoginSocketIO
{
    public void LoginSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("login-success", (success) => {
            On_LoginSuccess(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("login-fail", (error) => {
            On_LoginFail(error);
        });
    }

    public void Emit_Login(string username, string password)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-login", JsonUtility.ToJson(new LoginForm(username, password)));
    }

    private void On_LoginSuccess(string success)
    {
        LoginManager.instance.alertText.text = success;
        LoginManager.instance.alertText.color = Color.green;
    }

    private void On_LoginFail(string error)
    {
        LoginManager.instance.alertText.text = error;
        LoginManager.instance.alertText.color = Color.red;
    }
}
