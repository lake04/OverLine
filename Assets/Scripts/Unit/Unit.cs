using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int minSpeed;
    public int maxSpeed;
    
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
