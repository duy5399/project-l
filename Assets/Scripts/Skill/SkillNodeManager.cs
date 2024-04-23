using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeManager : MonoBehaviour
{
    [SerializeField] private SkillBaseJSON _skillBaseJSON;
    [SerializeField] private Button _skillBtn;
    [SerializeField] private Image _skillIcon;
    [SerializeField] private Image _skillBorder;
    [SerializeField] private TextMeshProUGUI _skillLv;
    [SerializeField] private Button _decreaseLv;
    [SerializeField] private Button _increaseLv;
    [SerializeField] private TextMeshProUGUI _skillName;
    public int curLv;
    public int tempLv;

    public SkillBaseJSON skillBaseJSON
    {
        get { return _skillBaseJSON; }
        set { _skillBaseJSON = value; }
    }

    public Button skillBtn
    {
        get { return _skillBtn; }
        set { _skillBtn = value; }
    }

    public Image skillIcon
    {
        get { return _skillIcon; }
        set { _skillIcon = value; }
    }
    public Image skillBorder
    {
        get { return _skillBorder; }
        set { _skillBorder = value; }
    }
    public TextMeshProUGUI skillLv
    {
        get { return _skillLv; }
        set { _skillLv = value; }
    }
    public Button decreaseLv
    {
        get { return _decreaseLv; }
        set { _decreaseLv = value; }
    }
    public Button increaseLv
    {
        get { return _increaseLv; }
        set { _increaseLv = value; }
    }
    public TextMeshProUGUI skillName
    {
        get { return _skillName; }
        set { _skillName = value; }
    }

    private void Awake()
    {
        skillIcon = this.transform.GetChild(0).GetComponent<Image>();
        skillBorder = this.transform.GetChild(1).GetComponent<Image>();
        skillBtn = this.transform.GetChild(1).GetComponent<Button>();
        skillLv = this.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        decreaseLv = this.transform.GetChild(3).GetComponent<Button>();
        increaseLv = this.transform.GetChild(4).GetComponent<Button>();
        skillName = this.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        skillBtn.onClick.AddListener(OnClick_DisplayInfo);
        decreaseLv.onClick.AddListener(OnClick_DecreaseLvSkill);
        increaseLv.onClick.AddListener(OnClick_IncreaseLvSkill);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_DisplayInfo()
    {
        SkillsManager.instance.skillInfo.skillNodeManager = this;
        SkillsManager.instance.skillInfo.skillName.text = skillBaseJSON.skill_name +" Lv." + tempLv;
        SkillsManager.instance.skillInfo.skillType.text = skillBaseJSON.skill_use_type == SkillUseType.Passive ? "K/N Bị Động" : "K/N Chủ Động";
        //SkillsManager.instance.skillInfo.description.text = skillBaseJSON.skill_info[curLv].Description();
        SkillsManager.instance.skillInfo.curPoint.text = "Điểm Kỹ Năng còn: <color=#FF4F00>" + SkillsManager.instance.tempPoint.ToString() +"</color>";
        skillLv.text = tempLv + "/" + skillBaseJSON.max_level;
    }

    public void OnClick_DecreaseLvSkill()
    {
        if (tempLv <= 0)
        {
            return;
        }
        SkillsManager.instance.tempPoint += 1;
        tempLv -= 1;
        OnClick_DisplayInfo();
    }
    public void OnClick_IncreaseLvSkill()
    {
        if(tempLv >= skillBaseJSON.max_level || SkillsManager.instance.tempPoint <= 0)
        {
            return;
        }
        SkillsManager.instance.tempPoint -= 1;
        tempLv += 1;
        OnClick_DisplayInfo();
    }
}
