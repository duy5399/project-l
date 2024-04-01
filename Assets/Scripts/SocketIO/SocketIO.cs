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

    public LoginSocketIO loginSocketIO
    {
        get { return _loginSocketIO; }
    }
    public RegisterSocketIO registerSocketIO
    {
        get { return _registerSocketIO; }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
