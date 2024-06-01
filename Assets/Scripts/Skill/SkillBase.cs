using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;
using System.ComponentModel;

[Serializable]
public class SkillBase
{
    [Description("ID kỹ năng")]
    public string skill_id;

    [Description("Tên kỹ năng")]
    public string skill_name;

    [Description("Biểu tượng kỹ năng")]
    public string skill_icon;

    [Description("Loại kỹ năng Chủ động hoặc Bị động")]
    public string skill_use_type;

    [Description("Kỹ năng có được tính là 1 đòn đánh thường hay không?")]
    public bool is_normal_attack;

    [Description("Mô tả về kỹ năng")]
    public string description;

    [Description("Cấp độ tối đa của kỹ năng")]
    public int max_level;

    [Description("Loại đối tượng mà kỹ năng có thể nhắm vào và thi triển")]
    public string skill_target_type;

    [Description("Vị trí đặt kỹ năng")]
    public string skill_pos;

    [Description("Logic hoạt động của kỷ năng khi thi triển thành công")]
    public SkillLogic skill_logic;

    [Description("Khoảng cách kỹ năng có thể thi triển")]
    public float distance;

    [Description("Kỹ năng có bị cấm thi triển khi câm lặng không?")]
    public bool can_be_silenced;

    [Description("Kỹ năng có thể bị ngắt/gián đoạn khi thi triển hay không?")]
    public bool can_interrupt;

    [Description("Kỹ năng có cho phép di chuyển khi đang niệm phép hay không?")]
    public bool can_move_when_casting;

    [Description("Hoạt ảnh của kỹ năng")]
    public string skill_animName;

    [Description("Hiệu ứng của kỹ năng")]
    public AnimEffect[] anim_effect;

    [Description("Thời gian hoạt ảnh khi vung vũ khí lên cao")]
    public float cast_head_time;

    [Description("Thời gian hoạt ảnh khi vung vũ khí về phía trước")]
    public float casting_time;

    [Description("Thời gian hoạt ảnh khi thu vũ khí về")]
    public float cast_back_time;

    [Description("Thời gian hoạt ảnh có thay đổi hay không? VD: hoạt ảnh đánh thường sẽ tỉ lệ với Tốc độ đánh của nhân vật")]
    public bool scale_animSpeed;

    [Description("!!!")]
    public float channel_time;

    [Description("Tham số của kỹ năng: sát thương, hiệu ứng buff, hiệu ứng debuff")]
    public SkillInfo[] skill_info;

    [Description("Cấp độ yêu cầu để có thể học kỹ năng này")]
    public int level_require;

    [Description("Các kỹ năng cần có để có thể học kỹ năng này")]
    public string skill_require;

    [Description("Các lớp nhân vật có thể học kỹ năng này")]
    public string[] class_require;

    [Description("Vị trí hiển thị của kỹ năng trong cây kỹ năng")]
    public int display_id;

    public string Description(int level)
    {
        string _description = description;
        if (_description.Contains("{raw_damage}"))
        {
            _description = _description.Replace("{raw_damage}", (skill_info[level].damage.raw_damage * 100) + "%");
        }
        if (_description.Contains("{p_atk_multiplier}"))
        {
            _description = _description.Replace("{p_atk_multiplier}", skill_info[level].damage.p_atk_multiplier.ToString());
        }
        if (_description.Contains("{cd}"))
        {
            _description = _description.Replace("{cd}", skill_info[level].cd.ToString());
        }
        return _description;
    }
}

public enum SkillUseType
{
    Passive = 0,
    Active = 1
}

public enum SkillTargetType
{
    None = 0,
    Self = 1,
    Ally = 2,
    Enemy = 3
}

public enum SkillTarget
{
    None = 0,
    Self = 1,
    Target = 2,
    Party = 3
}

[Serializable]
public class SkillInfo
{
    [Description("Cấp độ hiện tại của kỹ năng")]
    public int skill_lv;
    public Damage damage;
    public Buff[] buff;
    public Debuff debuff;
    public int maxTarget;
    public float cd;
    public float sp_cost;

    //public string buff": [
    //  {
    //    "buff_id": "Spear_Stab_Decrease_Armor",
    //    "status_effect": "DecreaseArmor",
    //    "append_type": "Add",
    //    "amount": 0.1,
    //    "lifetime": 3
    //  }
    //]
}
[Serializable]
public class Damage
{
    [Description("Loại sát thương mà kỹ năng gây ra: ST vật lý và ST phép")]
    public string damage_type;
    [Description("ST cơ bản của kỹ năng")]
    public float raw_damage;
    [Description("Hệ số ST vật lý kèm theo")]
    public float p_atk_multiplier;
    [Description("Hệ số ST phép kèm theo")]
    public float m_atk_multiplier;
    [Description("kỹ năng có thể chí mạng hay không?")]
    public bool can_crit;
    [Description("Kỹ năng có thể hút máu để hồi phục cho bản thân hay không?")]
    public bool can_lifesteal;
    //TO DO: có thể thêm chỉ số %hp, %def,...
}

