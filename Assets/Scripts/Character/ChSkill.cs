using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChSkill : MonoBehaviour
{
    [SerializeField] private ChBase chBase;
    public GameObject target;
    public SkillBaseJSON currentCasting;
    public bool locked;

    private void Awake()
    {
        chBase = GetComponent<ChBase>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectTargetToRelease(SkillBaseJSON skillBaseJSON)
    {
        switch (skillBaseJSON.skill_target_type)
        {
            case SkillTargetType.Self:
                target = this.gameObject;
                break;
            case SkillTargetType.Ally:
                target = this.gameObject;
                break;
            case SkillTargetType.Enemy:
                List<GameObject> nearCharacters = GameManager.instance.characterManager.otherCharacter.FindAll(x => chBase.DistanceToObj(this.gameObject, x) <= skillBaseJSON.distance + 5);
                if (nearCharacters.Count <= 0)
                {
                    target = null; 
                    break;
                }
                GameObject nearestTarget = nearCharacters[0];
                for (int i = 1; i < nearCharacters.Count; i++)
                {
                    if (chBase.DistanceToObj(this.gameObject, nearCharacters[i]) < chBase.DistanceToObj(this.gameObject, nearestTarget))
                    {
                        nearestTarget = nearCharacters[i];
                    }
                }
                target = nearestTarget;
                break;
        }
    }
}
