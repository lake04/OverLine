using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHover : MonoBehaviour
{
    public  Vector3 originalScale;
    private Vector3 hoverScale;

    private void Start()
    {
        originalScale = transform.localScale;

        hoverScale = new Vector3(originalScale.x*1.2f, originalScale.y*1.2f,0);
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
