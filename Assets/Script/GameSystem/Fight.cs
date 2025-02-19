using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public int a = 50;
    public int basicPower;
    public int coinPower;
    public int coinCount;

    private void Update()
    {
       
    }
    public void coin(int _basicPower, int _CoinPower,int _CoinCount)
    {
       
        for(int i=0;i< _CoinCount; i++)
        {
            int result = Random.Range(0, 100);
            Debug.Log($"{result} ,{a}");
            if (result >= a)
            {
                Debug.Log("¾Õ¸é");
                a -= 5;
                _basicPower += _CoinPower;
            }
            else
            {
                Debug.Log("µÞ¸é");
                a++;
            }
            Debug.Log($"{_basicPower}");
        }
        Debug.Log($"{this.basicPower}");
        Debug.Log("-----------------------");

    }

}
