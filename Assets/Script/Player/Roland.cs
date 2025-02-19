using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roland : Fight
{
    

    void Start()
    {
        this.basicPower = 6;
        this.coinPower = 4;
        this.coinCount = 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Roland");
            coin(basicPower, coinPower, coinCount);
        }
    }
}
