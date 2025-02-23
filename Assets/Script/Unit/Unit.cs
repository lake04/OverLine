using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int minSpeed;
    public int maxSpeed;
    public int defense;
    public int currentDefense;
    public int sanity;
    public  List<Skill>  skills;
    public Slider hpSlider;

    private void Awake()
    {
        this.currentHp = this.maxHp;
    }
    void Update()
    {
        HpSlider();
    }

    public void TakeDamage(int damage)
    {
        currentDefense = defense;
        this.currentHp= (currentHp+currentDefense)- damage;
        currentDefense = currentDefense - damage;
        if (this.currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void HpSlider()
    {
        hpSlider.value = currentHp;
        hpSlider.maxValue = maxHp;
    }
}
