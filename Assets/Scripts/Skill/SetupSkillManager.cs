using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupSkillManager : MonoBehaviour
{
    public List<SlotSetupSkill> skillButtonList;

    private void Awake()
    {
        skillButtonList = new List<SlotSetupSkill>();
        for(int i = 0; i< this.transform.childCount; i++)
        {
            skillButtonList.Add(transform.GetChild(i).GetComponent<SlotSetupSkill>());
            transform.GetChild(i).GetComponent<SlotSetupSkill>().index = i;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
