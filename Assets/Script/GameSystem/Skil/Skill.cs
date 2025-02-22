using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum resistances  {Normal,Fatal,Ineff}

public class Skill : MonoBehaviour
{
    public string skillName;
    public int power;
    public int defense;
    public int cost;
    public int level;
    public int maxLevel;
    public int corrosionPoint;
    public int assimilatePoint;
    public int resourceCount;

    public resistances resistances;

    public  Vector3 originalScale;
    private Vector3 hoverScale;

    public GamaManger gamaManger;

    private void Start()
    {
        originalScale = transform.localScale;
        hoverScale = new Vector3(originalScale.x*1.2f, originalScale.y*1.2f,0);
        //gamaManger = FindAnyObjectByType<GamaManger>();
    }
    private void Update()
    {
        
    }
    

    public void PlayerUseSkil(Player _player,Enemy _enemy)
    {
        
            gamaManger.AddResistances(this);
        gamaManger.assimilatePoint += assimilatePoint;
        gamaManger.corrosionPoint += corrosionPoint;
        gamaManger.cost-=cost;
        _player.defense += defense;
        _enemy.TakeDamage(power);
    }

    public void EnemyUseSkil(Player _player, Enemy _enemy)
    {
        gamaManger.AddResistances(this);
        gamaManger.assimilatePoint += assimilatePoint;
        gamaManger.corrosionPoint += corrosionPoint;
        gamaManger.cost -= cost;
        _enemy.defense += defense;
        _player.TakeDamage(power);
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
