using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public List<Skill> skills;

    void Start()
    {
       
    }

    void Update()
    {
        HpSlider();
    }
}
