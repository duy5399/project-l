using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChInfoManager : MonoBehaviour
{
    public static ChInfoManager instance { get; private set; }

    public TextMeshProUGUI pAtkTxt;
    public TextMeshProUGUI mAtkTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI spTxt;
    public TextMeshProUGUI pDefTxt;
    public TextMeshProUGUI mDefTxt;
    public TextMeshProUGUI pPenTxt;
    public TextMeshProUGUI mPenTxt;
    public TextMeshProUGUI asdpTxt;
    public TextMeshProUGUI hasteTxt;
    public TextMeshProUGUI hitTxt;
    public TextMeshProUGUI fleeTxt;
    public TextMeshProUGUI critTxt;
    public TextMeshProUGUI antiCritTxt;
    public TextMeshProUGUI critDmgTxt;
    public TextMeshProUGUI antiCritDmgTxt;
    public TextMeshProUGUI pLifestealTxt;
    public TextMeshProUGUI mLifestealTxt;
    public TextMeshProUGUI pReflectTxt;
    public TextMeshProUGUI mReflectTxt;
    public TextMeshProUGUI hpRengenTxt;
    public TextMeshProUGUI spRengenTxt;

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
        pAtkTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        mAtkTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        hpTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        spTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        pDefTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        mDefTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();
        pPenTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>();
        mPenTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>();
        asdpTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>();
        hasteTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>();
        hitTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>();
        fleeTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(11).GetChild(1).GetComponent<TextMeshProUGUI>();
        critTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(12).GetChild(1).GetComponent<TextMeshProUGUI>();
        antiCritTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(13).GetChild(1).GetComponent<TextMeshProUGUI>();
        critDmgTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(14).GetChild(1).GetComponent<TextMeshProUGUI>();
        antiCritDmgTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(15).GetChild(1).GetComponent<TextMeshProUGUI>();
        pLifestealTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(16).GetChild(1).GetComponent<TextMeshProUGUI>();
        mLifestealTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(17).GetChild(1).GetComponent<TextMeshProUGUI>();
        pReflectTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(18).GetChild(1).GetComponent<TextMeshProUGUI>();
        mReflectTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(19).GetChild(1).GetComponent<TextMeshProUGUI>();
        hpRengenTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(20).GetChild(1).GetComponent<TextMeshProUGUI>();
        spRengenTxt = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(21).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ChCurState chCurState = GameManager.instance.characterManager.myCharacter.GetComponent<ChCurState>();
        if (!chCurState)
        {
            return;
        }
        pAtkTxt.text = chCurState.p_atk.ToString();
        mAtkTxt.text = chCurState.m_atk.ToString();
        hpTxt.text = chCurState.max_hp.ToString();
        spTxt.text = chCurState.max_sp.ToString();
        pDefTxt.text = chCurState.p_def.ToString();
        mDefTxt.text = chCurState.m_def.ToString();
        pPenTxt.text = chCurState.p_pen.ToString();
        mPenTxt.text = chCurState.m_pen.ToString();
        asdpTxt.text = (chCurState.aspd * 100).ToString() + "%" ;
        hasteTxt.text = (chCurState.haste * 100).ToString() + "%";
        hitTxt.text = (chCurState.hit * 100).ToString() + "%";
        fleeTxt.text = (chCurState.flee * 100).ToString() + "%";
        critTxt.text = (chCurState.crit * 100).ToString() + "%";
        antiCritTxt.text = (chCurState.anti_crit * 100).ToString() + "%";
        critDmgTxt.text = (chCurState.crit_dmg * 100).ToString() + "%";
        antiCritDmgTxt.text = (chCurState.anti_crit_dmg * 100).ToString() + "%";
        pLifestealTxt.text = (chCurState.p_lifesteal * 100).ToString() + "%";
        mLifestealTxt.text = (chCurState.m_lifesteal * 100).ToString() + "%";
        pReflectTxt.text = (chCurState.p_reflect * 100).ToString() + "%";
        mReflectTxt.text = (chCurState.m_reflect * 100).ToString() + "%";
        hpRengenTxt.text = (chCurState.hp_regen_spd * 100).ToString() + "%";
        spRengenTxt.text = (chCurState.sp_regen_spd * 100).ToString() + "%";
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
