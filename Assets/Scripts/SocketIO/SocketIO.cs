using BestHTTP.SocketIO3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SocketIO : MonoBehaviour
{
    public static SocketIO instance { get ; private set; }
    public SocketManager socketManager { get; private set; }

    [SerializeField] private LoginSocketIO _loginSocketIO;
    [SerializeField] private RegisterSocketIO _registerSocketIO;
    [SerializeField] private CreateCharacterSocketIO _createCharacterSocketIO;
    [SerializeField] private CharacterSocketIO _characterSocketIO;
    [SerializeField] private ChatSocketIO _chatSocketIO;
    [SerializeField] private FriendSocketIO _friendSocketIO;
    [SerializeField] private SceneSocketIO _sceneSocketIO;
    [SerializeField] private SkillSocketIO _skillSocketIO;
    [SerializeField] private UISocketIO _uiSocketIO;
    [SerializeField] private CurrentStateSocketIO _currentStateSocketIO;

    public LoginSocketIO loginSocketIO
    {
        get { return _loginSocketIO; }
    }
    public RegisterSocketIO registerSocketIO
    {
        get { return _registerSocketIO; }
    }
    public CreateCharacterSocketIO createCharacterSocketIO
    {
        get { return _createCharacterSocketIO; }
    }
    public CharacterSocketIO characterSocketIO
    {
        get { return _characterSocketIO; }
    }
    public ChatSocketIO chatSocketIO
    {
        get { return _chatSocketIO; }
    }
    public FriendSocketIO friendSocketIO
    {
        get { return _friendSocketIO; }
    }
    public SceneSocketIO sceneSocketIO
    {
        get { return _sceneSocketIO; }
    }

    public SkillSocketIO skillSocketIO
    {
        get { return _skillSocketIO; }
    }
    public CurrentStateSocketIO currentStateSocketIO
    {
        get { return _currentStateSocketIO; }
    }

    public UISocketIO uiSocketIO
    {
        get { return _uiSocketIO; }
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
        _loginSocketIO = new LoginSocketIO();
        _registerSocketIO = new RegisterSocketIO();
        _createCharacterSocketIO = new CreateCharacterSocketIO();
        _characterSocketIO = new CharacterSocketIO();
        _chatSocketIO = new ChatSocketIO();
        _friendSocketIO = new FriendSocketIO();
        _sceneSocketIO = new SceneSocketIO();
        _skillSocketIO = new SkillSocketIO();
        _currentStateSocketIO = new CurrentStateSocketIO();
        _uiSocketIO = new UISocketIO();
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SocketOptions options = new SocketOptions();
        options.Auth = (manager, socket) => new { token = "project-l-123" };
        socketManager = new SocketManager(new Uri("http://localhost:3000"), options);
        socketManager.Socket.On("connection", () => Debug.Log(socketManager.Socket.Id));

        _loginSocketIO.LoginSocketIOStart();
        _registerSocketIO.RegisterSocketIOStart();
        _createCharacterSocketIO.CreateCharacterSocketIOStart();
        _characterSocketIO.CharacterSocketIOStart();
        _chatSocketIO.ChatSocketIOStart();
        _friendSocketIO.FriendSocketIOStart();
        _sceneSocketIO.SceneSocketIOStart();
        _skillSocketIO.SkillSocketIOStart();
        _currentStateSocketIO.CurrentStateSocketIOStart();
        _uiSocketIO.UISocketIOStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