public enum DamageType
{
    P_ATK = 0,
    M_ATK = 1
}

public enum SkillPos
{
    None = 0,
    [Description("Mục tiêu")]
    Target = 1,
    [Description("Vị trí của mục tiêu")]
    TargetPos = 2,
    //SelfPos = 3,    //vị trí ngay bản thân
    //AroundSelf = 4  //vị trí là xung quanh bản thân
}

public enum SkillShapeType
{
    Sigle = 1,
    Rectangle = 2,
    CircularSector = 3,
    Circle = 4
};

[Serializable]
public class SkillLogic
{
    [Description("Phạm vi hoạt động của kỹ năng")]
    public string logic;
    [Description("Hình dạng kỹ năng")]
    public string skill_shape_type;
    [Description("Đối tượng bị ảnh hưởng bởi kỹ năng")]
    public string target_type;
    [Description("Tham số về hình dạng kỹ năng. VD: Circle - radius = 3,...")]
    public float[] shape_param;
    [Description("Số lần tối đa có thể kích hoạt kỹ năng. VD: kỹ năng có thể gây ST 3 đợt")]
    public int count;
    [Description("Thời gian để kích hoạt lại kỹ năng. VD: kỹ năng có thể gây ST sau mỗi 3 giây")]
    public float interval;
    [Description("Số mục tiêu tối đa mà kỹ năng có thể tác động. VD: kỹ năng có thể gây ST tối đa cho 3 mục tiêu trong phạm vi")]
    public int max_hit_num;
}

public enum Logic
{
    //LockedTarget = 0,
    //SelfRange = 1,
    //PointRange = 2
    [Description("Kỹ năng Đơn mục tiêu (Đối tượng mà kỹ năng đã ngắm và thi triển)")]
    Single =0,
    [Description("Kỹ năng AOE")]
    Range = 1
}

[Serializable]
public class Buff
{
    public string buff_id;
    public string buff_name;
    public string buff_desc;
    public string buff_icon;
    public int buff_display;
    public float buff_rate;
    public BuffOn buff_on;
    public BuffEventType[] buff_event_type;
    public BuffOverlayType buff_overlay_type;
    public BuffType[] buff_type;
    public BuffEffect buff_effect;
    public BuffEndType buff_end_type;
    public BuffEndCondition buff_end_condition;
    public string caster;
    public string target;
    public string ability;
    public int buff_limit_layer;
    public int buff_level;
    public float buff_duration;
    public int BuffTag;
    //khi BUFF này có hiệu lực thì các BUFF tiếp theo không thể phát huy tác dụng, chẳng hạn như BKB miễn nhiễm choáng.
    public int BuffImmuneTag;
    //khi BUFF này có hiệu lực, buff nào hiện có sẽ trở nên không hợp lệ, chẳng hạn như một số buff xóa trạng thái tiêu cực
    public int BuffConflictTag;
    public AnimEffect[] animEffects;
    public SearchAmong searchAmong;

    //[JsonConverter(typeof(StringEnumConverter))]
    //public BuffOn buffOn;
    public float buffRange;
    public int maxHitNum;
    public bool haveLifeTime;
    public float[] lifeTime;
    public bool destroyOnLifeEnding;
    //[JsonConverter(typeof(StringEnumConverter))]
    //public AddType addType;
    public int maxStackUp;
    public bool lifeTimeCanChange;
}
[Serializable]
public class AnimEffect
{
    public string effectName;
    public string effectPath;
    public float delay;
    public float[] offset;
    public float lifeTime;
    public bool followHero;
    public bool scaleAnimSpeed;
    public float animSpeed;
    public bool mount;
}

public enum SearchAmong
{
    None = 0,
    Allies = 1,
    Enemies = 2
}
[Serializable]
public class Debuff : Buff
{

}

[Serializable]
public class BuffEffect
{
    public BuffType type;
    //AttrChange
    public float pAtk;
    public float pAtk_per;
    public float mAtk;
    public float mAtk_per;
    public float hp;
    public float hp_per;
    public float maxHp;
    public float maxHp_per;
    public float sp;
    public float sp_per;
    public float maxSp;
    public float maxSp_per;
    public float pDef;
    public float pDef_per;
    public float mDef;
    public float mDef_per;
    public float pPen;
    public float pPen_per;
    public float mPen;
    public float mPen_per;
    public float atkSpd_per;
    public float haste;
    public float hit;
    public float hit_per;
    public float flee;
    public float flee_per;
    public float crit_per;
    public float antiCrit_per;
    public float critDmg_per;
    public float shield;
    public float moveSpd;
    public float moveSpd_per;
    public float pLifesteal;
    public float mLifesteal;
    public float pReflect;
    public float mReflect;

    public float spCost_per;
    public float hpRegenSpd_per;
    public float spRegenSpd_per;

//    isdisperse

