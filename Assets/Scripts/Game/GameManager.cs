using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject mainCamera;
    public GameObject panelUILoading;
    public GameObject joystick;

    public CharacterManager characterManager;

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
        GameObject mainCameraPath = Resources.Load<GameObject>("prefab/camera/Main Camera");
        mainCamera = Instantiate(mainCameraPath);
        //joystick
        GameObject joystickPath = Resources.Load<GameObject>("prefab/ui/Canvas - Joystick");
        joystick = Instantiate(joystickPath);
        joystick.SetActive(false);
        //
        GameObject panelUILoadingPath = Resources.Load<GameObject>("prefab/ui/Canvas - UILoading");
        panelUILoading = Instantiate(panelUILoadingPath);

        characterManager = this.AddComponent<CharacterManager>();
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        
    }

    public IEnumerator _WaitFor(float delay, Action func)
    {
        yield return new WaitForSeconds(delay);
        func();
    }
}
