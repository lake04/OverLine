using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roland : Fight
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clash();
        }
    }
}
