using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManger : MonoBehaviour
{
    public int normal;
    public Text normalText;
    public int fatal;
    public Text fatalText;
    public int ineff;
    public Text ineffText;
    public int sum;
    public int sum2;
    public bool[] isbuffUp;

    //침식
    public int corrosionPoint;
    public Slider corrosionSlider;
    //동화
    public int assimilatePoint;
    public Slider assimilateSlider;
    public int cost;
    public Text costText;
    public Player player;

    void Start()
    {

    }

    void Update()
    {
        Slider(corrosionPoint, assimilatePoint);
        Text();
    }
    private void OnApplicationQuit()
    {
        Reset();
    }

    public void AddResistances(Skill _skill)
    {
        Debug.Log("자원 추가");
        switch (_skill.resistances)
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
    public void Slider(int _corrosionPoint, int _assimilatePoint)
    {
        corrosionSlider.maxValue = 50;
        corrosionSlider.value = _corrosionPoint;

        assimilateSlider.maxValue = 50;
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
        normal = 0;
        fatal = 0;
        ineff = 0;

        corrosionPoint = 0;
        assimilatePoint = 0;
        cost = 0;
    }

    public void AssimilatePointBuff()
    {
        if (assimilatePoint >= 20 && assimilatePoint <= 39)
        {
            if (isbuffUp[3] == false)
            {
                player.defense += 1;
                sum += 1;
                isbuffUp[0] = true;
            }
            RemoveResistances(1);
        }
        if (assimilatePoint >= 40 && assimilatePoint <= 49)
        {
            if (isbuffUp[1] == false)
            {
                player.defense += 2;
                sum += 2;
                isbuffUp[1] = true;
            }
            RemoveResistances(2);
        }
        if (assimilateSlider.value == 50)
        {
            if (isbuffUp[2] == false)
            {
                player.damage -= sum / 2;
                isbuffUp[2] = true;
            }
            RemoveResistances(3);
        }

    }

    public void corrosionPointBuff()
    {
        if (corrosionPoint >= 20 && corrosionPoint <= 39)
        {
            if (isbuffUp[3] == false)
            {
                player.damage += 1;
                sum2 += 1;
                isbuffUp[3] = true;
            }
            RemoveResistances(1);
        }
        if (corrosionPoint >= 40 && corrosionPoint <= 49)
        {
            if (isbuffUp[4] == false)
            {
                player.damage += 2;
                sum2 += 2;
                isbuffUp[4] = true;
            }
            RemoveResistances(2);
        }
        if (corrosionSlider.value == 50)
        {
            if (isbuffUp[5] == false)
            {
                player.damage -= sum2 / 2;
                isbuffUp[5] = true;
            }
            player.defense--;
        }
    }

    public void RemoveResistances(int num)
    {
        Debug.Log("자원 감소");

        normal -= num;
        fatal -= num;
        ineff -= num;
    }
}
