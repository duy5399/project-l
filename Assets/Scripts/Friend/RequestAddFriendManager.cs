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
<<<<<<< HEAD
        //GetRequestAddFriendList();
=======
        GetRequestAddFriendList();
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD
    public void GetRequestAddFriendList()
=======
    void GetRequestAddFriendList()
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
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
<<<<<<< HEAD
        GameObject requestObj = Instantiate(Resources.Load<GameObject>("prefab/friend/FriendInfo_RequestAddFriend"));
        FriendInfo_RequestAddFriend friendInfoManager = requestObj.GetComponent<FriendInfo_RequestAddFriend>();
        friendInfoManager.friendInfoJSON = infoRequesterJSON;
        friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("image/borderProfile/" + infoRequesterJSON.borderProfile);
        friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("image/profileImage/" + infoRequesterJSON.profileImg);
=======
        GameObject requestObj = Instantiate(Resources.Load<GameObject>("Prefab/Friend/FriendInfo_RequestAddFriend"));
        FriendInfo_RequestAddFriend friendInfoManager = requestObj.GetComponent<FriendInfo_RequestAddFriend>();
        friendInfoManager.friendInfoJSON = infoRequesterJSON;
        friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("Image/BorderProfile/" + infoRequesterJSON.borderProfile);
        friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("Image/ProfileImage/" + infoRequesterJSON.profileImg);
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
        friendInfoManager.nicknameText.text = infoRequesterJSON.nickname;
        friendInfoManager.levelText.text = infoRequesterJSON.level;
        requestObj.transform.SetParent(requestListScrollRect.content);
        requestObj.transform.localScale = Vector3.one;
        displayList.Add(requestObj);
    }

    public void AcceptFriendSuccess(string nickname)
    {
        FriendInfo_RequestAddFriend friendInfo = displayList.FirstOrDefault(x => x.GetComponent<FriendInfo_RequestAddFriend>().friendInfoJSON.nickname == nickname).GetComponent<FriendInfo_RequestAddFriend>();
        FriendListManager.instance.NewFriendInfo(friendInfo.friendInfoJSON);
        friendInfo.gameObject.SetActive(false);
    }

    public void DeclineFriendSuccess(string nickname)
    {
        displayList.FirstOrDefault(x => x.GetComponent<FriendInfo_RequestAddFriend>().friendInfoJSON.nickname == nickname && x.activeSelf ==true).SetActive(false);
    }
}
