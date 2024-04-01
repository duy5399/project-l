using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class RegisterSocketIO
{
    public void RegisterSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("register-success", (success) => {
            On_RegisterSuccess(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("register-fail", (error) => {
            On_RegisterFail(error);
        });
    }

    public void Emit_Register(string username, string password, string confirmPassword, string email)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-register", JsonUtility.ToJson(new RegisterForm(username, password, confirmPassword, email)));
    }

    private void On_RegisterSuccess(string success)
    {
        RegisterManager.instance.alertText.text = success;
        RegisterManager.instance.alertText.color = Color.green;
    }

    private void On_RegisterFail(string error)
    {
        RegisterManager.instance.alertText.text = error;
        RegisterManager.instance.alertText.color = Color.red;
    }
}
