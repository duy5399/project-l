using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MoveControllerIO
{
    #region On (lắng nghe sự kiện)
    public void MoveControllerIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("character_move_success", (characterData) => {
            GameManager.instance.characterManager.CharacterMove(characterData);
        });

        SocketIO.instance.socketManager.Socket.On<string>("character_rotate_success", (characterData) => {
            GameManager.instance.characterManager.CharacterRotate(characterData);
        });

        SocketIO.instance.socketManager.Socket.On<string>("set-character-position", (_characterData) => {
            Debug.Log("set-character-position: " + _characterData);
            BaseInfo characterData = JsonConvert.DeserializeObject<BaseInfo>(_characterData);
            GameManager.instance.characterManager.myCharacter.transform.position = new Vector3(characterData.data_position[0], characterData.data_position[1], characterData.data_position[2]);
        });

        SocketIO.instance.socketManager.Socket.On<string>("monster_move_success", (monsterInfo) => {
            //Debug.Log("monster_move_success" + monsterInfo);
            GameManager.instance.monsterManager.MonsterMove(monsterInfo);
        });

        SocketIO.instance.socketManager.Socket.On<string>("monster_rotate_success", (monsterInfo) => {
            //Debug.Log("monster_move_success" + monsterInfo);
            GameManager.instance.monsterManager.MonsterRotate(monsterInfo);
        });
    }

    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_CharacterMove(Vector3 position)
    {
        SocketIO.instance.socketManager.Socket.Emit("character_move", new float[] { position.x, position.y, position.z });
    }

    public void Emit_CharacterRotate(Quaternion rotation)
    {
        SocketIO.instance.socketManager.Socket.Emit("character_rotate", new float[] { rotation.x, rotation.y, rotation.z, rotation.w });
    }
    #endregion
}
