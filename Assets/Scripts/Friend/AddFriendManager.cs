using AYellowpaper.SerializedCollections;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddFriendManager : MonoBehaviour
{
    public static AddFriendManager instance { get; private set; }

    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private Button findButon;
    [SerializeField] private Button closeButton;
    [SerializeField] private ScrollRect searchFriendListScrollRect;
    [SerializedDictionary("nickname","obj")]
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
        nicknameInputField = transform.GetChild(0).GetComponent<TMP_InputField>();
        findButon = transform.GetChild(1).GetComponent<Button>();
        closeButton = transform.GetChild(4).GetComponent<Button>();
        searchFriendListScrollRect = GetComponentInChildren<ScrollRect>();
        displayList = new List<GameObject>();
    }

    private void OnEnable()
    {
        nicknameInputField.text = string.Empty;
        findButon.onClick.AddListener(FindFriend);
        closeButton.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
        });
    }
    private void OnDisable()
    {
        nicknameInputField.text = string.Empty;
        findButon.onClick.RemoveListener(FindFriend);
        closeButton.onClick.RemoveAllListeners();
        foreach (GameObject go in displayList)
        {
            go.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FindFriend()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.friendSocketIO.Emit_FindFriend(nicknameInputField.text);
    }

    public void DisplaySearchFriendInfo(string searchFriendListArray)
    {
        FriendInfoJSON[] searchFriendListJSON = JsonConvert.DeserializeObject<FriendInfoJSON[]>(searchFriendListArray);
        int count = 0;
        for (int i = 0; i < searchFriendListJSON.Length; i++)
        {
            GameObject friendObj;
            if (i < displayList.Count)
            {
                friendObj = displayList[i];
                friendObj.SetActive(true);
            }
            else
            {
                friendObj = Instantiate(Resources.Load<GameObject>("Prefab/Friend/FriendInfo_AddFriend"));
                friendObj.transform.SetParent(searchFriendListScrollRect.content);
                friendObj.transform.localScale = Vector3.one;
                displayList.Add(friendObj);
            }
            FriendInfo_AddFriend friendInfoManager = friendObj.GetComponent<FriendInfo_AddFriend>();
            friendInfoManager.friendInfoJSON = searchFriendListJSON[i];
            friendInfoManager.nicknameText.text = searchFriendListJSON[i].nickname;
            friendInfoManager.levelText.text = searchFriendListJSON[i].level;
            friendInfoManager.borderImage.sprite = Resources.Load<Sprite>("Image/BorderProfile/" + searchFriendListJSON[i].borderProfile);
            friendInfoManager.profileImage.sprite = Resources.Load<Sprite>("Image/ProfileImage/" + searchFriendListJSON[i].profileImg);
            count++;
        }
        for (int i = count; i < displayList.Count; i++)
        {
            displayList[i].SetActive(false);
        }
    }

    public void AddFriendSuccess(string nickname)
    {
        displayList.FirstOrDefault(x => x.GetComponent<FriendInfo_AddFriend>().friendInfoJSON.nickname == nickname).SetActive(false);
    }
}
