using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BattleState { START, PLAYTURN, ENEMYTURN, WON, LOSE }

public class ButtleSystem : MonoBehaviour
{
    private static ButtleSystem instance;
    
    public static ButtleSystem Instance
    {
        get
        {
            if(instance == null) instance = new ButtleSystem();
            return instance;
        }
    }
    #region 기본 정보
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    public Transform[] playerTransforms;
    public Transform[] enemyTransformss;

    public Player playerUnit;
    public Enemy enemyUnit;

    Enemy selectEnemy;
    int index;

    public List<Enemy> enemyList;

    public BattleState state;

    public GamaManger gamaManger;
    private Vector3 mousePosition;
    private Camera camera;
    public SkillSlot skillSlot;

    public StageManager stageManager;
    #endregion

    int count = 0;
    public int num;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        stageManager = FindAnyObjectByType<StageManager>();
        stageManager.Init(num);
    }

    void Start()
    {
        state = BattleState.START;
        camera = Camera.main;
        
        SetUpBattle();

    }

    private void Update()
    {
        PlayerTrun();
        if (Input.GetMouseButtonDown(0))
        {
            EnemySelect();
        }
        EnemyTrun();
    }

    private void SetUpBattle()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            GameObject _player = Instantiate(playerPrefabs[i], playerTransforms[i]);
            playerUnit = _player.GetComponent<Player>();
        }
        for (int j = 0; j < enemyPrefabs.Length; j++)
        {
            GameObject _enemy = Instantiate(enemyPrefabs[j], enemyTransformss[j]);
            enemyUnit = _enemy.GetComponent<Enemy>();
            enemyList.Add(enemyUnit);
        }
    }


    #region 합
    public void PlayerAttack(Player _player, Enemy _enemy, int num)
    {
        Debug.Log("플레이어 공격");
        _player.skills[num].PlayerUseSkil(_player, _enemy);
        _player.skills.RemoveAt(num);
    }
    #endregion
    private void EnemySelect()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 15f);
        Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);

        if (hit.collider == null) return;

        Enemy target = hit.collider.GetComponent<Enemy>();
        if (target != null)
        {
            Debug.Log("적 추가");
            index = enemyList.IndexOf(target);
        }
    }
    #region 턴 관련
    public void PlayerTrun()
    {
        if (gamaManger.cost == 0) gamaManger.cost = 1;
        if (state != BattleState.ENEMYTURN) state = BattleState.PLAYTURN;
        if (state == BattleState.PLAYTURN)
        {
            skillSlot = FindAnyObjectByType<SkillSlot>();

            Debug.Log("플레이어 턴");
            if (Input.GetKeyDown(KeyCode.P))
            {
                for (int i = playerUnit.skills.Count - 1; i >= 0; i--)
                {
                    PlayerAttack(playerUnit, enemyList[index], i);
                }
                state = BattleState.ENEMYTURN;
                selectEnemy = null;
                EndTurn();
            }
        }
    }

    public void EnemyTrun()
    {
        if (state == BattleState.ENEMYTURN)
        {
            Debug.Log("Enemy턴");
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                if (enemyList[i].skills.Count != 0 && enemyList[i].skills.Count != null)
                {
                    Debug.Log("zz");
                    EnemyUseSkill(i);
                }
                else
                {
                    playerUnit.NoramlTakeDamage(enemyList[i].damage);
                    Debug.Log("기본 공격");
                }
                if (playerUnit.currentShield > 0) playerUnit.currentShield = 0;
                if (enemyList[i].currentShield > 0) enemyList[i].currentShield = 0;
                playerUnit.defense = playerUnit.minDefense;
                enemyList[i].defense = enemyList[i].minDefense;
            }
            
            state = BattleState.PLAYTURN;
        }
    }

    public void EndTurn()
    {
        Debug.Log("턴종료");
        gamaManger.cost++;
       
        skillSlot.RandomSkill();
        gamaManger.AssimilatePointBuff();
        gamaManger.corrosionPointBuff();
    }
    #endregion

    public void EnemyUseSkill(int _num)
    {
        Debug.Log("Enemy스킬 사용");
        for (int j = enemyUnit.skills.Count - 1; j >= 0; j--)
        {
            enemyList[_num].skills[j].EnemyUseSkil(playerUnit, enemyList[_num]);
        }
    }
}
