using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public GamaManger manger;
    public GameObject skill;

    public List<Skill> skillList = new List<Skill>();
    

    public void AddSkills(skillInfoData skillData)
    {
        Skillreset();
        skillList.AddRange(skillData.skills);
        GameObject _skill = Instantiate(skill);
        _skill.GetComponent<Skill>();
    }

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    public void AddResources(string resourceType, int amount)
    {
      
    }
    public void Skillreset()
    {
        skillList.Clear();
    }
}
