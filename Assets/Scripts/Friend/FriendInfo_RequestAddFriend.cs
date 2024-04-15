using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfo_RequestAddFriend : FriendInfoManager
{
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button declineButton;

    protected override void Awake()
    {
        base.Awake();
        acceptButton = transform.GetChild(5).GetComponent<Button>();
        declineButton = transform.GetChild(6).GetComponent<Button>();
    }

    private void OnEnable()
    {
        acceptButton.onClick.AddListener(OnClick_AcceptRequest);
        declineButton.onClick.AddListener(OnClick_DeclineRequest);
    }
    private void OnDisable()
    {
        acceptButton.onClick.RemoveListener(OnClick_AcceptRequest);
        declineButton.onClick.RemoveListener(OnClick_DeclineRequest);
    }
    void OnClick_AcceptRequest()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.friendSocketIO.Emit_AcceptRequestAddFriend(friendInfoJSON.nickname);
    }

    void OnClick_DeclineRequest()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.friendSocketIO.Emit_DeclineRequestAddFriend(friendInfoJSON.nickname);
    }
}