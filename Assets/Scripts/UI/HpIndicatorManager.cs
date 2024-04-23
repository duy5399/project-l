using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Linq;

public class HpIndicatorManager : MonoBehaviour
{
    public enum ColorStyle
    {
        AttackDamage = 0,
        CriticalDamage = 1,
        Heal = 2,
        TakeDamage = 3
    }

    public static HpIndicatorManager instance { get; private set; }
    public List<GameObject> hpPlayLst;
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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayHPChange(Vector3 position, string content, ColorStyle colorStyle)
    {
        GameObject obj = hpPlayLst.FirstOrDefault(x => x.activeSelf == false);
        if (obj != null)
        {
            obj.SetActive(true);
            obj.transform.position = position;
            obj.GetComponent<FloatingText>().ShowText(content, colorStyle);
        }
        else
        {
            GameObject newObj = Instantiate(Resources.Load<GameObject>("prefab/ui/FloatingText"), position, Quaternion.identity);
            newObj.GetComponent<FloatingText>().ShowText(content, colorStyle);
            hpPlayLst.Add(newObj);
        }
    }
}
