using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skil : MonoBehaviour
{
    public int a = 50;
    public int basicPower;
    public int coinPower;
    public int coinCount;


    public void coin(int _basicPower, int _coinPower, int _coinCount, int _sanity)
    {

        for (int i = 0; i < _coinCount; i++)
        {
            int result = Random.Range(0, 100);
            Debug.Log($"{result} ,{_sanity}");
            if (result >= _sanity)
            {
                Debug.Log("¾Õ¸é");
                _basicPower += _coinPower;
            }
            else
            {
                Debug.Log("µÞ¸é");
            }
            Debug.Log($"{_basicPower}");
        }
        Debug.Log($"{this.basicPower}");
        Debug.Log("-----------------------");
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f);
    }
}
