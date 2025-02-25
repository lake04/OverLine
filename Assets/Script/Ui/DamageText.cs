using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageText : MonoBehaviour
{
    TMP_Text Damagetext;
    public int Endinfo;
    public float Damageinfo;
    public float destroyTime = 0.7f;
    private void Start()
    {
        DText();
    }
    public void Update()
    {
    
    }
    private void DText()
    {
        Damagetext = GetComponent<TMP_Text>();
        Damagetext.text = Damageinfo.ToString();
        DestroyText();
    }
    private void DestroyText()
    {
       Destroy(Damagetext, destroyTime);
    }
}
