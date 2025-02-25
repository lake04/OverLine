using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    void Start()
    {
        EffectEestroy();
    }

    void Update()
    {
        
    }

    public void EffectEestroy()
    {
        Destroy(this.gameObject,1f);
    }
}
