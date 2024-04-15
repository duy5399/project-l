using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private Transform _loading00Panel;
    [SerializeField] private LoadSceneManager _loadSceneManager;

    public Transform loading01Panel
    {
        get { return _loading00Panel; }
    }

    public LoadSceneManager loadSceneManager
    {
        get { return _loadSceneManager; }
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
        _loading00Panel = transform.GetChild(0);
        _loadSceneManager = GetComponentInChildren<LoadSceneManager>();
        _loadSceneManager.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _loading00Panel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _loading00Panel.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
