using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoManager : MonoBehaviour
{
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillType;
    public TextMeshProUGUI description;
    public TextMeshProUGUI curPoint;
    public Button resetSkillTree;
    public Button reset;
    public Button save;

    public SkillNodeManager skillNodeManager;

    private void Awake()
    {
        skillName = this.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        skillType = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        description = this.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        curPoint = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        resetSkillTree = this.transform.GetChild(4).GetComponent<Button>();
        reset = this.transform.GetChild(5).GetComponent<Button>();
        save = this.transform.GetChild(6).GetComponent<Button>();
    }

    private void OnEnable()
    {
        resetSkillTree.onClick.AddListener(OnClick_ResetSkillTree);
        reset.onClick.AddListener(OnClick_Reset);
        save.onClick.AddListener(OnClick_Save);
    }

    private void OnDisable()
    {
        skillName.text = string.Empty; 
        skillType.text = string.Empty; 
        description.text = string.Empty;
        resetSkillTree.onClick.RemoveListener(OnClick_ResetSkillTree);
        reset.onClick.RemoveListener(OnClick_Reset);
        save.onClick.RemoveListener(OnClick_Save);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnClick_ResetSkillTree()
    {

    }

    void OnClick_Reset()
    {
        SkillsManager.instance.tempPoint = SkillsManager.instance.curPoint;
        foreach(GameObject obj in SkillsManager.instance.skillList)
        {
            SkillNodeManager skillNodeManager = obj.GetComponent<SkillNodeManager>();
            if (skillNodeManager == null)
            {
                continue;
            }
            skillNodeManager.tempLv = skillNodeManager.curLv;
            skillNodeManager.OnClick_DisplayInfo();
        }
    }

    void OnClick_Save()
    {
        List<SkillLearn> skillLearn = new List<SkillLearn>();
        bool checkChange = false;
        foreach (GameObject obj in SkillsManager.instance.skillList)
        {
            SkillNodeManager skillNodeManager = obj.GetComponent<SkillNodeManager>();
            if (skillNodeManager == null || skillNodeManager.curLv == skillNodeManager.tempLv)
            {
                continue;
            }
            checkChange = true;
            SkillLearn x = new SkillLearn(skillNodeManager.skillBaseJSON.skill_id, skillNodeManager.tempLv, -2);
            skillLearn.Add(x);
        }
        if (!checkChange)
        {
            return;
        }
        MySkillsDataJSON newSkills = new MySkillsDataJSON(SkillsManager.instance.tempPoint, skillLearn.ToArray());
        SocketIO.instance.skillSocketIO.Emit_SaveSkills(newSkills);
    }
}
