using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChEffect : MonoBehaviour
{
    [SerializeField] private ChBase chBase;
    public SerializedDictionary<string, List<GameObject>> effectLst;

    private void Awake()
    {
        chBase = GetComponent<ChBase>();
        effectLst = new SerializedDictionary<string, List<GameObject>>();
    }

    public GameObject GetEffect(AnimEffect animEffect)
    {
        if (effectLst.ContainsKey(animEffect.effectName))
        {
            GameObject effectObj0 = effectLst[animEffect.effectName].FirstOrDefault(x => x.activeSelf == false);
            if (effectObj0)
            {
                return effectObj0;
            }
        }
        GameObject effectObj = Instantiate(Resources.Load<GameObject>(animEffect.effectPath));
        effectObj.name = animEffect.effectName;
        if (!effectLst.ContainsKey(animEffect.effectName))
        {
            effectLst.Add(animEffect.effectName, new List<GameObject>());
        }
        effectLst[animEffect.effectName].Add(effectObj);
        return effectObj;
    }
}
