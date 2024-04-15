using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CreateCharacterSocketIO
{
    #region On (lắng nghe sự kiện)
    public void CreateCharacterSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string, string>("get-job-classes-success", (basicClass, job) => {
            On_GetJobClassesSuccess(basicClass, job);
        });
        SocketIO.instance.socketManager.Socket.On<string>("get-job-classes-fail", (error) => {
            On_GetJobClassesFail(error);
        });
        SocketIO.instance.socketManager.Socket.On<string>("create-character-success", (success) => {
            On_CreateCharacterSuccess(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("create-character-fail", (error) => {
            On_CreateCharacterError(error);
        });
    }

    private void On_GetJobClassesSuccess(string basicClass, string job)
    {
        CreateCharacterManager.instance.LoadJobClasses(basicClass, job);
    }

    private void On_GetJobClassesFail(string error)
    {
        Debug.Log(error);
    }

    private void On_CreateCharacterSuccess(string success)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        CreateCharacterManager.instance.alertText.text = success;
        CreateCharacterManager.instance.alertText.color = Color.green;
    }

    private void On_CreateCharacterError(string error)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        CreateCharacterManager.instance.alertText.text = error;
        CreateCharacterManager.instance.alertText.color = Color.red;
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_GetJobClasses()
    {
        SocketIO.instance.socketManager.Socket.Emit("request-get-job-classes");
    }
    public void Emit_CreateCharacter(string nickname, bool gender, string job)
    {
        Debug.Log(nickname);
        SocketIO.instance.socketManager.Socket.Emit("request-create-character", nickname, gender, job);
    }
    #endregion
}
