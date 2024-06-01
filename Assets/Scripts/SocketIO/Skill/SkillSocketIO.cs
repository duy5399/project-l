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
        SocketIO.instance.socketManager.Socket.On<string, string, string>("init-skill-tree-success", (skills1, skills2, job) => {
            SkillsManager.instance.DisplaySkillTree(skills1, skills2, job);
        });

        SocketIO.instance.socketManager.Socket.On<string>("init-skill-tree-fail", (error) => {
            Debug.Log(error);
        });

        SocketIO.instance.socketManager.Socket.On<string>("save-skills-success", (skills) => {
            SkillsManager.instance.SaveSkillsSuccess(skills);
        });

        SocketIO.instance.socketManager.Socket.On<string>("save-skills-fail", (error) => {
            Debug.Log(error);
        });

        SocketIO.instance.socketManager.Socket.On<string>("equip-skill-success", (skill) => {
            Debug.Log("On_EquipSkillSuccess: " + skill);
        });

        SocketIO.instance.socketManager.Socket.On<string>("equip-skill-fail", (error) => {
            Debug.Log(error);
        });

        SocketIO.instance.socketManager.Socket.On<string>("trigger-skill-success", (skill) => {
            Debug.Log(skill.ToString());
        });

        SocketIO.instance.socketManager.Socket.On<string>("trigger-skill-fail", (error) => {
            Debug.Log(error.ToString());
        });
    }
    #endregion

    #region Emit (gửi sự kiện)
    public void Emit_SaveSkills(MySkills newSkills)
    {
        SocketIO.instance.socketManager.Socket.Emit("save-skills", JsonUtility.ToJson(newSkills));
    }

    public void Emit_EquipSkill(SkillLearn skill)
    {
        SocketIO.instance.socketManager.Socket.Emit("equip-skill", JsonUtility.ToJson(skill));
    }

    public void Emit_TriggerSkill(string skill_id)
    {
        SocketIO.instance.socketManager.Socket.Emit("trigger-skill", skill_id);
    }
    #endregion
}
