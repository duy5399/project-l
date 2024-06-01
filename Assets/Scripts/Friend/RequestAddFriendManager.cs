using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RequestAddFriendManager : MonoBehaviour
{
    public static RequestAddFriendManager instance { get; private set; }

    [SerializeField] private ScrollRect requestListScrollRect;
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
        requestListScrollRect = transform.GetChild(1).GetComponent<ScrollRect>();
        closeButton = transform.GetChild(2).GetComponent<Button>();
        displayList = new List<GameObject>();
    }

    private void OnEnable()
    {
        closeButton.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }
    void Start()
    {
        //GetRequestAddFriendList();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetRequestAddFriendList()
    {
        SocketIO.instance.friendSocketIO.Emit_GetRequestAddFriendList();
    }

    public void DisplayRequestAddFriendList(string requestList)
    {
        Debug.Log("DisplayRequestAddFriendList success: " + requestList);
        FriendInfoJSON[] friendListJSON = JsonConvert.DeserializeObject<FriendInfoJSON[]>(requestList);
        foreach (var friendInfoJSON in friendListJSON)
        {
            NewRequestAddFriend(friendInfoJSON);
        }
    }

    public void NewRequestAddFriend(FriendInfoJSON infoRequesterJSON)
    {
        GameObject requestObj = Instantiate(Resources.Load<GameObject>("prefab/friend/FriendInfo_RequestAddFriend"));
        FriendInfo_RequestAddFriend friendInfoManager = requestObj.GetComponent<FriendInfo_RequestAddFriend>();
        friendInfoManager.friendInfoJSON = infoRequesterJSON;
        friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("image/borderProfile/" + infoRequesterJSON.borderProfile);
        friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("image/profileImage/" + infoRequesterJSON.profileImg);
        friendInfoManager.nicknameText.text = infoRequesterJSON.nickname;
        friendInfoManager.levelText.text = infoRequesterJSON.level;
        requestObj.transform.SetParent(requestListScrollRect.content);
        requestObj.transform.localScale = Vector3.one;
        displayList.Add(requestObj);
    }

    public void AcceptFriendSuccess(string uid)
    {
        FriendInfo_RequestAddFriend friendInfo = displayList.FirstOrDefault(x => x.GetComponent<FriendInfo_RequestAddFriend>().friendInfoJSON.uid == uid).GetComponent<FriendInfo_RequestAddFriend>();
        FriendListManager.instance.NewFriendInfo(friendInfo.friendInfoJSON);
        friendInfo.gameObject.SetActive(false);
    }

    public void DeclineFriendSuccess(string uid)
    {
        displayList.FirstOrDefault(x => x.GetComponent<FriendInfo_RequestAddFriend>().friendInfoJSON.uid == uid && x.activeSelf ==true).SetActive(false);
    }
}
