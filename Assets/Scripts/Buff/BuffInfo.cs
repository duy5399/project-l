using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffInfo : MonoBehaviour
{
    public Buff buff;
    public Image iconBuffImg;
    public TextMeshProUGUI stackTxt;
    public Image lifetimeImg;

    public int stack;
    public float lifetime;

    private void Awake()
    {
        iconBuffImg = this.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        stackTxt = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        lifetimeImg = this.transform.GetChild(3).GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if(lifetime < 0)
        {
            return;
        }
        lifetime -= Time.fixedDeltaTime;
        lifetimeImg.fillAmount = 1 - (lifetime / buff.buff_duration);
    }
}
