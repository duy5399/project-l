using Cinemachine;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class CharacterManager : MonoBehaviour
{
    public GameObject myCharacter;
    public List<GameObject> otherCharacter;

    private void Awake()
    {
        otherCharacter = new List<GameObject>();
    }

    public GameObject SpawnCharacter(CharacterInfo characterData, bool isMyCharacter = false)
    {
        string modelPath = string.Empty;
        string animCtrlPath = string.Empty;
        string mountAnimCtrlPath = string.Empty;
        switch (characterData.gender)
        {
            case true:
                if (characterData.job == "class_1_1_1")
                {
                    modelPath = "character/pc_knight_m/Pc_Knight_M";
                    animCtrlPath = "character/pc_knight_m/Pc_Knight_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_m/Pc_Knight_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_1_2")
                {
                    modelPath = "character/pc_knight2_m/Pc_Knight2_M";
                    animCtrlPath = "character/pc_knight_m/Pc_Knight_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_m/Pc_Knight_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_1_3")
                {
                    modelPath = "character/pc_knight3_m/Pc_Knight3_M";
                    animCtrlPath = "character/pc_knight_m/Pc_Knight_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_m/Pc_Knight_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_1")
                {
                    modelPath = "character/pc_cursader_m/Pc_Cursader_M";
                    animCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_2")
                {
                    modelPath = "character/pc_cursader2_m/Pc_Cursader2_M";
                    animCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_3")
                {
                    modelPath = "character/pc_cursader3_m/Pc_Cursader3_M";
                    animCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_m/Pc_Cursader_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_1")
                {
                    modelPath = "character/pc_wirzard_m/Pc_Wirzard_M";
                    animCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_2")
                {
                    modelPath = "character/pc_wirzard2_m/Pc_Wirzard2_M";
                    animCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_3")
                {
                    modelPath = "character/pc_wirzard3_m/Pc_Wirzard3_M";
                    animCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_m/Pc_Wirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_1")
                {
                    modelPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M";
                    animCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_2")
                {
                    modelPath = "character/pc_blackwirzard2_m/Pc_BlackWirzard2_M";
                    animCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_3")
                {
                    modelPath = "character/pc_blackwirzard3_m/Pc_BlackWirzard3_M";
                    animCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_m/Pc_BlackWirzard_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_1")
                {
                    modelPath = "character/pc_archer_m/Pc_Archer_M";
                    animCtrlPath = "character/pc_archer_m/Pc_Archer_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_m/Pc_Archer_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_2")
                {
                    modelPath = "character/pc_archer2_m/Pc_Archer2_M";
                    animCtrlPath = "character/pc_archer_m/Pc_Archer_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_m/Pc_Archer_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_3")
                {
                    modelPath = "character/pc_archer3_m/Pc_Archer3_M";
                    animCtrlPath = "character/pc_archer_m/Pc_Archer_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_m/Pc_Archer_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_1")
                {
                    modelPath = "character/pc_ranger_m/Pc_Ranger_M";
                    animCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_2")
                {
                    modelPath = "character/pc_ranger2_m/Pc_Ranger2_M";
                    animCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_3")
                {
                    modelPath = "character/pc_ranger3_m/Pc_Ranger3_M";
                    animCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_m/Pc_Ranger_M_MountAnimCtrl";
                }
                break;
            case false:
                if (characterData.job == "class_1_1_1")
                {
                    modelPath = "character/pc_knight_w/Pc_Knight_W";
                    animCtrlPath = "character/pc_knight_w/Pc_Knight_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_w/Pc_Knight_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_1_2")
                {
                    modelPath = "character/pc_knight2_w/Pc_Knight2_W";
                    animCtrlPath = "character/pc_knight_w/Pc_Knight_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_w/Pc_Knight_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_1_3")
                {
                    modelPath = "character/pc_knight3_w/Pc_Knight3_W";
                    animCtrlPath = "character/pc_knight_w/Pc_Knight_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_knight_w/Pc_Knight_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_1")
                {
                    modelPath = "character/pc_cursader_w/Pc_Cursader_W";
                    animCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_2")
                {
                    modelPath = "character/pc_cursader2_w/Pc_Cursader2_W";
                    animCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_1_2_3")
                {
                    modelPath = "character/pc_cursader3_w/Pc_Cursader3_W";
                    animCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_cursader_w/Pc_Cursader_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_1")
                {
                    modelPath = "character/pc_wirzard_w/Pc_Wirzard_W";
                    animCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_2")
                {
                    modelPath = "character/pc_wirzard2_w/Pc_Wirzard2_W";
                    animCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_1_3")
                {
                    modelPath = "character/pc_wirzard3_w/Pc_Wirzard3_W";
                    animCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_wirzard_w/Pc_Wirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_1")
                {
                    modelPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W";
                    animCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_2")
                {
                    modelPath = "character/pc_blackwirzard2_w/Pc_BlackWirzard2_W";
                    animCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_2_2_3")
                {
                    modelPath = "character/pc_blackwirzard3_w/Pc_BlackWirzard3_W";
                    animCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_blackwirzard_w/Pc_BlackWirzard_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_1")
                {
                    modelPath = "character/pc_archer_w/Pc_Archer_W";
                    animCtrlPath = "character/pc_archer_w/Pc_Archer_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_w/Pc_Archer_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_2")
                {
                    modelPath = "character/pc_archer2_w/Pc_Archer2_W";
                    animCtrlPath = "character/pc_archer_w/Pc_Archer_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_w/Pc_Archer_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_1_3")
                {
                    modelPath = "character/pc_archer3_w/Pc_Archer3_W";
                    animCtrlPath = "character/pc_archer_w/Pc_Archer_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_archer_w/Pc_Archer_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_1")
                {
                    modelPath = "character/pc_ranger_w/Pc_Ranger_W";
                    animCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_2")
                {
                    modelPath = "character/pc_ranger2_w/Pc_Ranger2_W";
                    animCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_MountAnimCtrl";
                }
                else if (characterData.job == "class_3_2_3")
                {
                    modelPath = "character/pc_ranger3_w/Pc_Ranger3_W";
                    animCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_AnimCtrl";
                    mountAnimCtrlPath = "character/pc_ranger_w/Pc_Ranger_W_MountAnimCtrl";
                }
                break;
        }
        string mountPath = string.Empty;
        switch (characterData.mount)
        {
            case "Pet_DuJiaoXN_01":
                mountPath = "character/mount_dujiaoxn_01/fbx/Pet_DuJiaoXN_01";
                break;
            case "Pet_DuJiaoXN_02":
                mountPath = "character/mount_dujiaoxn_02/fbx/Pet_DuJiaoXN_02";
                break;
            case "Pet_HuoYanXB_01":
                mountPath = "character/mount_huoyanxb/fbx/Pet_HuoYanXB_01";
                break;
            case "Pet_BianXingJG_01":
                mountPath = "character/mount_jixiel/fbx/Pet_BianXingJG_01";
                break;
            case "Pet_LanHu_01":
                mountPath = "character/mount_lanhu_01/fbx/Pet_LanHu_01";
                break;
            case "Pet_XiaoYang_03":
                mountPath = "character/mount_mianyang/fbx/Pet_XiaoYang_03";
                break;
            case "Mount_QingLvZJ_01":
                mountPath = "character/mount_qinglvzj_01/fbx/Mount_QingLvZJ_01";
                break;
            case "Mount_ShengDanML_01":
                mountPath = "character/mount_shengdanml_01/fbx/Mount_ShengDanML_01";
                break;
            case "Pet_ShiZi_01":
                mountPath = "character/mount_shinius/fbx/Pet_ShiZi_01";
                break;
            case "Mount_XiaoJi_01":
                mountPath = "character/mount_taigujj/fbx/Mount_XiaoJi_01";
                break;
            case "Pet_LvGuai_01":
                mountPath = "character/mount_yuelongs/fbx/Pet_LvGuai_01";
                break;
            case "Pet_ZhanNiu_01":
                mountPath = "character/mount_zhanniu_01/fbx/Pet_ZhanNiu_01";
                break;
        }
        GameObject chPrefab = Resources.Load<GameObject>("character/baseprefab/Character");
        GameObject modelPrefab = Resources.Load<GameObject>(modelPath);
        GameObject mountPrefab = Resources.Load<GameObject>(mountPath);
        Vector3 position = new Vector3(characterData.data_position[0], characterData.data_position[1], characterData.data_position[2]);
        Quaternion rotation = Quaternion.Euler(characterData.data_rotation[0], characterData.data_rotation[1], characterData.data_rotation[2]);
        GameObject chObj = Instantiate(chPrefab, position, rotation);
        chObj.name = characterData.nickname + "_" + characterData.uid;
        GameObject modelObj = Instantiate(modelPrefab);
        modelObj.name = "model-of-" + characterData.nickname;
        modelObj.AddComponent<ChAudio>();

        HPbar.instance.lvTxt.text = "Lv. " + characterData.level.ToString();

        RuntimeAnimatorController animCtrl = Resources.Load<RuntimeAnimatorController>(animCtrlPath);
        RuntimeAnimatorController mountAnimCtrl = Resources.Load<RuntimeAnimatorController>(mountAnimCtrlPath);

        ChBase chBase = chObj.GetComponent<ChBase>();
        ChCurState chCurState = chObj.GetComponent<ChCurState>();
        chBase.chInfo = characterData;
        chCurState.stats = characterData.data_stats;
        if (chBase != null)
        {
            chBase.chAnim.animator = modelObj.GetComponent<Animator>();
            chBase.chAnim.animCtrl = animCtrl;
            chBase.chAnim.mountAnimCtrl = mountAnimCtrl;
        }

        //nếu có thú cưỡi
        if (mountPrefab != null)
        {
            GameObject mountObj = Instantiate(mountPrefab);
            mountObj.name = "mount-of-" + characterData.nickname;
            mountObj.transform.SetParent(chObj.transform);
            mountObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            modelObj.transform.SetParent(mountObj.transform.Find("Dummy_Root/Bip001/Dummy_Pet"));
            modelObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            chBase.chAnim.animator.runtimeAnimatorController = mountAnimCtrl;
        }
        else
        {
            modelObj.transform.SetParent(chObj.transform);
            modelObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            chBase.chAnim.animator.runtimeAnimatorController = animCtrl;
        }
        if(isMyCharacter)
        {
            GameManager.instance.virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = chObj.transform;
            GameManager.instance.characterManager.myCharacter = chObj;
            chBase.isLocalPlayer = true;
            chBase.chMove.joystick = GameManager.instance.joystick.GetComponent<VirtualController>().joystick.GetComponent<FixedJoystick>();
        }
        else
        {
            GameManager.instance.characterManager.otherCharacter.Add(chObj);
            chBase.isLocalPlayer = false;
        }
        return chObj;
    }

    public void CharacterMove(string _characterData)
    {
        //CharacterInfo characterData = JsonConvert.DeserializeObject<CharacterInfo>(_characterData);
        ////GameObject characterObj = GameObject.FindGameObjectsWithTag(characterData.category).FirstOrDefault(x => x.GetComponent<ChBase>().);
        //GameObject chObj = otherCharacter.FirstOrDefault(x => x.name == characterData.nickname + "_" + characterData.uid);
        //if (chObj == null)
        //{
        //    return;
        //}
        //chObj.transform.position = new Vector3(characterData.data_position[0], characterData.data_position[1], characterData.data_position[2]);

        CharacterInfo characterData = JsonConvert.DeserializeObject<CharacterInfo>(_characterData);
        if (characterData.category != "Player")
        {
            return;
        }
        GameObject characterObj = otherCharacter.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == characterData.uid);
        if (characterObj == null)
        {
            return;
        }
        characterObj.transform.position = new Vector3(characterData.data_position[0], characterData.data_position[1], characterData.data_position[2]);
    }

    public void CharacterRotate(string _characterData)
    {
        CharacterInfo characterData = JsonConvert.DeserializeObject<CharacterInfo>(_characterData);
        if (characterData.category != "Player")
        {
            return;
        }
        GameObject characterObj = otherCharacter.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == characterData.uid);
        if (characterObj == null)
        {
            return;
        }
        characterObj.transform.rotation = new Quaternion(characterData.data_rotation[0], characterData.data_rotation[1], characterData.data_rotation[2], characterData.data_rotation[3]);
    }

    public void TriggerAnim(string _characterData, string animName, float animSpeed, bool force)
    {
        CharacterInfo characterData = JsonConvert.DeserializeObject<CharacterInfo>(_characterData);
        List<GameObject> temp = new List<GameObject>(otherCharacter);
        temp.Add(myCharacter);
        GameObject chObj = temp.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == characterData.uid);
        if (chObj == null)
        {
            return;
        }
        ChBase chBase = chObj.GetComponent<ChBase>();
        chBase.chAnim.TriggerAnim(animName, animSpeed, force);
    }

    public void TriggerEffect(string _baseInfo, string _animEffects)
    {
        BaseInfo baseInfo = JsonConvert.DeserializeObject<BaseInfo>(_baseInfo);
        List<GameObject> temp = new List<GameObject>(otherCharacter);
        temp.Add(myCharacter);
        GameObject chObj = temp.FirstOrDefault(x => x.GetComponent<ChBase>().chInfo.uid == baseInfo.uid);
        if (chObj == null)
        {
            return;
        }
        ChBase chBase = chObj.GetComponent<ChBase>();
        AnimEffect[] animEffects = JsonConvert.DeserializeObject<AnimEffect[]>(_animEffects);
        for (int i = 0; i < animEffects.Length; i++)
        {
            chBase.chAnim.SpawnAnimEffect(animEffects[i]); 
        }
    }

    public void OtherCharacterDisconnected(CharacterInfo[] characterList)
    {
        for (int i = 0; i < characterList.Length; i++)
        {
            GameObject otherCharacterObj = otherCharacter.FirstOrDefault(x => x.name == characterList[i].nickname + "_" + characterList[i].uid);
            if (!otherCharacterObj)
            {
                continue;
            }
            otherCharacter.Remove(otherCharacterObj);
            Destroy(otherCharacterObj);
        }
    }

    public void ClearOtherCharacter()
    {
        otherCharacter.ForEach(x =>
        {
            Destroy(x);
        });
        otherCharacter.Clear();
    }
}
