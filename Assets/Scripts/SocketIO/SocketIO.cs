using BestHTTP.SocketIO3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketIO : MonoBehaviour
{
    public static SocketIO instance { get ; private set; }
    public SocketManager socketManager { get; private set; }

    [SerializeField] private LoginSocketIO _loginSocketIO;
    [SerializeField] private RegisterSocketIO _registerSocketIO;
    [SerializeField] private CharacterSocketIO _characterSocketIO;
    [SerializeField] private ChatSocketIO _chatSocketIO;
    [SerializeField] private FriendSocketIO _friendSocketIO;

    public LoginSocketIO loginSocketIO
    {
        get { return _loginSocketIO; }
    }
    public RegisterSocketIO registerSocketIO
    {
        get { return _registerSocketIO; }
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
        _characterSocketIO = new CharacterSocketIO();
        _chatSocketIO = new ChatSocketIO();
        _friendSocketIO = new FriendSocketIO();

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
        _characterSocketIO.CharacterSocketIOStart();
        _chatSocketIO.ChatSocketIOStart();
        _friendSocketIO.FriendSocketIOStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
