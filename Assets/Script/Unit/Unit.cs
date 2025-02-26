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
    public  List<Skill>  skills;
    public Slider hpSlider;
    public Animator animator;
    public GameObject SpawnDamageText;
    public Transform TextPos;

    private void Awake()
    {
        this.currentHp = this.maxHp;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
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
        GameObject Spawntext = Instantiate(SpawnDamageText, TextPos);
        Spawntext.GetComponent<DamageText>().Damageinfo = damage;
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
    public void UseAnimation(string name)
    {
        if(name != null) animator.SetTrigger(name);
        else return;
    }
}
