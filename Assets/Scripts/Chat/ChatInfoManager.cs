using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatInfoManager : MonoBehaviour
{
    [SerializeField] private Image _profileImage;
    [SerializeField] private Image _borderImage;
    [SerializeField] private TextMeshProUGUI _nicknameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _borderChatImage;
    [SerializeField] private TextMeshProUGUI _msgText;

    [SerializeField] private ChatInfoJSON _chatInfoJSON;

    public Image profileImage
    {
        get { return _profileImage; }
        set { _profileImage = value; }
    }
    public Image borderImage
    {
        get { return _borderImage; }
        set { _borderImage = value; }
    }
    public TextMeshProUGUI nicknameText
    {
        get { return _nicknameText; }
        set { _nicknameText = value; }
    }
    public TextMeshProUGUI levelText
    {
        get { return _levelText; }
        set { _levelText = value; }
    }
    public Image borderChatImage
    {
        get { return _borderChatImage; }
        set { _borderChatImage = value; }
    }
    public TextMeshProUGUI msgText
    {
        get { return _msgText; }
        set { _msgText = value; }
    }

    public ChatInfoJSON chatInfoJSON
    {
        get { return _chatInfoJSON; }
        set { _chatInfoJSON = value; }
    }

    private void Awake()
    {
        _borderImage = transform.GetChild(0).GetComponent<Image>();
        _profileImage = transform.GetChild(1).GetComponent<Image>();
        _nicknameText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _levelText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _borderChatImage = transform.GetChild(4).GetComponent<Image>();
        _msgText = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
