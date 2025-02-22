using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManger : MonoBehaviour
{
    public Skill skill;
    public int Normal;
    public int Fatal;
    public int Ineff;
    public int corrosionPoint;
    public int assimilatePoint;
    public int cost;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddResistances(Skill _skill)
    {
        switch(_skill.resistances)
        {
            case resistances.Normal:
                {
                    Normal += _skill.resourceCount;
                    break;
                }
            case resistances.Fatal:
                {
                    Fatal += _skill.resourceCount;
                    break;
                }
            case resistances.Ineff:
                {
                    Ineff += _skill.resourceCount;
                    break;
                }
        }
    }
}
