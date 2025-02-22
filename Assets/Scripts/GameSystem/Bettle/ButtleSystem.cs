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
    Unit enemyUnit;

    [SerializeField]
    private GameObject unitUiPrefab;
   
    public BattleState state;
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
            Debug.Log("턴 시작");
            for (int i = 0; i < playerUnit.skillList.Count; i++)
            {
                clash(playerUnit, enemyUnit,i);
            }
            playerUnit.skillList.Clear();
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
            enemyUnit = _enemy.GetComponent<Unit>();
        }
    }

    #region 합
    public void clash(Player _pSkil, Unit _enemyUnit,int num)
    {
        _enemyUnit.currentHp-= _pSkil.skillList[num].skill.power;
        playerUnit.Skillreset(num);
        Debug.Log("합");
    }
    #endregion
}
