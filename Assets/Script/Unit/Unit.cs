using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int minSpeed;
    public int maxSpeed;
    public int sanity;
    public  List<Skil>  skils;

   
    private void Awake()
    {
        this.currentHp = this.maxHp;
    }
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        this.currentHp -= damage;
    }
}
