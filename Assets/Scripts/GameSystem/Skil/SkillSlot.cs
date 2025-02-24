using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    public float spacing = 5f;
    public List<Skill> skillList;
    public Transform[] transforms;
    [SerializeField]
    private int max = 5; 
    private int count = 0;

    void Start()
    {
        for(int i = 0; i < max; i++)
        {
            RandomSkill();
        }
    }
    public void Update()
    {
      
       
    }

    public void RandomSkill()
    {
       Debug.Log("스킬 추가");
       if (count >= transforms.Length) count = 0;
       int result = Random.Range(0, skillList.Count);
       Skill spskill = Instantiate(skillList[result], transforms[count++]);
    } 
}
