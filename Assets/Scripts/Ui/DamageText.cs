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
      //적이 받는 데미지코드에서
      //public GameObject Infodamage;
      //public Transform Textpos;
      //  GameObject Text = Instantiate(Infodamage);
      //    Text.transform.position = Textpos.position;
      //    Text.GetComponent<DamageText>().Damageinfo = 적이 받은 데미지
      //적 코드에 TextPos 값을 게임 오브젝트 트렌스폼으로 바꾸기
      //
    }
  private void DestroyText()
    {
        Destroy(Damagetext);
    }
}
