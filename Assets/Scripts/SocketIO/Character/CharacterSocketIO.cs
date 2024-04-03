using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSocketIO
{
    public void CharacterSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("create-character-success", (success) => {
            On_CreateCharacterSuccess(success);
        });
        SocketIO.instance.socketManager.Socket.On<string>("create-character-fail", (error) => {
            On_CreateCharacterError(error);
        });
    }

    private void On_CreateCharacterSuccess(string success)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        CharacterManager.instance.alertText.text = success;
        CharacterManager.instance.alertText.color = Color.green;
        UIManager.instance.loadSceneManager.LoadScene(2);
    }

    private void On_CreateCharacterError(string error)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        CharacterManager.instance.alertText.text = error;
        CharacterManager.instance.alertText.color = Color.red;
    }

    #region Emit (gửi sự kiện)
    public void Emit_CreateCharacter(string nickname)
    {
        Debug.Log(nickname);
        SocketIO.instance.socketManager.Socket.Emit("request-create-character", nickname);
    }
    #endregion
}
