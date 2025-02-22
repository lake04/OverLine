using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManger : MonoBehaviour
{
    public Skill skill;
    public int Normal;
    public int Fatal;
    public int Ineff;
    public int corrosionPoint;
    public Slider corrosionSlider;
    public int assimilatePoint;
    public Slider assimilateSlider;
    public int cost;



    void Start()
    {
        
    }

    void Update()
    {
        Slider(corrosionPoint,assimilatePoint);
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
    public void Slider(int _corrosionPoint,int _assimilatePoint)
    {
        corrosionSlider.maxValue = 100;
        corrosionSlider.value = _corrosionPoint;

        assimilateSlider.maxValue = 100;
        assimilateSlider.value = _assimilatePoint;
    }

   
}
