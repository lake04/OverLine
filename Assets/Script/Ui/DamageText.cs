using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
     Text Damagetext;
    public int Endinfo;
    public int Damageinfo;
    public float destroyTime = 0.7f;
    private void Start()
    {
        Damagetext = GetComponent<Text>();
        Damagetext.text = Damageinfo.ToString();
        Invoke("DestroyText", destroyTime);
    }
    public void Update()
    {
    
    }
  private void DestroyText()
    {
        Destroy(Damagetext);
    }
}
