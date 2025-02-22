using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START,PLAYTURN, ENEMYTURN, WON,LOSE}

public class ButtleSystem : MonoBehaviour
{
    #region 기본 정보
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    public Transform[] playerTransforms;
    public Transform[] enemyTransformss;

    Player playerUnit;
    Enemy enemyUnit;

    public List<Enemy> enemyList;

    [SerializeField]
    private GameObject unitUiPrefab;
    [SerializeField]
    private Transform canvasTransform;

    public BattleState state;

    public GamaManger gamaManger;
    private Vector3 mousePosition;
    private Camera camera;
    #endregion

    int count = 0;
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
        camera = Camera.main;
    }

    private void Update()
    {
        PlayerTrun();
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
    public void PlayerAttack(Player _player,Enemy _enemy,int num)
    {
        Debug.Log("플레이어 공격");
        _player.skills[num].PlayerUseSkil(_player, _enemy);
        _player.skills.RemoveAt(num);
    }
    #endregion
    private void SkilCheak()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 15f);
        Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);

        if (hit.collider == null) return;

        Enemy target = hit.collider.GetComponent<Enemy>();
        if (target != null)
        {
            Debug.Log("Skil추가");
            PlayerAttack(playerUnit, target,1);
        }
    }
    public void PlayerTrun()
    {
        if (state != BattleState.ENEMYTURN) state = BattleState.PLAYTURN;
        if (state == BattleState.PLAYTURN)
        {
            Debug.Log("플레이어 턴");
            if (Input.GetKeyDown(KeyCode.P))
            {
                for (int i = playerUnit.skills.Count - 1; i >= 0; i--)
                {
                    PlayerAttack(playerUnit, enemyUnit, i);
                }
                playerUnit.defense = 0;
                state = BattleState.ENEMYTURN;
            }
        }
    }

    public void EnemyTrun()
    {
        if(state == BattleState.ENEMYTURN)
        {
            Debug.Log("Enemy턴");
            for (int i = enemyUnit.skills.Count - 1; i >= 0; i--)
            {
                enemyUnit.skills[i].EnemyUseSkil(playerUnit, enemyUnit);
            }
            state = BattleState.PLAYTURN;
        }
    }
}
