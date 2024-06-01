using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainChatManager;

[Serializable]
public class ChatInfoJSON
{
    public string uid;
    public string nickname;
    public string level;
    public string profileImg;
    public string borderProfile;
    public string borderChat;
    public ChatChannels chatChannel;
    public string msg;
}
