using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="Skill")]
public class Skill:ScriptableObject
{
    public string skillName;
    public string skillType;
    public int power;
    public int defense;
    public int cost;
    public int level;
    public int maxLevel;
    public int corrosionPoint;
    public int assimilatePoint;
    public string resourceType;
    public int resourceCount;
    public Sprite sprite;
}

public class SkillComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] public Skill skill;
    public Player player;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = skill.sprite;
        Debug.Log($"{skill.power}");
    }

    public void OnMouseDown()
    {
        SelectSkil();
    }


    public void SelectSkil()
    {
        Debug.Log("스킬 추가");
        player.AddSkills(this.gameObject.GetComponent<SkillComponent>());
    }
}
