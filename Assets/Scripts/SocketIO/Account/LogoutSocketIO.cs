using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LogoutSocketIO
{
    #region On (lắng nghe sự kiện)
    public void LoginSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string>("force-logout-success", (alert) => {
            On_ForceLogoutSuccess(alert);
        });
    }

    private void On_ForceLogoutSuccess(string alert)
    {
        
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_Logout()
    {
        SocketIO.instance.socketManager.Socket.Emit("request-logout");
    }
    #endregion
}
