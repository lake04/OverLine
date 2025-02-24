using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkilUi : MonoBehaviour
{
    public List<GameObject> skils = new List<GameObject>();
    private Vector3 mousePosition;
    private Camera camera;
    public Player player;
    public Enemy[] enemy;
    public GamaManger gamaManger;

    private void Start()
    {
        camera = Camera.main;
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            player = FindObjectOfType<Player>();
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

        Skill target = hit.collider.GetComponent<Skill>();
        if (target != null)
        {
            Debug.Log("SkilÃß°¡");
            if (target.cost > gamaManger.cost) return;
            player.skills.Add(target);
            gamaManger.cost -= target.cost;
            Destroy(target.gameObject);
        }
    }

}
