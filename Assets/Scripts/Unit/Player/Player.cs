using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public GamaManger manger;
    
    public List<SkillComponent> skillList;

    private void Start()
    {
        skillList = new List<SkillComponent>();
    }
    public void AddSkills(SkillComponent skillData)
    {
        skillList.Add(skillData);
    }
   
    public void AddResources(string resourceType, int amount)
    {
      
    }
    public void Skillreset(int num)
    {
        skillList.RemoveAt(num);
        Debug.Log("Áö¿öÁü");
    }

    private void OnApplicationQuit()
    {
        skillList.Clear();
    }
}
