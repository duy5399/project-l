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
    public GameObject virtualCamera;
    public GameObject ui_loading;
    public GameObject joystick;
    public GameObject ui_feature;
    public GameObject ui_currentState;

    public CharacterManager characterManager;
    public MonsterManager monsterManager;

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
        GameObject virtualCameraPath = Resources.Load<GameObject>("prefab/camera/Virtual Camera");
        virtualCamera = Instantiate(virtualCameraPath);
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
        monsterManager = this.AddComponent<MonsterManager>();
    }

    private void OnEnable()
    {
        
    }
    //public GameObject a; 
    private void Start()
    {
        //Debug.Log(a.transform.forward);
        //Debug.Log(a.transform.rotation);
        //Debug.Log(Vector3.forward);
        //Debug.Log(x(a.transform.rotation, Vector3.forward));
        //Debug.Log(a.transform.rotation * Vector3.forward);
        //a.transform.rotation = new Quaternion(0, 0.08716f, 0, 0.99619f);
    }

    public void WaitFor(float delay, Action func)
    {
        if (func == null)
        {
            return;
        }
        if (delay <= 0)
        {
            func();
        }
        else
        {
            Coroutine coroutine = StartCoroutine(_WaitFor(delay, func));
        }
    }

    IEnumerator _WaitFor(float delay, Action func)
    {
        yield return new WaitForSeconds(delay);
        func();
    }

    public void RepeatEvery(float delay, float interval,  Action func)
    {

    }
}