    //---------------AttrChange
    //stack tối đa
    public int limit_stack_up;
    //-----------DelStatus
    //danh sách status cần xóa (DelStatus) hoặc miễn nhiễm (ImmuneStatus)
    //public float StateDef
    public StateEffect[] status;
    public int random_num;

    //--------NoDelStatus
    //public StateEffect[] status;

    //----------ImmuneStatus
    //public StateEffect[] status;


    //status này không thể xóa
    public int force_status;


    //số lượng buff hoặc status tối đa có thể xóa
    //public int random_num;

    //----------AddBuff
    //danh sách id buff cần thêm và xoá
    public AddBuff addBuff;
    public float rate;


    //danh sách id buff kết thúc
    public string[] end_extra_buff;
    
    //--------AbsorbDamage
    public float AbsorbAmount;

    //--------LimitUseItem
    //danh sách vật phẩm bị cấm sử dụng
    public int[] forbid_all;
    
    //---------DmagetoHeal
    //VD DamageToHeal: range là pha,5 vi hồi máu, healRatio: tỉ lệ chuyển đổi dmg to heal, includeSelf: có hồi máu cho bản thân khôn
    public float range;
    public float healRatio;
    public int includeSelf;

    //------LimitSkill
    //danh sách kỹ năng hoặc buff bị giới hạn
    public int[] notid;

    //-------Disperse
    public int num;

    //--------ShareDamage
    //tỉ lệ chia sát thương (BindDamage)
    //public float rate;

    public int NormalAtk;


    //
    //
    public float AutoBlockRate;
    //
    public float sharePer;
}

public enum BuffType
{
    None = 0,
    AttrChange = 1,     //thay đổi chỉ số
    AddBuff,            //thêm buff
    DelBuff = 2,        //xóa buff
    AddStatus = 5,      //thêm trạng thái khống chế
    DelStatus = 3,      //xóa trạng thái khống chế
    HPSPChange = 4,     //hồi hp/sp
    AbsorbDamage = 6,   //lá chắn
    LimitUseItem = 8,   //giới hạn vật phẩm
    Disperse,           //xóa hiệu ứng debuff
    NoDisperse = 9,     //không thể xóa hiệu ứng debuff
    NoDelStatus = 10,   //không thể xóa trạng thái khống chế
    DamageToHeal = 11,  //chuyển sát thương thành hp
    LimitSkill = 12,    //giới hạn kỹ năng
    SpRecover = 13,     //hồi p 
    ImmuneStatus = 14,  //kháng trạng thái khống chế   
    ImmuneAttack = 16,  //kháng sát thương
    ShareDamage = 20,   //chia sẻ sát thương
    AutoBlock = 21,     
    DisableSkill,
    ClearSkillCD
}

public enum StateEffect
{
    None = 0,
    Dizzy = 1,
    Silence = 2,
    Burn = 3,
    Freeze = 5,
    Fear = 6,
}

public enum BuffEventType
{
    OnNone = 0,
    [Description("Khi nhân vật được tạo")]
    OnCreate = 1,
    [Description("Khi nhân vật sử dụng đánh thường")]
    OnAttack = 2,
    [Description("Khi nhân vật sử dụng kỹ năng")]
    OnSkillCast = 3,
    [Description("Khi nhân vật sử dụng đánh thường trúng mục tiêu")]
    OnAttackTarget = 4,
    [Description("Khi nhân vật sử dụng kỹ năng trúng mục tiêu")]
    OnSkillOnTarget = 5,
    [Description("Khi nhân vật bị trúng đòn đánh thường")]
    OnBeAttacked = 6,
    [Description("Khi nhân vật bị trúng đòn kỹ năng")]
    OnBeSkilled = 7,
    [Description("Khi nhân vật bị trúng hiệu ứng khống chế")]
    OnBeControl = 8,
    [Description("Trước khi nhân vật bị hạ gục")]
    OnBeforeDeath = 9,
    [Description("Sau khi nhân vật bị hạ gục")]
    OnAfterDeath = 10,
    [Description("Khi nhân vật hỗ trợ hạ gục mục tiêu")]
    OnAssist = 11,
    [Description("Khi nhân vật tiêu diệt được mục tiêu")]
    OnKill = 12,
    [Description("Khi nhân vật tiêu diệt được mục tiêu")]
    OnTime = 13,
}

public enum BuffOverlayType
{
    [Description("Ghi đè (Nếu đã có buff)")]
    Overlay = 0,
    [Description("Làm mới thời gian các buff trong stack và thêm vào (nếu không vượt quá giới hạn)")]
    Stack_Refresh = 1,
    [Description("Thêm vào stack (xóa các buff ở đầu mảng nếu vượt quá giới hạn)")]
    Stack_NotRefresh = 2
}

[Serializable]
public class BuffEndCondition
{
    public int activeTime;
    public float duration;
}

public enum BuffEndType
{
    All = 0,
    Layer = 1
}

public enum BuffOn
{
    Caster = 0,
    Target = 1
}

[SelectionBase]
public class AddBuff
{
    public Buff[] buffs;
}
