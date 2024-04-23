using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using static HpIndicatorManager;

public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI contentTxt;

    private void Awake()
    {
        contentTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform, Vector3.up);
    }

    public void ShowText(string content, ColorStyle colorStyle)
    {
        contentTxt.text = content;
        switch (colorStyle)
        {
            case ColorStyle.AttackDamage:
                contentTxt.color = new Color32(228, 228, 228, 255);
                break;
            case ColorStyle.CriticalDamage:
                contentTxt.color = new Color32(244, 200, 95, 255);
                break;
            case ColorStyle.Heal:
                contentTxt.color = new Color32(102, 204, 70, 255);
                break;
            case ColorStyle.TakeDamage:
                contentTxt.color = new Color32(224, 112, 125, 255);
                break;
        }
        contentTxt.DOFade(1f, 0f);
        transform.DOMoveY(this.transform.position.y + 2, 1f);
        contentTxt.DOFade(0, 2f).OnComplete(() => this.gameObject.SetActive(false));
    }
}
