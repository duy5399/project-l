using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfoManager : MonoBehaviour
{
    [SerializeField] protected Image _profileImage;
    [SerializeField] protected Image _borderImage;
    [SerializeField] protected TextMeshProUGUI _nicknameText;
    [SerializeField] protected TextMeshProUGUI _levelText;
    [SerializeField] protected TextMeshProUGUI _stateOnlineText;
    [SerializeField] protected FriendInfoJSON _friendInfoJSON;

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
    public TextMeshProUGUI stateOnlineText
    {
        get { return _stateOnlineText; }
        set { _stateOnlineText = value; }
    }

    public FriendInfoJSON friendInfoJSON
    {
        get { return _friendInfoJSON; }
        set { _friendInfoJSON = value; }
    }

    protected virtual void Awake()
    {
        _borderImage = transform.GetChild(0).GetComponent<Image>();
        _profileImage = transform.GetChild(1).GetComponent<Image>();
        _levelText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _nicknameText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _stateOnlineText = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    void Start()
    {

    }

    void Update()
    {

    }

    void OnClick_PrivateChat()
    {

    }

    void OnClick_Unfriend()
    {

    }
    void OnClick_AddFriend()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.friendSocketIO.Emit_RequestAddFriend(friendInfoJSON.uid);
    }

}
