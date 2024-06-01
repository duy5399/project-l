using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfo_Friend : FriendInfoManager
{
    [SerializeField] private Button privateChatButton;
    [SerializeField] private Button unfriendButton;

    protected override void Awake()
    {
        base.Awake();
        privateChatButton = transform.GetChild(5).GetComponent<Button>();
        unfriendButton = transform.GetChild(6).GetComponent<Button>();
    }

    private void OnEnable()
    {
        privateChatButton.onClick.AddListener(OnClick_PrivateChat);
        unfriendButton.onClick.AddListener(OnClick_Unfriend);
    }
    private void OnDisable()
    {
        privateChatButton.onClick.RemoveListener(OnClick_PrivateChat);
        unfriendButton.onClick.RemoveListener(OnClick_Unfriend);
    }
    void OnClick_PrivateChat()
    {
        //UIManager.instance.loading01Panel.gameObject.SetActive(true);
        //SocketIO.instance.friendSocketIO.Emit_RequestAddFriend(friendInfoJSON.nickname);
        MainChatManager.instance.PrivateChat(_friendInfoJSON, this.gameObject);
    }

    void OnClick_Unfriend()
    {

    }
}
