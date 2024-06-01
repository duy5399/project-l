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

    public Image backgroundImg;
    public ScrollRect skillTree;
    public SkillInfoManager skillInfo;
    public EquipSkills equipSkills;
    public Button closeBtn;
    public List<GameObject> skillNodeLst;
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
        equipSkills = this.transform.GetChild(3).GetComponent<EquipSkills>();
        closeBtn = this.transform.GetChild(5).GetComponent<Button>();
        skillNodeLst = new List<GameObject>();
        equipSkills.Init();
        this.gameObject.SetActive(false);
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
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Hiển thị thông tin bảng kỹ năng của nhân vật
    /// </summary>
    /// <param name="skills1">Danh sách kỹ năng</param>
    /// <param name="skills2">Danh sách kỹ năng đã học</param>
    /// <param name="job">Nghề nghiệp</param>
    public void DisplaySkillTree(string skills1, string skills2, string job)
    {
        VirtualController playerController = GameManager.instance.joystick.GetComponent<VirtualController>();
        switch (job)
        {
            case "class_1_1_1":
            case "class_1_2_1":
                backgroundImg.color = new Color32(201, 98, 94, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-swordsman 1");
                playerController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/katana");
                break;
            case "class_2_1_1":
            case "class_2_2_1":
                backgroundImg.color = new Color32(88, 124, 171, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-mage 1");
                playerController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/wand");
                break;
            case "class_3_1_1":
            case "class_3_2_1":
                backgroundImg.color = new Color32(124, 141, 49, 255);
                backgroundImg.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/icon/class/icon-archer 1");
                playerController.normalAttackBtn.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("image/button/bow");
                break;
        }
        SkillBase[] skillBaseLst = JsonConvert.DeserializeObject<SkillBase[]>(skills1);
        GameObject skillNodePrefab = Resources.Load<GameObject>("prefab/skills/SkillNode");
        for (int i = 0; i < skillBaseLst.Length; i++)
        {
            if (skillBaseLst[i].display_id == -1 && skillBaseLst[i].is_normal_attack)
            {
                playerController.normalAttackBtn.GetComponent<NormalAttackButton>().skillBase = skillBaseLst[i];
                continue;
            }
            //Thêm Empty object
            while(skillNodeLst.Count < skillBaseLst[i].display_id)
            {
                GameObject emptyObj = Instantiate(new GameObject("SkillNodeEmpty", typeof(RectTransform)), skillTree.content);
                skillNodeLst.Add(emptyObj);
            }
            GameObject skillNodeObj = Instantiate(skillNodePrefab);
            skillNodeObj.name = "Skill_" + skillBaseLst[i].skill_id;
            SkillNode skillNode = skillNodeObj.GetComponent<SkillNode>();
            skillNode.skillBase = skillBaseLst[i];
            Debug.Log("skillBaseLst[i].skill_name: " + skillBaseLst[i].skill_name);
            skillNode.skillName.text = skillBaseLst[i].skill_name;
            skillNode.skillIcon.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseLst[i].skill_icon);
            skillNode.skillBorder.sprite = Resources.Load<Sprite>(skillBaseLst[i].skill_use_type == "Passive" ? "image/skill/border/ui_border_skill_passsive_00" : "image/skill/border/ui_border_skill_active_00");
            skillNode.skillLv.text = "0/" + skillBaseLst[i].max_level;
            skillNodeObj.transform.parent = skillTree.content;
            skillNodeObj.transform.localScale = Vector3.one;
            skillNodeLst.Add(skillNodeObj);
        }
        //Xử lý thông tin kỹ năng đã học
        MySkills mySkills = JsonConvert.DeserializeObject<MySkills>(skills2);
        curPoint = mySkills.curPoint;
        tempPoint = mySkills.curPoint;
        for (int i = 0; i < mySkills.skills.Count(); i++)
        {
            GameObject skillNodeObj = skillNodeLst.FirstOrDefault(x => x.GetComponent<SkillNode>() != null && x.GetComponent<SkillNode>().skillBase.skill_id == mySkills.skills[i].skill_id);
            if (!skillNodeObj)
            {
                continue;
            }
            SkillNode skillNode = skillNodeObj.GetComponent<SkillNode>();
            skillNode.curLv = mySkills.skills[i].level;
            skillNode.tempLv = mySkills.skills[i].level;
            skillNode.skillLv.text = mySkills.skills[i].level + "/" + skillNode.skillBase.max_level;
            if (mySkills.skills[i].equip_slot < 0)
            {
                continue;
            }
            int slot = mySkills.skills[i].equip_slot;
            Debug.Log(slot);
            equipSkills.skillLstBtn[slot].skillBase = skillNode.skillBase;
            equipSkills.skillLstBtn[slot].skillIconImg.sprite = skillNode.skillIcon.sprite;
            playerController.equipSkillLstBtn[slot].GetComponent<EquipSkillButton>().skillBase = skillNode.skillBase;
            playerController.equipSkillLstBtn[slot].GetComponent<EquipSkillButton>().skillIconImg.sprite = skillNode.skillIcon.sprite;
            //virtualController.skillButtons[mySkillCheck.slot].GetComponent<SkillButton>().skillLvText.text = "Lv." + SkillsManager.instance.skillInfo.skillNodeManager.curLv;
        }
    }

    /// <summary>
    /// Lưu bảng kỹ năng thành công
    /// </summary>
    /// <param name="skills">Danh sách kỹ năng lưu thành công</param>
    public void SaveSkillsSuccess(string skills)
    {
        MySkills newSkills = JsonConvert.DeserializeObject<MySkills>(skills);
        curPoint = newSkills.curPoint;
        tempPoint = newSkills.curPoint;
        foreach (var skill in newSkills.skills)
        {
            GameObject skillNodeObj = skillNodeLst.FirstOrDefault(x => x.GetComponent<SkillNode>() != null && x.GetComponent<SkillNode>().skillBase.skill_id == skill.skill_id);
            if (!skillNodeObj)
            {
                continue;
            }
            SkillNode skillNode = skillNodeObj.GetComponent<SkillNode>();
            skillNode.curLv = skill.level;
            skillNode.tempLv = skill.level;
            Debug.Log("SaveSkillsSuccess: " + skill.skill_id + " - " + skill.level);
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
public class MySkills
{
    public SkillLearn[] skills;
    public int curPoint;

    public MySkills(int curPoint, SkillLearn[] skills)
    {
        this.curPoint = curPoint;
        this.skills = skills;
    }
}

[Serializable]
public class SkillLearn
{
    public string skill_id;
    public string skill_use_type;
    public int level;
    public int equip_slot;

    public SkillLearn(string skill_id, string skill_use_type, int level, int equip_slot)
    {
        this.skill_id = skill_id;
        this.skill_use_type = skill_use_type;
        this.level = level;
        this.equip_slot = equip_slot;
    }
}