using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SceneSocketIO
{
    #region On (lắng nghe sự kiện)
    public void SceneSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string, string>("load_scene_success", (_mapInfo, _otherCharacterList) => {
            Debug.Log(_mapInfo);
            MapInfo mapInfo = JsonConvert.DeserializeObject<MapInfo>(_mapInfo);
            MapManager.instance.LoadMap(mapInfo.scene_name, () => {
                GameManager.instance.characterManager.ClearOtherCharacter();
                //SocketIO.instance.characterSocketIO.Emit_GetOtherCharacterInMap();
                for(int i =0; i < mapInfo.waypoints.Count(); i++)
                {
                    Debug.Log("waypointsList: " + mapInfo.waypoints[i]);
                    MapManager.instance.InitWaypoint(mapInfo.waypoints[i]);
                }
                for (int i = 0; i < mapInfo.monsters.Count(); i++)
                {
                    Debug.Log("monsterList: " + mapInfo.monsters[i]);
                    GameManager.instance.monsterManager.InitMonster(mapInfo.monsters[i]);
                }
                CharacterInfo[] characterList = JsonConvert.DeserializeObject<CharacterInfo[]>(_otherCharacterList);
                for (int i = 0; i < characterList.Length; i++)
                {
                    if (GameManager.instance.characterManager.otherCharacter.FirstOrDefault(x => x.name == characterList[i].nickname + "_" + characterList[i].uid))
                    {
                        continue;
                    }
                    GameObject chObj = GameManager.instance.characterManager.SpawnCharacter(characterList[i]);
                }
            });
        });

        SocketIO.instance.socketManager.Socket.On<string>("load-scene-fail", (error) => {
            Debug.Log(error);
        });
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_GoToMap(string map_id)
    {
        SocketIO.instance.socketManager.Socket.Emit("go-to-map", map_id);
    }
    #endregion
}
