using BestHTTP.SocketIO3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UIElements;
=======
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485

public class SocketIO : MonoBehaviour
{
    public static SocketIO instance { get ; private set; }
    public SocketManager socketManager { get; private set; }

    [SerializeField] private LoginSocketIO _loginSocketIO;
    [SerializeField] private RegisterSocketIO _registerSocketIO;
<<<<<<< HEAD
    [SerializeField] private CreateCharacterSocketIO _createCharacterSocketIO;
    [SerializeField] private CharacterSocketIO _characterSocketIO;
    [SerializeField] private ChatSocketIO _chatSocketIO;
    [SerializeField] private FriendSocketIO _friendSocketIO;
    [SerializeField] private SceneSocketIO _sceneSocketIO;
    [SerializeField] private SkillSocketIO _skillSocketIO;
    [SerializeField] private UISocketIO _uiSocketIO;
    [SerializeField] private CurrentStateSocketIO _currentStateSocketIO;
=======
    [SerializeField] private CharacterSocketIO _characterSocketIO;
    [SerializeField] private ChatSocketIO _chatSocketIO;
    [SerializeField] private FriendSocketIO _friendSocketIO;
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485

    public LoginSocketIO loginSocketIO
    {
        get { return _loginSocketIO; }
    }
    public RegisterSocketIO registerSocketIO
    {
        get { return _registerSocketIO; }
    }
<<<<<<< HEAD
    public CreateCharacterSocketIO createCharacterSocketIO
    {
        get { return _createCharacterSocketIO; }
    }
=======
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
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
<<<<<<< HEAD
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
=======
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485

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
<<<<<<< HEAD
        _createCharacterSocketIO = new CreateCharacterSocketIO();
        _characterSocketIO = new CharacterSocketIO();
        _chatSocketIO = new ChatSocketIO();
        _friendSocketIO = new FriendSocketIO();
        _sceneSocketIO = new SceneSocketIO();
        _skillSocketIO = new SkillSocketIO();
        _currentStateSocketIO = new CurrentStateSocketIO();
        _uiSocketIO = new UISocketIO();
=======
        _characterSocketIO = new CharacterSocketIO();
        _chatSocketIO = new ChatSocketIO();
        _friendSocketIO = new FriendSocketIO();

>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
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
<<<<<<< HEAD
        _createCharacterSocketIO.CreateCharacterSocketIOStart();
        _characterSocketIO.CharacterSocketIOStart();
        _chatSocketIO.ChatSocketIOStart();
        _friendSocketIO.FriendSocketIOStart();
        _sceneSocketIO.SceneSocketIOStart();
        _skillSocketIO.SkillSocketIOStart();
        _currentStateSocketIO.CurrentStateSocketIOStart();
        _uiSocketIO.UISocketIOStart();
=======
        _characterSocketIO.CharacterSocketIOStart();
        _chatSocketIO.ChatSocketIOStart();
        _friendSocketIO.FriendSocketIOStart();
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
