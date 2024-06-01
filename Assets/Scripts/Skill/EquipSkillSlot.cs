using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Jobs;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EquipSkillSlot : MonoBehaviour
{
    public int index;
    public SkillBase skillBase;
    public Button equipSkillBtn;
    public Image skillIconImg;

    private void Awake()
    {
        skillIconImg = this.transform.GetChild(1).GetComponent<Image>();
        equipSkillBtn = this.transform.GetChild(2).GetComponent<Button>();
    }

    private void OnEnable()
    {
        equipSkillBtn.onClick.AddListener(OnClick_EquipSkill);
    }

    private void OnDisable()
    {
        equipSkillBtn.onClick.RemoveListener(OnClick_EquipSkill);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init()
    {
        skillIconImg = this.transform.GetChild(1).GetComponent<Image>();
        equipSkillBtn = this.transform.GetChild(2).GetComponent<Button>();
    }

    void OnClick_EquipSkill()
    {
        if (SkillsManager.instance.skillInfo.skillNodeManager == null || SkillsManager.instance.skillInfo.skillNodeManager.curLv <= 0 || SkillsManager.instance.skillInfo.skillNodeManager.skillBase.skill_use_type == "Passive")
        {
            return;
        }
        if (skillBase != null && skillBase.skill_id == SkillsManager.instance.skillInfo.skillNodeManager.skillBase.skill_id)
        {
            return;
        }
        EquipSkillSlot slotSetupSkill = SkillsManager.instance.equipSkills.skillLstBtn.FirstOrDefault(x => x.skillBase != null && x.skillBase.skill_id == SkillsManager.instance.skillInfo.skillNodeManager.skillBase.skill_id);
        if(slotSetupSkill != null)
        {
            slotSetupSkill.skillBase = null;
            slotSetupSkill.skillIconImg.sprite = Resources.Load<Sprite>("image/background/ui_transparent_00");
        }
        skillBase = SkillsManager.instance.skillInfo.skillNodeManager.skillBase;
        skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBase.skill_icon);
        VirtualController virtualController = GameManager.instance.joystick.GetComponent<VirtualController>();
        virtualController.equipSkillLstBtn[index].GetComponent<EquipSkillButton>().skillBase = skillBase;
        virtualController.equipSkillLstBtn[index].GetComponent<EquipSkillButton>().skillLv = SkillsManager.instance.skillInfo.skillNodeManager.curLv;
        virtualController.equipSkillLstBtn[index].GetComponent<EquipSkillButton>().skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBase.skill_icon);
        virtualController.equipSkillLstBtn[index].GetComponent<EquipSkillButton>().skillLvText.text = "Lv." + SkillsManager.instance.skillInfo.skillNodeManager.curLv;
        SocketIO.instance.skillSocketIO.Emit_EquipSkill(new SkillLearn(skillBase.skill_id, skillBase.skill_use_type, SkillsManager.instance.skillInfo.skillNodeManager.curLv, index));
    }
}
