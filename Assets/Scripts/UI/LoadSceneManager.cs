<<<<<<< HEAD
using System;
=======
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI progressText;

    private void Awake()
    {
        progressSlider = GetComponentInChildren<Slider>();
        progressText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        progressSlider.value = 0;
        progressText.text = "0%";
    }

    private void OnDisable()
    {
        progressSlider.value = 0;
        progressText.text = "0%";
    }

<<<<<<< HEAD
    public void LoadScene(string sceneName, Action func = null)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName, func));
    }
    IEnumerator LoadSceneAsync(string sceneName, Action func = null)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
=======
    public void LoadScene(int sceneLevel)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneLevel));
    }
    IEnumerator LoadSceneAsync(int sceneLevel)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneLevel);
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            progressSlider.value = progressValue;
            int progressValue1 = (int)progressValue * 100;
            progressText.text = progressValue1.ToString() + "%";
            yield return null;
        }
<<<<<<< HEAD
        if (func != null)
        {
            func();
        }
=======
>>>>>>> fe0eb62cff20252f9182d96088b832c039117485
        this.gameObject.SetActive(false);
    }
}
