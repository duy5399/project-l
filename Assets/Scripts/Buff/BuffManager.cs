using AYellowpaper.SerializedCollections;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance { get; private set; }

    [SerializedDictionary("BuffID", "BuffObj")]
    public SerializedDictionary<string, GameObject> buffLst;
    public Transform content;

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
        buffLst = new SerializedDictionary<string, GameObject>();
        content = this.transform.GetComponent<ScrollRect>().content;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddBuff(string _buff)
    {
        Buff buff = JsonConvert.DeserializeObject<Buff>(_buff);
        GameObject buffObj = null;
        if (buffLst.ContainsKey(buff.buff_id))
        {
            if (!buffLst[buff.buff_id].activeSelf)
            {
                buffObj = buffLst[buff.buff_id];
            }
        }
        else
        {
            buffObj = Instantiate(Resources.Load<GameObject>("prefab/buff/BuffInfo"), content);
            buffLst.Add(buff.buff_id, buffObj);
        }
        if (buffObj == null)
        {
            return;
        }
        buffObj.SetActive(true);
        BuffInfo buffInfo = buffObj.GetComponent<BuffInfo>();
        buffInfo.buff = buff;
        buffInfo.iconBuffImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + buff.buff_icon);
        buffInfo.stackTxt.text = string.Empty;
        buffInfo.stack = 1;
        buffInfo.lifetime = buff.buff_duration;
    }

    public void UpdateBuff(string _buff, int stack, bool isRefresh)
    {
        Buff buff = JsonConvert.DeserializeObject<Buff>(_buff);
        if (!buffLst.ContainsKey(buff.buff_id))
        {
            AddBuff(_buff);
        }
        else
        {
            GameObject buffObj = buffLst[buff.buff_id];
            BuffInfo buffInfo = buffObj.GetComponent<BuffInfo>();
            buffInfo.stackTxt.text = stack == 0 ? string.Empty : stack.ToString();
            if (isRefresh)
            {
                buffInfo.lifetime = buff.buff_duration;
            }
        }
    }

    public void RemoveBuff(string _buff)
    {
        Buff buff = JsonConvert.DeserializeObject<Buff>(_buff);
        if (!buffLst.ContainsKey(buff.buff_id))
        {
            return;
        }
        BuffInfo buffInfo = buffLst[buff.buff_id].GetComponent<BuffInfo>();
        buffInfo.buff = null;
        buffInfo.iconBuffImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + buff.buff_icon);
        buffInfo.stackTxt.text = string.Empty;
        buffInfo.stack = 0;
        buffInfo.lifetime = -1;
        buffLst[buff.buff_id].SetActive(false);
    }
}
