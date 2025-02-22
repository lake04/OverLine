using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START,PLAYTURN,WON,LOSE}

public class ButtleSystem : MonoBehaviour
{
    #region 기본 정보
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    public Transform[] playerTransforms;
    public Transform[] enemyTransformss;

    Player playerUnit;
    Enemy enemyUnit;

    [SerializeField]
    private GameObject unitUiPrefab;
    [SerializeField]
    private Transform canvasTransform;

    public BattleState state;

    public GamaManger gamaManger;

    #endregion

    int count = 0;
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(playerUnit.skills.Count <=0) return;
            for(int i = 0; i <=playerUnit.skills.Count; i++)
            {
                PlayerAttack(playerUnit, enemyUnit,i);
                count++;
            }
            count = 0;
        }
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
        }
    }

    #region 합
    public void PlayerAttack(Player _player,Enemy _enemy,int num)
    {
        Debug.Log("공격");
        Debug.Log($"count:{count}");
        _player.skills[num].UseSkil(_player, _enemy);
        playerUnit.skills.RemoveAt(num);
    }
    #endregion

}
