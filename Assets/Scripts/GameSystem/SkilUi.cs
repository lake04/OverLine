using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkilUi : MonoBehaviour
{
    public List<GameObject> skils = new List<GameObject>();
    private Vector3 mousePosition;
    private Camera camera;
    public Roland player;
    public Enemy[] enemy;

    private void Start()
    {
        camera = Camera.main;
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            player = FindObjectOfType<Roland>();
            enemy = FindObjectsOfType<Enemy>();
            SkilCheak();
        }
    }

    private void SkilCheak()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 15f);
        Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);

        if (hit.collider == null) return;

        Skil target = hit.collider.GetComponent<Skil>();
        if (target != null)
        {
            Debug.Log("Skil�߰�");
            player.skils.Add(target); 
        }
    }

}
