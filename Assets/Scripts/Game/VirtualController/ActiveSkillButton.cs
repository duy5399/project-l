using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillButton : SkillButton
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnClick_TriggerSkill()
    {
        base.OnClick_TriggerSkill();

        GameObject charactorToControl = GameManager.instance.characterManager.myCharacter;

    }
}
