using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FriendSocketIO
{
    #region On (lắng nghe sự kiện)
    public void FriendSocketIOStart()
    {
        //lấy danh sách bạn bè
        SocketIO.instance.socketManager.Socket.On<string>("get-friend-list-success", (friendList) => {
            On_GetFriendListSuccess(friendList);
        });
        SocketIO.instance.socketManager.Socket.On("get-friend-list-fail", () => {
            On_GetFriendListFail();
        });
        //tìm bạn
        SocketIO.instance.socketManager.Socket.On<string>("find-friend-success", (searchFriendListArray) => {
            On_FindFriendSuccess(searchFriendListArray);
        });
        SocketIO.instance.socketManager.Socket.On("find-friend-fail", () => {
            On_FindFriendFail();
        });
        //gửi lời mời kết bạn
        SocketIO.instance.socketManager.Socket.On<string>("add-friend-success", (nickname) => {
            On_AddFriendSuccess(nickname);
        });
        SocketIO.instance.socketManager.Socket.On("add-friend-fail", () => {
            On_AddFriendFail();
        });
        //người khác gửi lời mời kết bạn 
        SocketIO.instance.socketManager.Socket.On<string>("another-player-sent-add-friend-request", (infoRequester) => {
            On_RequestAddFriend(infoRequester);
        });
        //lấy danh sách chờ kết bạn
        SocketIO.instance.socketManager.Socket.On<string>("get-request-add-friend-list-success", (requestList) => {
            On_GetRequestAddFriendListSuccess(requestList);
        });
        SocketIO.instance.socketManager.Socket.On("get-request-add-friend-list-fail", () => {
            On_GetRequestAddFriendListFail();
        });
        //đồng ý kết bạn
        SocketIO.instance.socketManager.Socket.On<string>("accept-friend-success", (nickname) => {
            On_AcceptFriendSuccess(nickname);
        });
        SocketIO.instance.socketManager.Socket.On("add-friend-fail", () => {
            On_AcceptFriendFail();
        });
        //không đồng ý kết bạn
        SocketIO.instance.socketManager.Socket.On<string>("decline-friend-success", (nickname) => {
            On_DeclineFriendSuccess(nickname);
        });
        SocketIO.instance.socketManager.Socket.On("decline-friend-fail", () => {
            On_DeclineFriendFail();
        });
        //người khác đồng ý kết bạn
        SocketIO.instance.socketManager.Socket.On<string>("another-player-accpet-add-friend", (infoAccept) => {
            On_AnotherPlayerAccpetAddFriend(infoAccept);
        });
    }

    //danh sách bạn bè
    void On_GetFriendListSuccess(string friendList)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        FriendListManager.instance.DisplayFriendList(friendList);
    }
    void On_GetFriendListFail()
    {
        Debug.Log("get-friend-list-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }

    //tìm bạn
    void On_FindFriendSuccess(string searchFriendListArray)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        AddFriendManager.instance.DisplaySearchFriendInfo(searchFriendListArray);
    }
    void On_FindFriendFail()
    {
        Debug.Log("find-friend-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }

    //thêm bạn
    void On_AddFriendSuccess(string nickname)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        AddFriendManager.instance.AddFriendSuccess(nickname);
    }
    void On_AddFriendFail()
    {
        Debug.Log("add-friend-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }

    //người khác gửi lời mời kết bạn 
    void On_RequestAddFriend(string infoRequester)
    {
        FriendInfoJSON infoRequesterJSON = JsonConvert.DeserializeObject<FriendInfoJSON>(infoRequester);
        RequestAddFriendManager.instance.NewRequestAddFriend(infoRequesterJSON);
    }
    //danh sách chờ kết bạn
    void On_GetRequestAddFriendListSuccess(string requestList)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        RequestAddFriendManager.instance.DisplayRequestAddFriendList(requestList);
    }
    void On_GetRequestAddFriendListFail()
    {
        Debug.Log("get-request-add-friend-list-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }

    //đồng ý kết bạn
    void On_AcceptFriendSuccess(string nickname)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        RequestAddFriendManager.instance.AcceptFriendSuccess(nickname);
    }
    void On_AcceptFriendFail()
    {
        Debug.Log("accept-request-add-friend-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }
    //không đồng ý kết bạn
    void On_DeclineFriendSuccess(string nickname)
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
        RequestAddFriendManager.instance.DeclineFriendSuccess(nickname);
    }
    void On_DeclineFriendFail()
    {
        Debug.Log("decline-request-add-friend-fail");
        UIManager.instance.loading01Panel.gameObject.SetActive(false);
    }
    //người khác đồng ý kết bạn
    void On_AnotherPlayerAccpetAddFriend(string infoAccept)
    {
        FriendInfoJSON friendInfoJSON = JsonConvert.DeserializeObject<FriendInfoJSON>(infoAccept);
        FriendListManager.instance.NewFriendInfo(friendInfoJSON);
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_GetFriendList()
    {
        SocketIO.instance.socketManager.Socket.Emit("get-friend-list");
    }
    public void Emit_FindFriend(string nickname)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-find-friend", nickname);
    }
    public void Emit_RequestAddFriend(string nickname)
    {
        SocketIO.instance.socketManager.Socket.Emit("request-add-friend", nickname);
    }
    public void Emit_GetRequestAddFriendList()
    {
        SocketIO.instance.socketManager.Socket.Emit("get-request-add-friend-list");
    }
    public void Emit_AcceptRequestAddFriend(string nickname)
    {
        SocketIO.instance.socketManager.Socket.Emit("accept-request-add-friend", nickname);
    }
    public void Emit_DeclineRequestAddFriend(string nickname)
    {
        SocketIO.instance.socketManager.Socket.Emit("decline-request-add-friend", nickname);
    }
    #endregion
}
