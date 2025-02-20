using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum resistances  { Normal,Fatal,Ineff}

public class Skil : MonoBehaviour
{
    public int basicPower;
    public int coinPower;
    public int coinCount;
    public int power;

    public resistances resistances;

    public  Vector3 originalScale;
    private Vector3 hoverScale;


    private void Start()
    {
         originalScale = transform.localScale;

        hoverScale = new Vector3(originalScale.x*1.2f, originalScale.y*1.2f,0);
    }

    public void coin(int _basicPower, int _coinPower, int _coinCount, int _sanity)
    {
        Debug.Log($"{this.basicPower}");
        power = 0;
        Debug.Log($"power:{power}");
        for (int i = 0; i < _coinCount; i++)
        {
            int result = Random.Range(0, 100);
            //Debug.Log($"{result} ,{_sanity}");
            if (result <= _sanity)
            {
                Debug.Log("앞면");
                _basicPower += _coinPower;
            }
            else
            {
                Debug.Log("뒷면");
            }
        }
        power = _basicPower;
        Debug.Log($"power:{power}");
        Debug.Log($"매개변수 _basicPower:{_basicPower}"); 
        Debug.Log("-----------------------");
    }

    private void OnMouseEnter()
    {
       transform.localScale = hoverScale;
    }
    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }
}
