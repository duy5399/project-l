using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    public static SkillsManager instance { get; private set; }

    [SerializeField] private Image backgroundImg;
    [SerializeField] private ScrollRect skillTree;
    public SkillInfoManager skillInfo;
    public SetupSkillManager setupSkill;
    [SerializeField] private Button closeBtn;
    public List<GameObject> skillList;
    public int curPoint;
    public int tempPoint;

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
        backgroundImg = this.transform.GetChild(0).GetComponent<Image>();
        skillTree = this.transform.GetChild(1).GetComponent<ScrollRect>();
        skillInfo = this.transform.GetChild(2).GetComponent<SkillInfoManager>();
        setupSkill = this.transform.GetChild(3).GetComponent<SetupSkillManager>();
        closeBtn = this.transform.GetChild(5).GetComponent<Button>();
        skillList = new List<GameObject>();
    }

    private void OnEnable()
    {
        closeBtn.onClick.AddListener(OnClick_Close);
    }

    private void OnDisable()
    {

    }

    void Start()
    {
        //GetSkills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSkills()
    {
        SocketIO.instance.skillSocketIO.Emit_GetSkills();
    }

    public void DisplaySkillTree(string skills, string mySkills, string job)
    {
        Debug.Log(mySkills);
        VirtualController virtualController = GameManager.instance.joystick.GetComponent<VirtualController>();
        switch (job)
        {
            case "class_1_1_1":
            case "class_1_2_1":
                backgroundImg.color = new Color32(201, 98, 94, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-swordsman 1");
                virtualController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/katana");
                break;
            case "class_2_1_1":
            case "class_2_2_1":
                backgroundImg.color = new Color32(88, 124, 171, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-mage 1");
                virtualController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/bow");
                break;
            case "class_3_1_1":
            case "class_3_2_1":
                backgroundImg.color = new Color32(124, 141, 49, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-archer 1");
                virtualController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/wand");
                break;
        }
        SkillBaseJSON[] skillBaseJSON = JsonConvert.DeserializeObject<SkillBaseJSON[]>(skills);
        MySkillsDataJSON mySkillDataJSON = JsonConvert.DeserializeObject<MySkillsDataJSON>(mySkills);
        curPoint = mySkillDataJSON.curPoint;
        tempPoint = curPoint;
        GameObject skillNodePrefab = Resources.Load<GameObject>("prefab/skills/SkillNode");
        for (int i = 0; i < skillBaseJSON.Length; i++)
        {
            if (skillBaseJSON[i].display_id == -1 && skillBaseJSON[i].is_normal_attack)
            {
                virtualController.normalAttackBtn.GetComponent<NormalAttackButton>().skillBaseJSON = skillBaseJSON[i];
                continue;
            }
            while(skillList.Count < skillBaseJSON[i].display_id)
            {
                GameObject emptyObj = Instantiate(new GameObject("SkillNodeEmpty", typeof(RectTransform)), skillTree.content);
                skillList.Add(emptyObj);
            }
            GameObject skillNodeObj = Instantiate(skillNodePrefab, skillTree.content);
            skillNodeObj.name = "Skill_" + skillBaseJSON[i].skill_id;
            SkillNodeManager skillNode = skillNodeObj.GetComponent<SkillNodeManager>();
            skillNode.skillBaseJSON = skillBaseJSON[i];
            skillNode.skillName.text = skillBaseJSON[i].skill_name;
            skillNode.skillIcon.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseJSON[i].skill_id);
            skillNode.skillBorder.sprite = Resources.Load<Sprite>(skillBaseJSON[i].skill_use_type == SkillUseType.Passive ? "image/skill/border/ui_border_skill_passsive_00" : "image/border/ui_border_skill_active_00");
            SkillLearn mySkillCheck = mySkillDataJSON.skills.FirstOrDefault(x => x.skill_id == skillBaseJSON[i].skill_id);
            if (mySkillCheck != null)
            {
                skillNode.curLv = mySkillCheck.level;
                skillNode.tempLv = mySkillCheck.level;
                if(mySkillCheck.slot >= 0)
                {
                    setupSkill.skillButtonList[mySkillCheck.slot].skillBaseJSON = skillBaseJSON[i];
                    setupSkill.skillButtonList[mySkillCheck.slot].skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseJSON[i].skill_id);
                    virtualController.skillButtons[mySkillCheck.slot].GetComponent<SkillButton>().skillBaseJSON = skillBaseJSON[i];
                    virtualController.skillButtons[mySkillCheck.slot].GetComponent<SkillButton>().skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseJSON[i].skill_id);
                    //virtualController.skillButtons[mySkillCheck.slot].GetComponent<SkillButton>().skillLvText.text = "Lv." + SkillsManager.instance.skillInfo.skillNodeManager.curLv;
                }
            }
            else
            {
                skillNode.curLv = 0;
                skillNode.tempLv = 0;
            }
            skillNode.skillLv.text = skillNode.tempLv + "/" + skillNode.skillBaseJSON.max_level;
            skillList.Add(skillNodeObj);
        }
    }

    public void SaveSkillsSuccess(string newSkills)
    {
        MySkillsDataJSON newSkillsDataJSON = JsonConvert.DeserializeObject<MySkillsDataJSON>(newSkills);
        curPoint = newSkillsDataJSON.curPoint;
        tempPoint = newSkillsDataJSON.curPoint;
        foreach (var skill in newSkillsDataJSON.skills)
        {
            GameObject skillObj = skillList.FirstOrDefault(x => x.GetComponent<SkillNodeManager>() != null && x.GetComponent<SkillNodeManager>().skillBaseJSON.skill_id == skill.skill_id);
            if(skillObj != null)
            {
                skillObj.GetComponent<SkillNodeManager>().curLv = skill.level;
                skillObj.GetComponent<SkillNodeManager>().tempLv = skill.level;
                Debug.Log("SaveSkillsSuccess: " + skill.skill_id + " - " + skill.level);
            }
        }
    }

    public void OnChange_MySkills()
    {

    }

    void OnClick_Close()
    {
        this.gameObject.SetActive(false);
    }
}

[Serializable]
public class MySkillsDataJSON
{
    public int curPoint;
    public SkillLearn[] skills;

    public MySkillsDataJSON(int curPoint, SkillLearn[] skills)
    {
        this.curPoint = curPoint;
        this.skills = skills;
    }
}

[Serializable]
public class SkillLearn
{
    public string skill_id;
    public int level;
    public int slot;

    public SkillLearn(string skill_id, int level, int slot)
    {
        this.skill_id = skill_id;
        this.level = level;
        this.slot = slot;
    }
}