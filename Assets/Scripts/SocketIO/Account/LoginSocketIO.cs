using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoginSocketIO
{
    public void LoginSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("login-success-no-character", (success) => {
            On_LoginSuccessNoCharacter(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("login-success-have-character", (success) => {
            On_LoginSuccessHaveCharacter(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("login-fail", (error) => {
            On_LoginFail(error);
        });
    }

    private void On_LoginSuccessNoCharacter(string success)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        LoginManager.instance.alertText.text = success;
        LoginManager.instance.alertText.color = Color.green;
        UIManager.instance.loadSceneManager.LoadScene(1);
    }

    private void On_LoginSuccessHaveCharacter(string success)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        LoginManager.instance.alertText.text = success;
        LoginManager.instance.alertText.color = Color.green;
        UIManager.instance.loadSceneManager.LoadScene(2);
    }

    private void On_LoginFail(string error)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        LoginManager.instance.alertText.text = error;
        LoginManager.instance.alertText.color = Color.red;
    }

    #region Emit (gửi sự kiện)
    public void Emit_Login(string username, string password)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-login", JsonUtility.ToJson(new LoginForm(username, password)));
    }
    #endregion
}
