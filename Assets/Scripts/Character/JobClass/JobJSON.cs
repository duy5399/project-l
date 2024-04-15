using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainChatManager;

[Serializable]
public class JobJSON
{
    public string job_id;
    public string job_name;
    public int level_requirement;
    public string job_gender;
    public string job_role;
    public string job_des;
    public string[] job_subclasses;
}
