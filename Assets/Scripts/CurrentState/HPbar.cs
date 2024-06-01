using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public static HPbar instance { get; private set; }

    public Image avatarImg;
    public Image jobImg;
    public Slider hpSld;
    public Slider spSld;
    public TextMeshProUGUI lvTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI spTxt;

    public Button chInfoBtn;

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

        avatarImg = this.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        jobImg = this.transform.GetChild(2).GetComponent<Image>();
        hpSld = this.transform.GetChild(3).GetComponent<Slider>();
        spSld = this.transform.GetChild(4).GetComponent<Slider>();
        lvTxt = this.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        hpTxt = this.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        spTxt = this.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
        chInfoBtn = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        chInfoBtn.onClick.AddListener(OnClick_DisplayChInfoDetail);
    }

    private void OnDisable()
    {
        chInfoBtn.onClick.RemoveListener(OnClick_DisplayChInfoDetail);
    }

    void OnClick_DisplayChInfoDetail()
    {
        this.transform.parent.GetChild(2).gameObject.SetActive(true);
    }
}
