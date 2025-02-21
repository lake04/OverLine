using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string skillName;
    public string skillType;  
    public int power;
    public int defense;
    public int cost;
    public int level;
    public int maxLevel;
    public int corrosionPoint;
    public int assimilatePoint;
    public string resourceType;
    public int resourceCount;

    public void UseSkill(Player player)
    {
        player.AddResources(resourceType, resourceCount);
    }
}

[System.Serializable]
public class skillInfoData 
{
    public List<Skill> skills;
}

public class JsonLoader : MonoBehaviour
{
    public Player player;

    public static skillInfoData LoadJsonData(string path)
    {
        TextAsset jsonText = Resources.Load<TextAsset>(path);
        if (jsonText != null)
        {
            return JsonUtility.FromJson<skillInfoData>(jsonText.text);
        }
        return null;
    }

    void Start()
    {
        skillInfoData skillData = LoadJsonData("SkillData");
        if (skillData != null)
        {
            Debug.Log("성공");
            player.AddSkills(skillData);
        }
        else
        {
            Debug.LogError("못함");
        }
    }
}
