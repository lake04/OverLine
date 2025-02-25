using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public float damage;
    public float defense; 
    public float maxHp;
    public float currentHp;
    public float shield;
    public float currentShield;
    public  List<Skill>  skills;
    public Slider hpSlider;
    public Animator animator;
    public GameObject SpawnDamageText;
    public GameObject hitEffect;
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

    public  void TakeDamage(float _damage)
    {
        currentShield = shield;
        float currentDamage = damage * 0.5f > 1 ? damage * 0.5f : currentDamage = 1;
        float currentDefense = currentDamage - (_damage * currentDamage) > 1 ? currentDamage - (_damage * currentDamage) : 1;

        this.currentHp= (currentHp + currentShield) - (_damage * currentDefense);

        currentShield = currentShield - (_damage * currentDamage)- currentDefense;
        GameObject spawnText = Instantiate(SpawnDamageText, TextPos);
        spawnText.GetComponent<DamageText>().Damageinfo = (_damage * currentDamage) - currentDefense;
        StartCoroutine(HitEffect());
        if (this.currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void NoramlTakeDamage(float _damage)
    {
        currentShield = shield;
        this.currentHp = (currentHp + currentShield) - _damage;
        float currentDamage = _damage - defense > 1 ? _damage - defense : 1;
        this.currentHp = (currentHp + currentShield) - currentDamage;
        currentShield = currentShield - currentDamage;
        GameObject spawnText = Instantiate(SpawnDamageText, TextPos);
        spawnText.GetComponent<DamageText>().Damageinfo = currentDamage;
        StartCoroutine(HitEffect());
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

    public IEnumerator HitEffect()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(hitEffect, this.gameObject.transform);
    }

}
