<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
using UnityEngine;

[Serializable]
public class CharacterSocketIO
{
<<<<<<< HEAD
    public List<GameObject> playerListInLocation;

    #region On (lắng nghe sự kiện)
    public void CharacterSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("my-character-connected", (characterData) => {
            On_MyCharacterConnected(characterData);
        });
        SocketIO.instance.socketManager.Socket.On<string>("other-player-connected", (characterData) => {
            On_OtherPlayerConnected(characterData);
        });
        SocketIO.instance.socketManager.Socket.On<string>("character-move-success", (characterData) => {
            On_CharacterMove(characterData);
        });
        SocketIO.instance.socketManager.Socket.On<string>("character-rotate-success", (characterData) => {
            On_CharacterRotate(characterData);
        });
        SocketIO.instance.socketManager.Socket.On<string, string, float, bool>("character-trig-anim-success", (characterData, animName, animSpeed, force) => {
            Debug.Log("character-trig-anim-success: " + animName);
            On_CharacterTrigAnim(characterData,animName, animSpeed, force);
        });
    }

    public void On_MyCharacterConnected(string characterData)
    {
        Debug.Log(characterData);
        GameObject chObj = GameManager.instance.characterManager.InitCharacter(characterData);
        GameManager.instance.characterManager.myCharacter = chObj;
        ChBase chBase = chObj.GetComponent<ChBase>();
        chBase.isLocalPlayer = true;
        chBase.category = ChBase.Category.Player;
        chBase.chMove.joystick = GameManager.instance.joystick.GetComponent<VirtualController>().joystick.GetComponent<FixedJoystick>();
    }

    public void On_OtherPlayerConnected(string characterData)
    {
        Debug.Log(characterData);
        CharacterDataJSON characterDataJSON = JsonConvert.DeserializeObject<CharacterDataJSON>(characterData);
        if (GameManager.instance.characterManager.otherCharacter.FirstOrDefault(x => x.name == characterDataJSON.nickname)){
            return;
        }
        GameObject chObj = GameManager.instance.characterManager.InitCharacter(characterData);
        GameManager.instance.characterManager.otherCharacter.Add(chObj);
        ChBase chBase = chObj.GetComponent<ChBase>();
        chBase.isLocalPlayer = false;
        chBase.category = ChBase.Category.Player;
    }

    public void On_CharacterMove(string characterData)
    {
        GameManager.instance.characterManager.CharacterMove(characterData);
    }

    public void On_CharacterRotate(string characterData)
    {
        GameManager.instance.characterManager.CharacterRotate(characterData);
    }

    public void On_CharacterTrigAnim(string characterData, string animName, float animSpeed, bool force)
    {
        GameManager.instance.characterManager.CharacterTrigAnim(characterData, animName, animSpeed, force);
    }

    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_GetOtherCharacterInMap()
    {
        SocketIO.instance.socketManager.Socket.Emit("get-other-character-in-map");
    }
    public void Emit_CharacterMove(Vector3 position)
    {
        SocketIO.instance.socketManager.Socket.Emit("character-move", new float[] { position.x, position.y, position.z });
    }
    public void Emit_CharacterRotate(Vector3 rotation)
    {
        SocketIO.instance.socketManager.Socket.Emit("character-rotate", new float[] { rotation.x, rotation.y, rotation.z });
    }
    public void Emit_CharacterTrigAnim(string animName, float animSpeed = 1f, bool force = false)
    {
        SocketIO.instance.socketManager.Socket.Emit("character-trig-anim", animName, animSpeed, force);
    }

    //
    public void Emit_TriggerNormalAttack()
    {
        SocketIO.instance.socketManager.Socket.Emit("trigger-normal-attack");
=======
    #region On (lắng nghe sự kiện)
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
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_CreateCharacter(string nickname)
    {
        Debug.Log(nickname);
        SocketIO.instance.socketManager.Socket.Emit("request-create-character", nickname);
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
    }
    #endregion
}
