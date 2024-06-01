using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfo_AddFriend : FriendInfoManager
{
    [SerializeField] private Button addfriendButton;

    protected override void Awake()
    {
        base.Awake();
        addfriendButton = transform.GetChild(5).GetComponent<Button>();
    }

    private void OnEnable()
    {
        addfriendButton.onClick.RemoveListener(OnClick_AddFriend);
        addfriendButton.onClick.AddListener(OnClick_AddFriend);
    }
    private void OnDisable()
    {
        //addfriendButton.onClick.RemoveListener(OnClick_AddFriend);
    }
    void OnClick_AddFriend()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.friendSocketIO.Emit_RequestAddFriend(friendInfoJSON.uid);
    }
}
