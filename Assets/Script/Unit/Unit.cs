using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int minSpeed;
    public int maxSpeed;
    public Skil[] skils;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }
}
