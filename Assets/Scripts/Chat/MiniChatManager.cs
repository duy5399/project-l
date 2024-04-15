using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MainChatManager;

public class MiniChatManager : MonoBehaviour
{
    public static MiniChatManager instance { get; private set; }

    [SerializeField] private TextMeshProUGUI chatViewText;
    [SerializeField] private Queue<string> displayingMessages;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        displayingMessages = new Queue<string>();
        chatViewText = transform.GetChild(0).GetComponent<ScrollRect>().content.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick_MiniChat);
    }
    private void OnDisable()
    {
        this.GetComponent<Button>().onClick.RemoveListener(OnClick_MiniChat);
    }

    public void DisplayMsg(string chatInfo)
    {
        ChatInfoJSON chatInfoJSON = JsonConvert.DeserializeObject<ChatInfoJSON>(chatInfo);
        string msg = "";
        switch (chatInfoJSON.chatChannel)
        {
            case ChatChannels.World:
                msg = "<color=#819de1><Th.Giới></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
                break;
            case ChatChannels.Private:
                msg = "<color=#7b9de2><Ch.Riêng></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
                break;
            case ChatChannels.Guild:
                msg = "<color=#90c333><Công Hội></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
                break;
            //case ChatChannels.Guild:
            //    msg = "<color=#90c333><Th.Giới></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
            //    break;
            //case ChatChannels.Recruit:
            //    msg = "<color=#b18383><Th.Giới></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
            //    break;
            //case ChatChannels.System:
            //    msg = "<color=#ca98b1><Th.Giới></color> <color=#72e2da>" + chatInfoJSON.nickname + ":</color> " + chatInfoJSON.msg;
            //    break;
        }
        if (displayingMessages.Count == 10)
        {
            string msgLine0 = displayingMessages.Dequeue();
            if (chatViewText.text.Contains(msgLine0))
            {
                chatViewText.text.Remove(0, msgLine0.Length-1);
            }
        }
        chatViewText.text += "\n" + msg;
    }

    private void OnClick_MiniChat()
    {
        MainChatManager.instance.gameObject.SetActive(true);
    }
}
