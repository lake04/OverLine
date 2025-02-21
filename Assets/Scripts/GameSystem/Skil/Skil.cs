using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum resistances  { Normal,Fatal,Ineff}

public class Skil : MonoBehaviour
{
    public int basicPower;
    public int defense;
    public int power;
    public GamaManger gamaManger;

    public resistances resistances;

    public  Vector3 originalScale;
    private Vector3 hoverScale;

    private void Start()
    {
        originalScale = transform.localScale;

        hoverScale = new Vector3(originalScale.x*1.2f, originalScale.y*1.2f,0);
        gamaManger = FindAnyObjectByType<GamaManger>();
    }

    public virtual void Skileffect()
    {

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
