using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilUi : MonoBehaviour
{
    public List<GameObject> skils = new List<GameObject>();
    Vector3 mousePosition;
    Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        SkileCheak();
    }

    private void SkileCheak()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 15f);
        Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);
        if(hit.collider == null) return;
        else if (hit.collider.CompareTag("Skil"))
        {
            Debug.Log(hit);
        }
       
    }
}
