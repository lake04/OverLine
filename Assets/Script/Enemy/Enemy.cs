using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fight
{

    void Start()
    {
        this.basicPower = 8;
        this.coinPower = 3;
        this.coinCount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            Debug.Log("Enemy");
            coin(basicPower, coinPower, coinCount);
        }
    }
}
