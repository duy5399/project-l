using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance { get; private set; }

    [SerializeField] private MiniChatManager miniChatManager;

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


        //usernameInputField = transform.GetChild(0).GetComponent<TMP_InputField>();
        //passwordInputField = transform.GetChild(1).GetComponent<TMP_InputField>();
        //loginButton = transform.GetChild(2).GetComponent<Button>();
        //alertText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
