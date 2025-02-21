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
       
    }
    #endregion

    public void SelectSkil()
    {

    }
}
