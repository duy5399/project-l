using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager instance { get; private set; }

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
    }

    public void LoadMap(string sceneName, Action func = null)
    {
        StartCoroutine(LoadMapAsync(sceneName, func));
    }

    IEnumerator LoadMapAsync(string sceneName, Action func = null)
    {
        UIManager.instance.loadSceneManager.gameObject.SetActive(true);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            UIManager.instance.loadSceneManager.progressSlider.value = progressValue;
            int progressValue1 = (int)progressValue * 100;
            UIManager.instance.loadSceneManager.progressText.text = progressValue1.ToString() + "%";
            yield return null;
        }
        if (func != null)
        {
            func();
        }
        UIManager.instance.loadSceneManager.gameObject.SetActive(false);
    }

    public void InitWaypoint(Waypoints waypoints)
    {
        GameObject waypoitPrefab = Resources.Load<GameObject>("effect/new_effect/effect/xitong/eff_teleport/eff_Teleport");
        if(waypoitPrefab != null)
        {
            Debug.Log("waypoitPrefab");
        }
        GameObject waypoitObj = Instantiate(waypoitPrefab, new Vector3(waypoints.position[0], waypoints.position[1], waypoints.position[2]), Quaternion.identity);
        waypoitObj.GetComponent<Waypoint>().map_id = waypoints.map_id;
    }
}
