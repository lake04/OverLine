using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    private static System.Random random = new System.Random();

    public List<Skill> skillList;
    public Transform[] transforms; 
    [SerializeField]
    private int max = 5; 
    private List<int> newTransforms;
    private int count = 0; 

    void Start()
    {
        newTransforms = new List<int>();
        for (int i = 0; i < transforms.Length; i++)
        {
            newTransforms.Add(i); 
        }
        SpawnSkills();
    }

    public void SpawnSkills()
    {
        int count = 0;

        while (count < max && newTransforms.Count > 0)
        {
            RandomSkill();
            count++;
        }
    }

    public void RandomSkill()
    {
        if (newTransforms.Count == 0)
        {
            return;
        }

        int randomIndex = UnityEngine.Random.Range(0, newTransforms.Count); 
        int _pos= newTransforms[randomIndex];
        newTransforms.RemoveAt(randomIndex);

        int result = UnityEngine.Random.Range(0, skillList.Count);

        Skill _spSkill = Instantiate(skillList[result], transforms[_pos]);
        _spSkill.isSpIndex = _pos;
    }

    public void EndTurn()
    {
        Debug.Log("ÅÏÁ¾·á");
        RandomSkill();
    }

    public void RemoveSkill(Skill _skill)
    {
        if (_skill != null && _skill.isSpIndex >= 0)
        {
            int _pos = _skill.isSpIndex;

            if (!newTransforms.Contains(_pos))
            {
                newTransforms.Add(_pos);
            }

            Destroy(_skill.gameObject);
        }
    }
}
