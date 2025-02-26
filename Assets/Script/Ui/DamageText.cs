using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public TMP_Text Damagetext;
    Color alpha;
    public int Damageinfo;
    public float moveSpeed;
    public float alphaSpeed;
    public float destroyTime;
    public void Awake()
    {
        Damagetext = GetComponent<TMP_Text>();
        alpha = Damagetext.color;
    }
    private void Start()
    {
        DmgText();
    }
    public void Update()
    {
         transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        Damagetext.color = alpha;
    }
  private void DestroyText()
   {
        Destroy(Damagetext, destroyTime);
   }
    public void DmgText()
    {
        Damagetext = GetComponent<TMP_Text>();
        Damagetext.text = Damageinfo.ToString();
        Debug.Log("황주하 퍼리퍼리");
        DestroyText();
    }
}
