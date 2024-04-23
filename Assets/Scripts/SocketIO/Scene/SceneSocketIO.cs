using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneSocketIO
{
    #region On (lắng nghe sự kiện)
    public void SceneSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("load-scene-success", (scene) => {
            On_LoadScene(scene);
        });
    }

    private void On_LoadScene(string scene)
    {
        UIManager.instance.loadSceneManager.LoadScene(scene, () => {
            GameManager.instance.characterManager.otherCharacter.Clear();
            SocketIO.instance.socketManager.Socket.Emit("get-other-character-in-map");
        });
    }
    #endregion
}
