using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    public static RegisterManager instance { get; private set; }
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TMP_InputField confirmPasswordInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private Button registerButton;
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
        confirmPasswordInputField = transform.GetChild(2).GetComponent<TMP_InputField>();
        emailInputField = transform.GetChild(3).GetComponent<TMP_InputField>();
        registerButton = transform.GetChild(4).GetComponent<Button>();
        alertText = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        usernameInputField.text = string.Empty;
        passwordInputField.text = string.Empty;
        confirmPasswordInputField.text = string.Empty;
        emailInputField.text = string.Empty;
        alertText.text = string.Empty;
        registerButton.onClick.AddListener(OnClick_Register);
    }

    private void OnDisable()
    {
        usernameInputField.text = string.Empty;
        passwordInputField.text = string.Empty;
        confirmPasswordInputField.text = string.Empty;
        emailInputField.text = string.Empty;
        alertText.text = string.Empty;
        registerButton.onClick.RemoveListener(OnClick_Register);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void OnClick_Register()
    {
        SocketIO.instance.registerSocketIO.Emit_Register(usernameInputField.text, passwordInputField.text, confirmPasswordInputField.text, emailInputField.text);
    }
}

[Serializable]
public class RegisterForm
{
    public string username;
    public string password;
    public string confirmPassword;
    public string email;

    public RegisterForm(string username, string password, string confirmPassword, string email)
    {
        this.username = username;
        this.password = password;
        this.confirmPassword = confirmPassword;
        this.email = email;
    }
}
