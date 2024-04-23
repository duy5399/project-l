using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Jobs;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SlotSetupSkill : MonoBehaviour
{
    public int index;
    public SkillBaseJSON skillBaseJSON;
    public Button equipSkillBtn;
    public Image skillIconImg;

    private void Awake()
    {
        skillIconImg = this.transform.GetChild(1).GetComponent<Image>();
        equipSkillBtn = this.transform.GetChild(2).GetComponent<Button>();
        skillBaseJSON = null;
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

    void OnClick_EquipSkill()
    {
        if (SkillsManager.instance.skillInfo.skillNodeManager == null || SkillsManager.instance.skillInfo.skillNodeManager.curLv <= 0 || SkillsManager.instance.skillInfo.skillNodeManager.skillBaseJSON.skill_use_type == SkillUseType.Passive)
        {
            return;
        }
        if (skillBaseJSON != null && skillBaseJSON.skill_id == SkillsManager.instance.skillInfo.skillNodeManager.skillBaseJSON.skill_id)
        {
            return;
        }
        SlotSetupSkill slotSetupSkill = SkillsManager.instance.setupSkill.skillButtonList.FirstOrDefault(x => x.skillBaseJSON != null && x.skillBaseJSON.skill_id == SkillsManager.instance.skillInfo.skillNodeManager.skillBaseJSON.skill_id);
        if(slotSetupSkill != null)
        {
            slotSetupSkill.skillBaseJSON = null;
            slotSetupSkill.skillIconImg.sprite = Resources.Load<Sprite>("image/background/ui_transparent_00");
        }
        skillBaseJSON = SkillsManager.instance.skillInfo.skillNodeManager.skillBaseJSON;
        skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseJSON.skill_id);
        VirtualController virtualController = GameManager.instance.joystick.GetComponent<VirtualController>();
        virtualController.skillButtons[index].GetComponent<SkillButton>().skillBaseJSON = skillBaseJSON;
        virtualController.skillButtons[index].GetComponent<SkillButton>().skillLv = SkillsManager.instance.skillInfo.skillNodeManager.curLv;
        virtualController.skillButtons[index].GetComponent<SkillButton>().skillIconImg.sprite = Resources.Load<Sprite>("image/skill/icon/" + skillBaseJSON.skill_id);
        virtualController.skillButtons[index].GetComponent<SkillButton>().skillLvText.text = "Lv." + SkillsManager.instance.skillInfo.skillNodeManager.curLv;
        SocketIO.instance.skillSocketIO.Emit_EquipSkill(new SkillLearn(skillBaseJSON.skill_id, SkillsManager.instance.skillInfo.skillNodeManager.curLv, index));
    }
}
