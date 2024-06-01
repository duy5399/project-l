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

    public SkillNode skillNodeManager;

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
        save.onClick.AddListener(OnClick_SaveSkills);
    }

    private void OnDisable()
    {
        skillName.text = string.Empty; 
        skillType.text = string.Empty; 
        description.text = string.Empty;
        resetSkillTree.onClick.RemoveListener(OnClick_ResetSkillTree);
        reset.onClick.RemoveListener(OnClick_Reset);
        save.onClick.RemoveListener(OnClick_SaveSkills);
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
        foreach(GameObject obj in SkillsManager.instance.skillNodeLst)
        {
            SkillNode skillNodeManager = obj.GetComponent<SkillNode>();
            if (skillNodeManager == null)
            {
                continue;
            }
            skillNodeManager.tempLv = skillNodeManager.curLv;
            skillNodeManager.OnClick_DisplayInfo();
        }
    }

    void OnClick_SaveSkills()
    {
        List<SkillLearn> skillLearn = new List<SkillLearn>();
        foreach (GameObject obj in SkillsManager.instance.skillNodeLst)
        {
            SkillNode skillNode = obj.GetComponent<SkillNode>();
            if (!skillNode || skillNode.curLv == skillNode.tempLv)
            {
                continue;
            }
            SkillLearn skillChange = new SkillLearn(skillNode.skillBase.skill_id, skillNode.skillBase.skill_use_type, skillNode.tempLv, -2);
            skillLearn.Add(skillChange);
        }
        if (skillLearn.Count() == 0)
        {
            return;
        }
        MySkills newSkills = new MySkills(SkillsManager.instance.tempPoint, skillLearn.ToArray());
        SocketIO.instance.skillSocketIO.Emit_SaveSkills(newSkills);
    }
}
