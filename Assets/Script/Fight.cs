using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    int a = 50;
    int b;


    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clash();
        }
    }
    public void clash()
    {
        int result = Random.Range(0, 100);
        Debug.Log($"{result} ,{a}");

        if (result >= a)
        {
            Debug.Log("�� �¸�");
            a-=5;

        }
        else
        {
            Debug.Log("�� �й�");

            a++;
        }
    }
}
