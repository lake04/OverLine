using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManger : MonoBehaviour
{
    public int corrosion;
    public int assimilate;
    public int cost;

    public int resources1;
    public int resources2;
    public int resources3;

    public int normal;
    public Text normalText;
    public int fatal;
    public Text fatalText;
    public int ineff;
    public Text ineffText;

    public int corrosionPoint;
    public Slider corrosionSlider;
    public int assimilatePoint;
    public Slider assimilateSlider;
    public int cost;
    public Text costText;
    
    void Start()
    {
      
    }

    void Update()
    {
        Slider(corrosionPoint,assimilatePoint);
        Text();
    }
    private void OnApplicationQuit()
    {
        Reset();
    }

    public void AddResistances(Skill _skill)
    {
        Debug.Log("자원 추가");
        switch(_skill.resistances)
        {
            case resistances.Normal:
                {
                    normal += _skill.resourceCount;
                    break;
                }
            case resistances.Fatal:
                {
                    fatal += _skill.resourceCount;
                    break;
                }
            case resistances.Ineff:
                {
                    ineff += _skill.resourceCount;
                    break;
                }
            default: break;
        }
    }
    public void Slider(int _corrosionPoint,int _assimilatePoint)
    {
        corrosionSlider.maxValue = 100;
        corrosionSlider.value = _corrosionPoint;

        assimilateSlider.maxValue = 100;
        assimilateSlider.value = _assimilatePoint;
    }

    public void Text()
    {
        normalText.text = normal.ToString();
        fatalText.text = fatal.ToString();
        ineffText.text = ineff.ToString();
        costText.text = cost.ToString();
    }
    public void Reset()
    {
     normal =0;
     fatal =0 ;
     ineff=0;

     corrosionPoint = 0;
     assimilatePoint = 0;
     cost = 0;
     }
}
