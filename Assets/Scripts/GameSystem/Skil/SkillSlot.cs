using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    public float spacing = 5f; 

    void Start()
    {
        ArraySkill();
    }

    void ArraySkill()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.position = new Vector3(i * spacing, -3.5f, 0);
        }
    }
}
