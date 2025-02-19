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

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state;
    #endregion

    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
    }
    
    private void SetUpBattle()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            GameObject _player = Instantiate(playerPrefabs[i], playerTransforms[i]);
        }
        for (int j = 0; j < enemyPrefabs.Length; j++)
        {
            GameObject _enemy = Instantiate(enemyPrefabs[j], enemyTransformss[j]);
        }
    }

    public void clash(Skil _pSkil, Skil _eSkil)
    {

    }
}
