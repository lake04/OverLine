using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;

    public static StageManager Instance
    {
        get
        {
            if (instance == null) instance = new StageManager();
            return instance;
        }
    }

    [SerializeField]
    private StageInfo stageInfo;

    private Stage stage;
    public ButtleSystem buttleSystem;

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
    }

    public void LodeStage(int num)
    {
        Stage stage = stageInfo.stage[num];
        SceneManager.LoadScene(stage.stageName);
    }
    public void Init(int num)
    {
        Stage stage = stageInfo.stage[num];
        buttleSystem = FindAnyObjectByType<ButtleSystem>();
        buttleSystem.num = num;

        for (int i = 0; i < stage.enemy.Length; i++)
        {
            buttleSystem.enemyPrefabs[i] = stage.enemy[i];
        }
        buttleSystem.playerPrefabs[0] = stage.player; 
    }
}
