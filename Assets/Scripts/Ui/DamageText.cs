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
      //���� �޴� �������ڵ忡��
      //public GameObject Infodamage;
      //public Transform Textpos;
      //  GameObject Text = Instantiate(Infodamage);
      //    Text.transform.position = Textpos.position;
      //    Text.GetComponent<DamageText>().Damageinfo = ���� ���� ������
      //�� �ڵ忡 TextPos ���� ���� ������Ʈ Ʈ���������� �ٲٱ�
      //
    }
  private void DestroyText()
    {
        Destroy(Damagetext);
    }
}
