using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    int a = 50;
    int b;


    void Start()
    {
        
            //0~100
            int result = Random.Range(0, 100);
            Debug.Log($"{result} ,{a}");

            if (result >= a)
            {
                Debug.Log("�� �¸�");
                a--;

            }
            else
            {
                Debug.Log("�� �й�");

                a++;
            }
    }
}
