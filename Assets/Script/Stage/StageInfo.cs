using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    public string stageName;
    public int enemyCount;
    public GameObject[] enemy;
    public GameObject player;

}

[CreateAssetMenu(fileName = "StageInfo",menuName = "Scriptable Object/StageInfo")]
public class StageInfo:ScriptableObject
{
    public Stage[] stage;
}
