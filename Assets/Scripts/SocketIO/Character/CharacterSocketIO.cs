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
        //tạo game object của nhân vật
        SocketIO.instance.socketManager.Socket.On<string>("my-character-connected", (_myCharacterData) => {
            CharacterInfo[] myCharacterData = JsonConvert.DeserializeObject<CharacterInfo[]>(_myCharacterData);
            GameObject chObj = GameManager.instance.characterManager.SpawnCharacter(myCharacterData[0], true);
        });

        //danh sách người chơi đã kết nối trong phòng => tạo gameobject
        SocketIO.instance.socketManager.Socket.On<string>("other-player-connected", (otherCharacterList) => {
            CharacterInfo[] characterList = JsonConvert.DeserializeObject<CharacterInfo[]>(otherCharacterList);
            for (int i = 0; i < characterList.Length; i++)
            {
                if (GameManager.instance.characterManager.otherCharacter.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == characterList[i].uid))
                {
                    continue;
                }
                GameObject chObj = GameManager.instance.characterManager.SpawnCharacter(characterList[i]);
            }
        });

        //danh sách người chơi đã ngắt kết nối trong phòng => xóa gameobject
        SocketIO.instance.socketManager.Socket.On<string>("other-character-disconnected", (otherCharacterList) => {
            CharacterInfo[] characterList = JsonConvert.DeserializeObject<CharacterInfo[]>(otherCharacterList);
            GameManager.instance.characterManager.OtherCharacterDisconnected(characterList);
        });
    }

    #endregion

    #region Emit (gửi sự kiện)

    //
    public void Emit_InitStats()
    {
        SocketIO.instance.socketManager.Socket.Emit("init-stats");
    }
    #endregion
}
