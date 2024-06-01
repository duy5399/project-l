using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkills : MonoBehaviour
{
    public List<EquipSkillSlot> skillLstBtn;

    private void Awake()
    {

    }

    void Start()
    {
            
    }

    void Update()
    {
        
    }

    public void Init()
    {
        skillLstBtn = new List<EquipSkillSlot>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            EquipSkillSlot equipSkillSlot = transform.GetChild(i).GetComponent<EquipSkillSlot>();
            equipSkillSlot.Init();
            skillLstBtn.Add(equipSkillSlot);
            transform.GetChild(i).GetComponent<EquipSkillSlot>().index = i;
        }
    }
}
