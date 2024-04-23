using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UISocketIO
{
    #region On (lắng nghe sự kiện)
    public void UISocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On("init-ui-feature", () => {
            On_InitUIFeature();
        });
    }
    private void On_InitUIFeature()
    {
        GameManager.instance.joystick.SetActive(true);
        GameManager.instance.ui_feature.SetActive(true);
        GameManager.instance.ui_feature.GetComponentInChildren<FriendListManager>().GetFriendList();
        GameManager.instance.ui_feature.GetComponentInChildren<RequestAddFriendManager>().GetRequestAddFriendList();
        GameManager.instance.ui_feature.GetComponentInChildren<SkillsManager>().GetSkills();
    }
    #endregion
}
