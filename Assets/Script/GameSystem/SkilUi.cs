using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilUi : MonoBehaviour
{
    public List<GameObject> skils = new List<GameObject>();
    private Vector3 mousePosition;
    private Camera camera;
    public Roland player;
    public Enemy enemy;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SkileCheak();

        }
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
            player.coin(player.basicPower,player.coinPower,player.coinCount);
            enemy.coin(enemy.basicPower, enemy.coinPower, enemy.coinCount);
        }
    }
}
