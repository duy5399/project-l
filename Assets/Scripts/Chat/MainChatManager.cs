using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class MainChatManager : MonoBehaviour
{
    public static MainChatManager instance { get; private set; }

    public enum ChatChannels
    {
        None = 0,
        World = 1,
        Private = 2,
        Guild = 3,
        Party = 4
    }

    [SerializeField] private ChatChannels chatChannel;

    [SerializeField] private Button worldChannelButton;
    [SerializeField] private Button privateChannelButton;
    [SerializeField] private Button guildChannelButton;
    [SerializeField] private Button partyChannelButton;
    [SerializeField] private Button recruitChannelButton;
    [SerializeField] private Button systemChannelButton;

    [SerializeField] private TMP_InputField msgInputField;
    [SerializeField] private Button sendMsgButton;
    [SerializeField] private Image cantChatImage;

    [SerializeField] private ScrollRect chatViewScrollRect;
    [SerializeField] private Transform worldContent;
    [SerializeField] private Transform privateChatList;
    [SerializeField] private Transform privateChatContent;
    [SerializeField] private Transform guildContent;
    [SerializeField] private Transform partyContent;
    [SerializeField] private Transform recruitContent;
    [SerializeField] private Transform systemContent;

    [SerializeField] private string nicknamePrivateChatString;
    [SerializeField] private Dictionary<string, GameObject> privateChatListDict;
    [SerializeField] private Dictionary<string, GameObject> privateContentDict;
    [SerializeField] private Image nicknamePrivateChat;
    [SerializeField] private Button closeButton;

    [SerializeField] private List<Button> selectChannelButton;
    [SerializeField] private List<Transform> contentChatList;

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
        chatChannel = ChatChannels.None;
        worldChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        privateChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Button>();
        guildChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Button>();
        partyChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Button>();
        recruitChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetComponent<Button>();
        systemChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(5).GetComponent<Button>();

        selectChannelButton = new List<Button>() { worldChannelButton, privateChannelButton, guildChannelButton, partyChannelButton, recruitChannelButton , systemChannelButton };

        msgInputField = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_InputField>();
        sendMsgButton = transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Button>();
        cantChatImage = transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();

        chatViewScrollRect = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<ScrollRect>();
        worldContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Transform>();
        privateChatList = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Transform>();
        privateChatContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Transform>();
        guildContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Transform>();
        partyContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetComponent<Transform>();
        recruitContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();
        systemContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(6).GetComponent<Transform>();

        contentChatList = new List<Transform>() { worldContent, privateChatList, guildContent, partyContent, recruitContent, systemContent };

        privateChatListDict = new Dictionary<string, GameObject>();
        privateContentDict = new Dictionary<string, GameObject>();
        nicknamePrivateChat = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>();
        closeButton = transform.GetChild(2).GetComponent<Button>();
    }

    private void OnEnable()
    {
        worldChannelButton.onClick.AddListener(OnClick_WorldChannelButton);
        privateChannelButton.onClick.AddListener(OnClick_PrivateChannelButton);
        guildChannelButton.onClick.AddListener(OnClick_GuildChannelButton);
        partyChannelButton.onClick.AddListener(OnClick_PartyChannelButton);
        recruitChannelButton.onClick.AddListener(OnClick_RecruitChannelButton);
        systemChannelButton.onClick.AddListener(OnClick_SystemChannelButton);

        sendMsgButton.onClick.AddListener(OnClick_SendMsg);

        closeButton.onClick.AddListener(OnClick_Close);
        cantChatImage.gameObject.SetActive(false);
        nicknamePrivateChatString = string.Empty;
        worldChannelButton.onClick?.Invoke();
    }

    private void OnDisable()
    {
        worldChannelButton.onClick.RemoveListener(OnClick_WorldChannelButton);
        privateChannelButton.onClick.RemoveListener(OnClick_PrivateChannelButton);
        guildChannelButton.onClick.RemoveListener(OnClick_GuildChannelButton);
        partyChannelButton.onClick.RemoveListener(OnClick_PartyChannelButton);
        recruitChannelButton.onClick.RemoveListener(OnClick_RecruitChannelButton);
        systemChannelButton.onClick.RemoveListener(OnClick_SystemChannelButton);

        sendMsgButton.onClick.RemoveListener(OnClick_SendMsg);

        closeButton.onClick.RemoveListener(OnClick_Close);
        cantChatImage.gameObject.SetActive(false);
        nicknamePrivateChatString = string.Empty;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }



    void OnClick_WorldChannelButton()
    {
        ChangeChannelButton(worldChannelButton);
        ChangeChannelContent(worldContent);
        chatChannel = ChatChannels.World;
        cantChatImage.gameObject.SetActive(false);
        msgInputField.gameObject.SetActive(true);
        sendMsgButton.gameObject.SetActive(true);
    }
    void OnClick_PrivateChannelButton()
    {
        ChangeChannelButton(privateChannelButton);
        ChangeChannelContent(privateChatList);
        chatChannel = ChatChannels.Private;
        cantChatImage.gameObject.SetActive(false);
        msgInputField.gameObject.SetActive(true);
        sendMsgButton.gameObject.SetActive(true);
    }
    void OnClick_GuildChannelButton()
    {
        ChangeChannelButton(guildChannelButton);
        ChangeChannelContent(guildContent);
        chatChannel = ChatChannels.Guild;
        cantChatImage.gameObject.SetActive(false);
        msgInputField.gameObject.SetActive(true);
        sendMsgButton.gameObject.SetActive(true);
    }

    void OnClick_PartyChannelButton()
    {
        ChangeChannelButton(partyChannelButton);
        ChangeChannelContent(partyContent);
        chatChannel = ChatChannels.Party;
        cantChatImage.gameObject.SetActive(false);
        msgInputField.gameObject.SetActive(true);
        sendMsgButton.gameObject.SetActive(true);
    }

    void OnClick_RecruitChannelButton()
    {
        ChangeChannelButton(recruitChannelButton);
        ChangeChannelContent(recruitContent);
        chatChannel = ChatChannels.None;
        msgInputField.gameObject.SetActive(false);
        sendMsgButton.gameObject.SetActive(false);
        cantChatImage.gameObject.SetActive(true);
    }

    void OnClick_SystemChannelButton()
    {
        ChangeChannelButton(systemChannelButton);
        ChangeChannelContent(systemContent);
        chatChannel = ChatChannels.None;
        msgInputField.gameObject.SetActive(false);
        sendMsgButton.gameObject.SetActive(false);
        cantChatImage.gameObject.SetActive(true);
    }


    void OnClick_SendMsg()
    {
        SocketIO.instance.chatSocketIO.Emit_SendMsg(chatChannel, msgInputField.text, nicknamePrivateChatString);
    }

    void OnClick_Close()
    {
        this.gameObject.SetActive(false);
    }

    public void DisplayMsg(string chatInfo, bool isReveice)
    {
        ChatInfoJSON chatInfoJSON = JsonConvert.DeserializeObject<ChatInfoJSON>(chatInfo);
        GameObject newChat = Instantiate(Resources.Load<GameObject>("prefab/chat/" + (isReveice == true ? "OtherChatMessage" : "MyChatMessage")));
        ChatInfoManager chatInfoManager = newChat.GetComponent<ChatInfoManager>();
        chatInfoManager.chatInfoJSON = chatInfoJSON;
        chatInfoManager.borderImage.sprite = Resources.Load<Sprite>("Image/BorderProfile/" + chatInfoJSON.borderProfile);
        chatInfoManager.profileImage.sprite = Resources.Load<Sprite>("Image/ProfileImage/" + chatInfoJSON.profileImg);
        chatInfoManager.nicknameText.text = chatInfoJSON.nickname;
        chatInfoManager.levelText.text = "Lv. " + chatInfoJSON.level;
        chatInfoManager.msgText.text = chatInfoJSON.msg;

        switch (chatInfoJSON.chatChannel)
        {
            case ChatChannels.World:
                newChat.transform.SetParent(worldContent);
                break;
            case ChatChannels.Private:
                if (isReveice)
                {
                    //nếu chưa có người này trong danh sách thì tạo mới và thêm vào dict
                    if (!privateChatListDict.ContainsKey(chatInfoJSON.nickname))
                    {
                        NewPrivateChat(chatInfoJSON);
                    }
                    //nếu chưa có bảng chat riêng cho người này thì tạo mới và thêm vào dict
                    if (!privateContentDict.ContainsKey(chatInfoJSON.nickname))
                    {
                        GameObject newPrivateChatContent = Instantiate(privateChatContent.gameObject, chatViewScrollRect.viewport);
                        privateContentDict.Add(chatInfoJSON.nickname, newPrivateChatContent);
                        contentChatList.Add(newPrivateChatContent.transform);
                        newPrivateChatContent.SetActive(false);
                    }
                    newChat.transform.SetParent(privateContentDict[chatInfoJSON.nickname].transform);
                }
                else
                {
                    newChat.transform.SetParent(chatViewScrollRect.content);
                }                
                break;
            case ChatChannels.Guild:
                newChat.transform.SetParent(guildContent);
                break;
        }
        newChat.transform.localScale = Vector3.one;
    }

    void ChangeChannelButton(Button channelButton)
    {
        selectChannelButton.ForEach((x) =>
        {
            if(x != null && x == channelButton)
            {
                ChangeColorButton(x, new Color(147f / 255f, 170f / 222f, 255f / 230f, 255f / 255f), Color.white);
            }
            else
            {
                ChangeColorButton(x, Color.white, new Color(50f / 255f, 50f / 255f, 50f / 255f, 255f / 255f));
            }
        });
    }

    void ChangeColorButton(Button button, Color color1, Color color2)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color1;
        cb.selectedColor = color1;
        button.colors = cb;
        button.GetComponentInChildren<TextMeshProUGUI>().color = color2;
        nicknamePrivateChat.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        nicknamePrivateChatString = string.Empty;
    }

    void ChangeChannelContent(Transform channelContent)
    {
        contentChatList.ForEach((x) =>
        {
            if (x != null && x == channelContent)
            {
                x.gameObject.SetActive(true);
                chatViewScrollRect.content = (RectTransform)x;
            }
            else
            {
                x.gameObject.SetActive(false);
            }
        });
    }

    public void PrivateChat(string nickname, GameObject infoPrivateChat)
    {
        this.gameObject.SetActive(true);
        privateChannelButton.onClick?.Invoke();
        //nếu chưa có người này trong danh sách thì tạo mới và thêm vào dict
        if (!privateChatListDict.ContainsKey(nickname))
        {
            GameObject newPrivateChat = Instantiate(infoPrivateChat, privateChatList);
            privateChatListDict.Add(nickname, newPrivateChat);
        }
        //nếu chưa có bảng chat riêng cho người này thì tạo mới và thêm vào dict
        if (!privateContentDict.ContainsKey(nickname))
        {
            GameObject newPrivateChatContent = Instantiate(privateChatContent.gameObject, chatViewScrollRect.viewport);
            privateContentDict.Add(nickname, newPrivateChatContent);
            contentChatList.Add(newPrivateChatContent.transform);
        }
        ChangeChannelContent(privateContentDict[nickname].transform);
        nicknamePrivateChatString = nickname;
        nicknamePrivateChat.GetComponentInChildren<TextMeshProUGUI>().text = nickname;
    }

    public void NewPrivateChat(ChatInfoJSON ChatInfoJSON)
    {
        GameObject newPrivateChat = Instantiate(Resources.Load<GameObject>("prefab/friend/FriendInfo_Friend"));
        FriendInfo_Friend friendInfoManager = newPrivateChat.GetComponent<FriendInfo_Friend>();
        friendInfoManager.friendInfoJSON.nickname = ChatInfoJSON.nickname;
        friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("Image/BorderProfile/" + ChatInfoJSON.borderProfile);
        friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("Image/ProfileImage/" + ChatInfoJSON.profileImg);
        friendInfoManager.nicknameText.text = ChatInfoJSON.nickname;
        friendInfoManager.levelText.text = ChatInfoJSON.level;
        newPrivateChat.transform.SetParent(privateChatList);
        newPrivateChat.transform.localScale = Vector3.one;
        privateChatListDict.Add(ChatInfoJSON.nickname, newPrivateChat);
    }
}
