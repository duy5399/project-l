using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainChatManager : MonoBehaviour
{
    public enum ChatChannels
    {
        None = 0,
        World = 1,
        Private = 2,
        Guild = 3,
        Recruit = 4,
        System = 5,
    }

    [SerializeField] private ChatChannels chatChannel;

    [SerializeField] private Button worldChannelButton;
    [SerializeField] private Button privateChannelButton;
    [SerializeField] private Button guildChannelButton;
    [SerializeField] private Button recruitChannelButton;
    [SerializeField] private Button systemChannelButton;

    [SerializeField] private TMP_InputField msgInputField;
    [SerializeField] private Button sendMsgButton;

    [SerializeField] private ScrollRect chatViewScrollRect;
    [SerializeField] private Transform worldContent;
    [SerializeField] private Transform privateContent;
    [SerializeField] private Transform guildContent;
    [SerializeField] private Transform recruitContent;
    [SerializeField] private Transform systemContent;

    private void Awake()
    {
        chatChannel = ChatChannels.None;
        worldChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        privateChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Button>();
        guildChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Button>();
        recruitChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Button>();
        systemChannelButton = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetComponent<Button>();

        msgInputField = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_InputField>();
        sendMsgButton = transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Button>();

        chatViewScrollRect = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<ScrollRect>();
        worldContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Transform>();
        privateContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Transform>();
        guildContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Transform>();
        recruitContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Transform>();
        systemContent = transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetComponent<Transform>();
    }

    private void OnEnable()
    {
        sendMsgButton.onClick.AddListener(OnClick_SendMsg);
    }

    private void OnDisable()
    {
        sendMsgButton.onClick.RemoveListener(OnClick_SendMsg);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnClick_SendMsg()
    {
        SocketIO.instance.chatSocketIO.Emit_SendMsg(chatChannel, msgInputField.text);
    }
}
