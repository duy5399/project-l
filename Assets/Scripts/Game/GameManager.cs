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
    public GameObject ui_loading;
    public GameObject joystick;
    public GameObject ui_feature;
    public GameObject ui_currentState;

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
        GameObject ui_loadingPath = Resources.Load<GameObject>("prefab/ui/Canvas - UILoading");
        ui_loading = Instantiate(ui_loadingPath);
        //
        GameObject ui_featurePath = Resources.Load<GameObject>("prefab/ui/Canvas - UI Feature");
        ui_feature = Instantiate(ui_featurePath);
        ui_feature.SetActive(false);
        //
        GameObject ui_currentStatePath = Resources.Load<GameObject>("prefab/ui/Canvas - UI CurrentState");
        ui_currentState = Instantiate(ui_currentStatePath);

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

    public void RepeatEvery(float delay, float interval,  Action func)
    {

    }
}
