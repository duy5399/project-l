using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MainChatManager;
using UnityEngine.UI;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class FriendListManager : MonoBehaviour
{
    public static FriendListManager instance { get; private set; }

    [SerializeField] private TMP_InputField nicknameInputFriend;
    [SerializeField] private Button searchFriendButton;
    [SerializeField] private ScrollRect friendListScrollRect;
    [SerializeField] private Button closeButton;
    [SerializeField] private List<GameObject> displayList;

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
        nicknameInputFriend = transform.GetChild(0).GetComponent<TMP_InputField>();
        searchFriendButton = transform.GetChild(1).GetComponent<Button>();
        friendListScrollRect = transform.GetChild(2).GetComponent< ScrollRect>();
        closeButton = transform.GetChild(6).GetComponent<Button>();
    }

    private void OnEnable()
    {
        nicknameInputFriend.text = string.Empty;
        searchFriendButton.onClick.AddListener(OnClick_SearchFriend);
        closeButton.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        nicknameInputFriend.text = string.Empty;
        searchFriendButton.onClick.RemoveListener(OnClick_SearchFriend);
        closeButton.onClick.RemoveAllListeners();
    }

    void Start()
    {
        //GetFriendList();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetFriendList()
    {
        SocketIO.instance.friendSocketIO.Emit_GetFriendList();
    }

    void OnClick_SearchFriend()
    {
        displayList.ForEach(x =>
        {
            if (x.GetComponent<FriendInfo_Friend>().friendInfoJSON.nickname.Contains(nicknameInputFriend.text))   
            {
                x.SetActive(true);
            }
            else
            {
                x.SetActive(false);
            }
        });
    }

    public void DisplayFriendList(string friendList)
    {
        Debug.Log("DisplayFriendList success: " + friendList);
        FriendInfoJSON[] friendListJSON = JsonConvert.DeserializeObject<FriendInfoJSON[]>(friendList);
        foreach (var friendInfoJSON in friendListJSON)
        {
            NewFriendInfo(friendInfoJSON);
        }
    }

    public void NewFriendInfo(FriendInfoJSON friendInfoJSON)
    {
        GameObject friendObj = Instantiate(Resources.Load<GameObject>("prefab/friend/FriendInfo_Friend"));
        FriendInfo_Friend friendInfoManager = friendObj.GetComponent<FriendInfo_Friend>();
        friendInfoManager.friendInfoJSON = friendInfoJSON;
        friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("image/borderProfile/" + friendInfoJSON.borderProfile);
        friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("image/profileImage/" + friendInfoJSON.profileImg);
        friendInfoManager.nicknameText.text = friendInfoJSON.nickname;
        friendInfoManager.levelText.text = friendInfoJSON.level;
        friendInfoManager.stateOnlineText.text = friendInfoJSON.isOnline == true ? "#Online" : "#Offline";
        friendInfoManager.stateOnlineText.color = friendInfoJSON.isOnline == true ? Color.green : Color.gray;
        friendObj.transform.SetParent(friendListScrollRect.content);
        friendObj.transform.localScale = Vector3.one;
        displayList.Add(friendObj);
    }
}
