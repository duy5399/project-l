using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] protected SkillBaseJSON _skillBaseJSON;
    [SerializeField] protected int _skillLv;
    [SerializeField] protected Button _skillButton;
    [SerializeField] protected Image _skillIconImg;
    [SerializeField] protected TextMeshProUGUI _skillLvText;
    [SerializeField] protected Image _cooldownImg;
    [SerializeField] protected TextMeshProUGUI _cooldownText;

    [SerializeField] protected bool isCooldown;
    [SerializeField] protected float curCooldown;

    public SkillBaseJSON skillBaseJSON
    {
        get { return _skillBaseJSON; }
        set { _skillBaseJSON = value; }
    }

    public int skillLv
    {
        get { return _skillLv; }
        set { _skillLv = value; }
    }

    public Button skillButton
    {
        get { return _skillButton; }
        set { _skillButton = value; }
    }

    public Image skillIconImg
    {
        get { return _skillIconImg; }
        set { _skillIconImg = value; }
    }

    public TextMeshProUGUI skillLvText
    {
        get { return _skillLvText; }
        set { _skillLvText = value; }
    }

    public Image cooldownImg
    {
        get { return _cooldownImg; }
        set { _cooldownImg = value; }
    }

    public TextMeshProUGUI cooldownText
    {
        get { return _cooldownText; }
        set { _cooldownText = value; }
    }

    protected virtual void Awake()
    {
        skillButton = this.GetComponent<Button>();
        skillIconImg = this.transform.GetChild(0).GetComponent<Image>();
        skillLvText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        cooldownImg = this.transform.GetChild(2).GetComponent<Image>();
        cooldownText = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        isCooldown = false;
        curCooldown = 0;
    }

    protected virtual void OnEnable()
    {
        skillButton.onClick.AddListener(OnClick_TriggerSkill);
    }

    protected virtual void OnDisable()
    {
        skillButton.onClick.RemoveListener(OnClick_TriggerSkill);
    }

    void Start()
    {
        
    }

    protected virtual void Update()
    {
        if(this.skillBaseJSON == null)
        {
            return;
        }
        if (!isCooldown || curCooldown <= 0)
        {
            return;
        }
        cooldownText.text = Mathf.Floor(curCooldown).ToString();
        cooldownImg.fillAmount = curCooldown / this.skillBaseJSON.skill_info[skillLv].cd;
        curCooldown -= Time.deltaTime;
        if(curCooldown <= 0)
        {
            cooldownText.text = "";
            cooldownImg.fillAmount = 0;
            isCooldown = false;
            curCooldown = 0;
        }
    }

    protected virtual void OnClick_TriggerSkill()
    {
        if (this.skillBaseJSON == null)
        {
            return;
        }
        ChBase chBase = GameManager.instance.characterManager.myCharacter.GetComponent<ChBase>();
        //if (!chBase.chSkill.target)
        //{
        //    chBase.chSkill.SelectTargetToRelease(this.skillBaseJSON);
        //}
        //if (!chBase.chSkill.target)
        //{
        //    return;
        //}
        //chBase.chMove.autoMoveToTarget = true;
        //chBase.chMove.distanceWithTarget = this.skillBaseJSON.distance;
        //chBase.chMove.AutoMoveToTarget(chBase.chSkill.target, () =>
        //{
        //    SocketIO.instance.skillSocketIO.Emit_TriggerSkill(skillBaseJSON);
        //});
        if (!chBase.chSkill.target)
        {
            SocketIO.instance.skillSocketIO.Emit_TriggerSkill(this.skillBaseJSON);
        }
    }
}
