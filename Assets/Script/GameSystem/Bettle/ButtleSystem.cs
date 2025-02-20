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

    [SerializeField]
    private GameObject unitUiPrefab;
    [SerializeField]
    private Transform canvasTransform;

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
            for(int i = 0; i < playerUnit.skils.Count; i++)
            {
                clash(playerUnit.skils[i], enemyUnit.skils[i]);
            }
            
        }
    }

    private void SetUpBattle()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            GameObject _player = Instantiate(playerPrefabs[i], playerTransforms[i]);
            playerUnit = _player.GetComponent<Unit>();
            //SpawnUnitHpSlider(_player);
        }
        for (int j = 0; j < enemyPrefabs.Length; j++)
        {
            GameObject _enemy = Instantiate(enemyPrefabs[j], enemyTransformss[j]);
            enemyUnit = _enemy.GetComponent<Unit>();
            //SpawnUnitHpSlider(_enemy);
        }
    }

    private void SpawnUnitHpSlider(GameObject unit)
    {
        GameObject sliderclone = Instantiate(unitUiPrefab);
        sliderclone.transform.SetParent(canvasTransform);
        sliderclone.transform.localScale = Vector3.one;
        sliderclone.GetComponent<FollowUnitUi>().SetUp(unit.transform);
        sliderclone.GetComponent<UnitView>().Setup(unit.GetComponent<Unit>());
    }

    #region 합
    public void clash(Skil _pSkil, Skil _eSkil)
    {
        playerUnit.skils.Clear();
        while(_eSkil.coinCount>=1 && _pSkil.coinCount>=1)
        {
            count++;
            Debug.Log($"count:{count}");
            Debug.Log($"pSkil.basicPower:{_pSkil.basicPower}, pSkil.coinPower:{_pSkil.coinPower}, pSkil.coinCount:{_pSkil.coinCount}");
            Debug.Log($"_eSkil.basicPower:{_eSkil.basicPower}, _eSkil.coinPower:{_eSkil.coinPower}, _eSkil.coinCount:{_eSkil.coinCount}");
            _pSkil.coin(_pSkil.basicPower, _pSkil.coinPower, _pSkil.coinCount, playerUnit.sanity);
            _eSkil.coin(_eSkil.basicPower, _eSkil.coinPower, _eSkil.coinCount, enemyUnit.sanity);
            Debug.Log($"{_pSkil.basicPower} {_eSkil.basicPower}");
            if (_pSkil.power > _eSkil.power)
            {
                if (_eSkil.coinCount > 1) _eSkil.coinCount--;
                else
                {
                    playerUnit.sanity += 5;
                    enemyUnit.sanity -= 5;
                    Debug.Log("플레이어 승");
                    enemyUnit.currentHp -= _pSkil.coinPower;
                    Debug.Log($"enemyHp : {enemyUnit.currentHp}");
                    break;
                }
            }
            else if (_pSkil.power < _eSkil.power)
            {
                if (_pSkil.coinCount > 1) _pSkil.coinCount--;
                else
                {
                    playerUnit.sanity -= 5;
                    enemyUnit.sanity += 5;
                    Debug.Log("적 승");
                    playerUnit.currentHp -= _eSkil.coinPower;
                    Debug.Log($"playerHp : {playerUnit.currentHp}");
                    break;
                }
            }
        }
    }
    #endregion

}
