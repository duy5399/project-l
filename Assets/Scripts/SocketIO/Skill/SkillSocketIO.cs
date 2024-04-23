using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[Serializable]
public class SkillSocketIO
{
    #region On (lắng nghe sự kiện)
    public void SkillSocketIOStart()
    {
        SocketIO.instance.socketManager.Socket.On<string, string, string>("get-skills-success", (skills, mySkills, job) => {
            On_GetSkillsSuccess(skills, mySkills, job);
        });
        SocketIO.instance.socketManager.Socket.On<string>("get-skills-fail", (error) => {
            On_GetSkillsFail(error);
        });
        SocketIO.instance.socketManager.Socket.On<string>("save-skills-success", (newSkills) => {
            On_SaveSkillsSuccess(newSkills);
        });
        SocketIO.instance.socketManager.Socket.On<string>("save-skills-fail", (error) => {
            On_SaveSkillsFail(error);
        });
        SocketIO.instance.socketManager.Socket.On<string>("equip-skill-success", (skill) => {
            On_EquipSkillSuccess(skill);
        });
        SocketIO.instance.socketManager.Socket.On<string>("equip-skill-fail", (error) => {
            On_EquipSkillFail(error);
        });
        SocketIO.instance.socketManager.Socket.On<string>("trigger-skill-success", (skill) => {
            Debug.Log(skill.ToString());
        });
        SocketIO.instance.socketManager.Socket.On<string>("trigger-skill-fail", (error) => {
            Debug.Log(error.ToString());
        });
    }
    private void On_GetSkillsSuccess(string skills, string mySkills, string job)
    {
        SkillsManager.instance.DisplaySkillTree(skills, mySkills, job);
    }
    private void On_GetSkillsFail(string error)
    {
        Debug.Log(error);
    }
    private void On_SaveSkillsSuccess(string newSkills)
    {
        SkillsManager.instance.SaveSkillsSuccess(newSkills);
    }
    private void On_SaveSkillsFail(string error)
    {
        Debug.Log(error);
    }
    private void On_EquipSkillSuccess(string skill)
    {
        Debug.Log("On_EquipSkillSuccess: " + skill);
    }
    private void On_EquipSkillFail(string error)
    {
        Debug.Log(error);
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_GetSkills()
    {
        SocketIO.instance.socketManager.Socket.Emit("get-skills");
    }

    public void Emit_SaveSkills(MySkillsDataJSON newSkills)
    {
        SocketIO.instance.socketManager.Socket.Emit("save-skills", JsonUtility.ToJson(newSkills));
    }

    public void Emit_EquipSkill(SkillLearn skill)
    {
        SocketIO.instance.socketManager.Socket.Emit("equip-skill", JsonUtility.ToJson(skill));
    }

    public void Emit_TriggerSkill(SkillBaseJSON SkillBaseJSON)
    {
        SocketIO.instance.socketManager.Socket.Emit("trigger-skill", JsonUtility.ToJson(SkillBaseJSON));
    }
    #endregion
}
