using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualController : MonoBehaviour
{
    public GameObject joystick;
    public Button normalAttackBtn;
    public Button changeComboSkillBtn;
    public List<Button> skillButtons;
    private bool isComboSkill0;

    private void Awake()
    {
        joystick = transform.GetChild(0).gameObject;
        normalAttackBtn = transform.GetChild(2).GetComponent<Button>();
        changeComboSkillBtn = transform.GetChild(3).GetComponent<Button>();
        skillButtons = new List<Button>();
        for (int i = 4; i < 12; i++){
            Button skillBtn = transform.GetChild(i).GetComponent<Button>();
            skillButtons.Add(skillBtn);
            if(i > 7)
            {
                skillBtn.gameObject.SetActive(false);
            }
        }
        isComboSkill0 = true;
    }

    private void OnEnable()
    {
        changeComboSkillBtn.onClick.AddListener(OnClick_ChangeSkill);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnClick_ChangeSkill()
    {
        if (isComboSkill0)
        {
            for (int i = 0; i < skillButtons.Count; i++)
            {
                if (i < 4)
                {
                    skillButtons[i].gameObject.SetActive(false);
                }
                else
                {
                    skillButtons[i].gameObject.SetActive(true);
                }
            }
            isComboSkill0 = false;
        }
        else
        {
            for (int i = 0; i < skillButtons.Count; i++)
            {
                if (i < 4)
                {
                    skillButtons[i].gameObject.SetActive(true);
                }
                else
                {
                    skillButtons[i].gameObject.SetActive(false);
                }
            }
            isComboSkill0 = true;
        }
    }
}
