using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public float damage;
    public float defense;
    public float minDefense;
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
        this.minDefense = defense;
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
        currentShield = defense;
        float currentDamage = damage * 0.5f > 1 ? damage * 0.5f : currentDamage = 1;
        float _takeDamage = (_damage * currentDamage) - currentShield > 1 ? (_damage * currentDamage) - currentShield : 1;

        this.currentHp= currentHp - _takeDamage;

        GameObject spawnText = Instantiate(SpawnDamageText, TextPos);
        spawnText.GetComponent<DamageText>().Damageinfo = _takeDamage;
        StartCoroutine(HitEffect());
        if (this.currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void NoramlTakeDamage(float _damage)
    {
        currentShield = defense;
        float _takeDamage = _damage - currentShield>1 ? _damage-currentShield : 1;
        this.currentHp = currentHp - _takeDamage;
        GameObject spawnText = Instantiate(SpawnDamageText, TextPos);
        spawnText.GetComponent<DamageText>().Damageinfo = _takeDamage;
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
