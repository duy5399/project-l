using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public static LoginManager instance { get; private set; }
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Button loginButton;
    [SerializeField] private TextMeshProUGUI _alertText;
    public TextMeshProUGUI alertText
    {
        get { return _alertText; }
        set { _alertText = value; }
    }
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
        usernameInputField = transform.GetChild(0).GetComponent<TMP_InputField>();
        passwordInputField = transform.GetChild(1).GetComponent<TMP_InputField>();
        loginButton = transform.GetChild(2).GetComponent<Button>();
        alertText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        usernameInputField.text = string.Empty;
        passwordInputField.text = string.Empty;
        loginButton.onClick.AddListener(OnClick_Login);
    }

    private void OnDisable()
    {
        usernameInputField.text = string.Empty;
        passwordInputField.text = string.Empty;
        loginButton?.onClick.RemoveListener(OnClick_Login);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnClick_Login()
    {
        SocketIO.instance.loginSocketIO.Emit_Login(usernameInputField.text, passwordInputField.text);
    }
}

[Serializable]
public class LoginForm
{
    public string username;
    public string password;

    public LoginForm(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
