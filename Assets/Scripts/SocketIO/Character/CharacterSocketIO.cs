using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CharacterSocketIO
{
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
        GameManager.instance.joystick.SetActive(true);
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
    #endregion
}
